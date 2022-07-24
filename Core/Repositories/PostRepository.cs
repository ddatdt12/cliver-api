using AutoMapper;
using CliverApi.Core.Contracts;
using CliverApi.DTOs;
using CliverApi.Error;
using CliverApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CliverApi.Core.Repositories
{
    public class PostRepository : GenericRepository<Post>, IPostRepository
    {
        private IMapper _mapper;
        public PostRepository(DataContext context, ILogger logger, IMapper mapper) : base(context, logger)
        {
            _mapper = mapper;
        }
        private async Task UpsertPackage(PackageDto package)
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
                var pack = new Package();
                _mapper.Map(package, pack);
                _context.Packages.Add(pack);
            }
            await _context.SaveChangesAsync();
        }
        public async Task Update(int id, UpdatePostDto postData)
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
                    if (postData.StandardPackage == null || postData.PremiumPackage == null)
                        throw new ApiException("Standard,premium package and  is required when offering more packages is enabled", 400);
                    await UpsertPackage(postData.StandardPackage);
                    await UpsertPackage(postData.PremiumPackage);
                }
                else
                {


                }

            }

            _mapper.Map(postData, post);
        }
    }
}
