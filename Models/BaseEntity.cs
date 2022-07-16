namespace CliverApi.Models
{
    public abstract class BaseEntity<T> where T : class
    {
        public T? Id { get; set; }
    }
}
