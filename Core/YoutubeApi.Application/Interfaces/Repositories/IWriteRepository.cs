using YoutubeApi.Domain.Common;

namespace YoutubeApi.Application.Interfaces.Repositories
{
    public interface IWriteRepository<T> where T : class, IEntityBase, new()
    {
        Task AddAsync(T entity);
        Task AddRangeAsync (IList<T> entities);  
        Task <T> UpateAsync (T entity); //update de genellikle updatelediğim veri döndürülür o yzden T var
        
        //delete async kısmı için int id de verebilirdik ama idsi integer dedğilse patlarız diye böyle yaptık
        Task HardDeleteAsync (T entity); // hard delete  ile veriyi kalıcı olarak sileriz. genelde kullanmayız 
        //Task SoftDeleteAsync (T entity); // soft delete ile veririnin isDeleted kısmını true yaparız. genelde bunu kullanırız



    }
}
