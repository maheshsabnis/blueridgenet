using API_App.MOdels;

namespace API_App.Services
{
    public interface IService<TEntity, in TPk> where TEntity : EntityBase
    {
        Task<ResponseObject<TEntity>> GetAsync();
        Task<ResponseObject<TEntity>> GetAsync(TPk id);
        Task<ResponseObject<TEntity>> CreateAsync(TEntity entity);
        Task<ResponseObject<TEntity>> UpdateAsync(TEntity entity);
        Task<ResponseObject<TEntity>> DeleteAsync(TPk id);
    }


    public class ResponseObject<TEntity> where TEntity : EntityBase
    {
        public List<TEntity>? Records { get; set; }
        public TEntity? Record { get; set; }
        public string? Message { get; set; }
        public int StatusCode { get; set; }
    }
}
