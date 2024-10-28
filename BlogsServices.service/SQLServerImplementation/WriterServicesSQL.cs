using BlogsServices.Core.Interfaces;
using BlogsServices.Core.Models;


namespace BlogsServices.service.SQLServerImplementation
{
    public class WriterServicesSQL : IWriterServices
    {
        private IBlogsWriterRepositroy _repository;
        public WriterServicesSQL(IBlogsWriterRepositroy repository)
        {
            _repository = repository;
        }
        public async Task<bool> CreateWriter(Writer writer)
        {
            return await Task.Run(() =>
            {
                return _repository.CreateWriter(writer);

            });
        }
        public async Task<bool> DeleteWriter(int id)
        {
            return await Task.Run(() =>
            {
                return _repository.DeleteWriter(id);
            });

        }

        public async Task<List<Writer>> GetAllWriter()
        {
            return await Task.Run(() =>
            {
                return _repository.GetAllWriter();

            });
        }

        public async Task<Writer> GetWriter(int id)
        {
            return await Task.Run(() =>
            {
                return _repository.GetWriter(id);

            });
        }

        public async Task<bool> UpdateWriter(Writer writer)
        {
            return await Task.Run(() =>
            {
                return _repository.UpdateWriter(writer);

            });
        }
    }
}
