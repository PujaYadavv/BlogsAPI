using BlogsServices.Core.Interfaces;
using BlogsServices.Core.Models;
using Microsoft.EntityFrameworkCore;


namespace BlogsServices.Repository
{
    public class BlogsWriterRepository : IBlogsWriterRepositroy
    {
        public List<Writer> GetAllWriter()
        {
            List<Writer> writer = null;
            using (BlogsWriterContext context = new BlogsWriterContext())
            {
                //   writer = context.Writers.Include(w => context.Blogs).ToList();
                     writer = context.Writers.Include(w => w.blogs1).ToList();
            }
            return writer;
        }
        public Writer GetWriter(int id)
        {
            Writer writer = null;
            using (BlogsWriterContext context = new BlogsWriterContext())
            {
                writer = context.Writers.Include(w => w.blogs1).FirstOrDefault(w => w.Id == id);
                //if(writer != null)
                //{
                //    writer.blogs1=context.Blogs.Where(b=>b.Id==id).ToList();
                //}
            }
            return writer;
        }
        public bool CreateWriter(Writer writer)
        {
            bool result = false;
            using (BlogsWriterContext context = new BlogsWriterContext())
            {
                context.Writers.Add(writer);
                int noOfRowsUpdated = context.SaveChanges();
                if (noOfRowsUpdated > 0)
                {
                    result = true;
                }
            }
            return result;
        }
        public bool UpdateWriter(Writer writer)
        {
            bool result = false;
            using (BlogsWriterContext context = new BlogsWriterContext())
            {
                Writer existingWriter = context.Writers.FirstOrDefault(w => w.Id == writer.Id);
                if (existingWriter != null)
                {
                    context.Writers.Update(writer);
                    int noOfRowsUpdated = context.SaveChanges();
                    if (noOfRowsUpdated > 0)
                    {
                        result = true;
                    }
                }
                return result;
            }
        }

        public bool DeleteWriter(int id)
        {
            bool result = false;
            using (BlogsWriterContext context = new BlogsWriterContext())
            {
                Writer existingWriter = context.Writers.FirstOrDefault(w => w.Id == id);
                if (existingWriter != null)
                {
                    context.Writers.Remove(existingWriter);
                    int noOfRowsAffected = context.SaveChanges();
                    if (noOfRowsAffected > 0)
                    {
                        result = true;
                    }
                }
            }
            return result;

        }

        public List<Blogs> GetAllBlogs(int writerId)
        {
            List<Blogs> blogs = null;
            using (BlogsWriterContext context=new BlogsWriterContext())
            {
                blogs = context.Blogs.Where(b => b.WriterId == writerId).ToList();
            }
            return blogs;
        }
        public Blogs GetBlogs(int writerId, int id)
        {
            Blogs blogs = null;
            using( BlogsWriterContext context=new BlogsWriterContext())
            {
                Writer existingWriter = context.Writers.FirstOrDefault(w => w.Id == writerId);
                if (existingWriter != null)
                {
                    blogs = context.Blogs.FirstOrDefault(b => b.Id == id);
                }
            }
            return blogs;
        }
        public bool CreateBlogs(int writerId, Blogs blogs)
        {
            bool result = false;
            using (BlogsWriterContext context=new BlogsWriterContext())
            {
                Writer existingwriter = context.Writers.FirstOrDefault(w => w.Id == writerId);
                if (existingwriter != null)
                {
                    blogs.WriterId = writerId;
                    context.Blogs.Add(blogs);
                    int noOfRowsEffected = context.SaveChanges();
                    if (noOfRowsEffected > 0)
                    {
                        result = true;
                    }
                }
            }
            return result;
        }
        public bool UpdateBlogs(int writerId, Blogs blogs)
        {

            bool result = false;
            using(BlogsWriterContext context=new BlogsWriterContext())
            {
                Writer existingWriter = context.Writers.FirstOrDefault(w => w.Id == writerId);
                if (existingWriter != null)
                {
                    blogs.WriterId = writerId;
                    context.Blogs.Update(blogs);
                    int noOfRowsAffected = context.SaveChanges();
                    if (noOfRowsAffected > 0)
                    {
                        result = true;
                    }

                }
            }
            return result;
        }
        public bool DeleteBlogs(int writerId, int id)
        {
            bool result = false;
            using (BlogsWriterContext context = new BlogsWriterContext())
            {
                Writer existingWriter = context.Writers.FirstOrDefault(w => w.Id == writerId);
                if (existingWriter != null)
                {
                    Blogs existingBlogs = context.Blogs.FirstOrDefault(b => b.Id == id);
                    if (existingBlogs != null)
                    {
                        context.Blogs.Remove(existingBlogs);
                        int noOfRowsAffected = context.SaveChanges();
                        if (noOfRowsAffected > 0)
                        {
                            result = true;
                        }
                    }

                }
            }
            return result;
        }




    }
}
