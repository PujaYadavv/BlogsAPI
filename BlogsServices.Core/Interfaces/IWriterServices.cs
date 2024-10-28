using BlogsServices.Core.Models;


namespace BlogsServices.Core.Interfaces
{
    public interface IWriterServices
    {
        Task<List<Writer>> GetAllWriter();
        Task<Writer> GetWriter(int id);
        Task<bool> CreateWriter(Writer writer);
        Task<bool> UpdateWriter(Writer writer);
        Task<bool> DeleteWriter(int id);
    }



}
