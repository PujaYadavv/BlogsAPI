using BlogsServices.Core.Interfaces;
using BlogsServices.Core.Models;
using Newtonsoft.Json;

namespace BlogsServices.service.JsonImplementation
{

    public class BlogServices : IBlogsServices
    {
        string jsonFilePath = @"C:\Users\Puja.Kumari\Desktop\BlogsWriterDB.json";


        private IWriterServices _writerServices;
        public BlogServices(IWriterServices writerServices)
        {
            _writerServices = writerServices;
        }
        public async Task<List<Blogs>> GetAllBlogs(int writerId)
        {
            return await Task.Run(() =>
            {
                string writerString = File.ReadAllText(jsonFilePath);
                List<Writer> existingWriter = JsonConvert.DeserializeObject<List<Writer>>(writerString);
                if (existingWriter != null)
                {
                    Writer existingwriter = existingWriter.FirstOrDefault(w => w.Id == writerId);
                    if (existingwriter != null)
                    {
                        return existingwriter.blogs1;
                    }
                }
                return null;
            });
        }
        public async Task<Blogs> GetBlogs(int writerId, int id)
        {
            return await Task.Run(() =>
            {
                string writerString = File.ReadAllText(jsonFilePath);
                List<Writer> existingWriters = JsonConvert.DeserializeObject<List<Writer>>(writerString);
                if (existingWriters != null)
                {
                    Writer existingwriter = existingWriters.FirstOrDefault(w => w.Id == writerId);
                    if (existingwriter != null)
                    {
                        if (existingwriter.blogs1 != null)
                        {
                            Blogs blogs = existingwriter.blogs1.FirstOrDefault(r => r.Id == id);
                            if (blogs != null)
                            {
                                return blogs;
                            }
                        }
                    }
                }
                return null;
            });
        }

        public async Task<bool> CreateBlogs(int writerId, Blogs blogs)
        {
            return await Task.Run(() =>
            {

                string writerString = File.ReadAllText(jsonFilePath);
                List<Writer> existingWriters = JsonConvert.DeserializeObject<List<Writer>>(writerString);
                if (existingWriters != null)
                {
                    Writer existingwriter = existingWriters.FirstOrDefault(w => w.Id == writerId);
                    if (existingwriter != null)
                    {
                        if (existingwriter.blogs1 == null)
                        {
                            existingwriter.blogs1 = new List<Blogs>();
                        }
                        existingwriter.blogs1.Add(blogs);
                    }
                }
                string Writerstring = JsonConvert.SerializeObject(existingWriters, Formatting.Indented);
                File.WriteAllText(jsonFilePath, Writerstring);
                return true;
            });
        }
        public async Task<bool> UpdateBlogs(int writerId, Blogs blogs)
        {
            return await Task.Run(() =>
            {
                string writerString = File.ReadAllText(jsonFilePath);
                List<Writer> existingWriters = JsonConvert.DeserializeObject<List<Writer>>(writerString);
                if (existingWriters != null)
                {
                    Writer existingWriter = existingWriters.FirstOrDefault(w => w.Id == writerId);
                    if (existingWriter != null)
                    {
                        Blogs existingBlog = existingWriter.blogs1.FirstOrDefault(b => b.Id == blogs.Id);
                        if (existingBlog != null)
                        {
                            existingBlog = blogs;
                        }
                    }
                }
                string Writerstring = JsonConvert.SerializeObject(existingWriters, Formatting.Indented);
                File.WriteAllText(jsonFilePath, Writerstring);

                return true;
            });
        }
        public async Task<bool> DeleteBlogs(int writerId, int id)
        {
            return await Task.Run(() =>
            {
                string writerString = File.ReadAllText(jsonFilePath);
                List<Writer> existingWriters = JsonConvert.DeserializeObject<List<Writer>>(writerString);
                if (existingWriters != null)
                {
                    Writer existingWriter = existingWriters.FirstOrDefault(w => w.Id == writerId);
                    if (existingWriter != null)
                    {

                        if (existingWriter.blogs1 != null)
                        {
                            existingWriter.blogs1.RemoveAll(b => b.Id == id);
                        }

                    }
                }
                string Writerstring = JsonConvert.SerializeObject(existingWriters, Formatting.Indented);
                File.WriteAllText(jsonFilePath, Writerstring);
                return true;
            });
        }
    }
}

