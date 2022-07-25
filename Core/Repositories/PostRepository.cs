using AutoMapper;
using CliverApi.Core.Contracts;
using CliverApi.DTOs;
using CliverApi.Error;
using CliverApi.Models;
using Microsoft.EntityFrameworkCore;
using static CliverApi.Common.Enum;

namespace CliverApi.Core.Repositories
{
    public class PostRepository : GenericRepository<Post>, IPostRepository
    {
        private IMapper _mapper;
        public PostRepository(DataContext context, ILogger logger, IMapper mapper) : base(context, logger)
        {
            _mapper = mapper;
        }
        private async Task UpsertPackage(UpsertPackageDto package)
        {
            if (package.Id.HasValue)
            {
                var pack = await _context.Packages.FindAsync(package.Id);
                if (pack != null)
                {
                    throw new ApiException("Package not found", 400);
                }

                _mapper.Map(package, pack);
            }
            else
            {
                var existP = await _context.Packages.Where(p => p.IsAvailable && p.Type == package.Type).FirstOrDefaultAsync();
                if (existP != null)
                {
                    _mapper.Map(package, existP);
                }
                else
                {
                    var pack = new Package();
                    _mapper.Map(package, pack);
                    _context.Packages.Add(pack);
                }

            }
        }
        public async Task Update(int id, UpdatePostDto postData)
        {

            using var transaction = _context.Database.BeginTransaction();

            try
            {
                var post = await FindById(id);
                if (post == null)
                {
                    throw new ApiException("Post not found", 404);
                }

                if (postData.HasOfferPackages != null)
                {
                    if (postData.HasOfferPackages.Value)
                    {
                        if (postData.Packages is null || new HashSet<UpsertPackageDto>(postData.Packages.ToList(), new UpsertPackageDtoEqualityComparer()).Count() < 3)
                        {
                            throw new ApiException("Invalid packages data", 400);
                        }

                        foreach (var item in postData.Packages)
                        {
                            item.PostId = id;
                            await UpsertPackage(item);
                        }

                        await _context.SaveChangesAsync();
                    }
                    else
                    {
                        await _context.Entry(post).Collection(p => p.Packages).Query()
                               .Where(p => p.IsAvailable)
                               .LoadAsync();

                        bool needSaveChanges = false;
                        var basicPackage = postData.Packages?.Where(p => p.Type == PackageType.Standard).FirstOrDefault();
                        if (basicPackage != null)
                        {
                            needSaveChanges = true;
                            basicPackage.PostId = post.Id;

                            await UpsertPackage(basicPackage);
                        }
                        if (post.Packages.Count() > 1)
                        {
                            var packs = post.Packages.Where(p => p.Type == PackageType.Premium|| p.Type == PackageType.Standard);

                            foreach (var p in packs)
                            {
                                _context.Packages.Remove(p);
                            }
                            needSaveChanges = true;
                        }
                        if (needSaveChanges) await _context.SaveChangesAsync();
                    }

                }

                _mapper.Map(postData, post);
                await _context.SaveChangesAsync();

                await transaction.CommitAsync();
            }
            catch (Exception)
            {
                await transaction.RollbackAsync();
                throw;
            }



        }

        public async Task<Post> FindById(int id)
        {
            return await _context.Posts.Where(p => p.Id == id).Include(p => p.Packages).Include(p => p.User).FirstOrDefaultAsync();
        }
    }
}
