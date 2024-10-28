using BlogsServices.Core.Interfaces;
using BlogsServices.Core.Models;
using Newtonsoft.Json;
namespace BlogsServices.service.JsonImplementation
{
    public class WriterServices : IWriterServices
    {
        string jsonFilePath = @"C:\Users\Puja.Kumari\Desktop\BlogsWriterDB.json";

        public async Task<List<Writer>> GetAllWriter()
        {
            return await Task.Run(() =>
            {
                try
                {
                    string writerstring = File.ReadAllText(jsonFilePath);
                    List<Writer> writer = JsonConvert.DeserializeObject<List<Writer>>(writerstring);
                    return writer;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("FileNotFoundException");
                }
                return null;

            });
        }
        public async Task<Writer> GetWriter(int id)
        {
            return await Task.Run(() =>
            {
                string writerstring = File.ReadAllText(jsonFilePath);
                List<Writer> writers = JsonConvert.DeserializeObject<List<Writer>>(writerstring);
                Writer writer = writers.FirstOrDefault(m => m.Id == id);
                return writer;

            });
        }
        public async Task<bool> CreateWriter(Writer writer)
        {
            return await Task.Run(() =>
            {
                string writerstring = File.ReadAllText(jsonFilePath);
                List<Writer> Existingwriters = JsonConvert.DeserializeObject<List<Writer>>(writerstring);
                if (Existingwriters == null)
                {
                    Existingwriters = new List<Writer>();
                }
                Existingwriters.Add(writer);

                string writerString = JsonConvert.SerializeObject(Existingwriters, Formatting.Indented);
                File.WriteAllText(jsonFilePath, writerString);
                return true;

                //try
                //{

                //}
                //catch (Exception ex)
                //{
                //    throw new Exception("path not found..");
                //}

            });
        }
        public async Task<bool> UpdateWriter(Writer writer)
        {
            return await Task.Run(() =>
            {
                string writerstring = File.ReadAllText(jsonFilePath);
                List<Writer> ExistingWriters = JsonConvert.DeserializeObject<List<Writer>>(writerstring);
                if (ExistingWriters != null)
                {
                    int existingWritersindex = ExistingWriters.FindIndex(m => m.Id == writer.Id);
                    if (existingWritersindex > -1)
                    {
                        ExistingWriters[existingWritersindex] = writer;
                    }
                }
                string writerstrings = JsonConvert.SerializeObject(ExistingWriters, Formatting.Indented);
                File.WriteAllText(jsonFilePath, writerstrings);
                return true;
            });
        }
        public async Task<bool> DeleteWriter(int id)
        {
            return await Task.Run(() =>
            {
                throw new Exception("simple throwing");
                string writerStrings = File.ReadAllText(jsonFilePath);
                List<Writer> existingWriter = JsonConvert.DeserializeObject<List<Writer>>(writerStrings);
                if (existingWriter != null)
                {
                    //existingWriter.RemoveAll(existingWriter.Remove);
                    existingWriter.RemoveAll(w => w.Id == id);
                }
                string writerString = JsonConvert.SerializeObject(existingWriter, Formatting.Indented);
                File.WriteAllText(jsonFilePath, writerString);
                return true;
            });
        }

    }
}
