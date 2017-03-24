using MyPortfolio.Contexts;
using MyPortfolio.Models.Blog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyPortfolio.Data
{
    public class DbInitializer
    {
        public static void Initialize(BloggingContext context)
        {
            context.Database.EnsureCreated();
            if (context.Blogs.Any())
            {
                return;   // DB has been seeded
            }

            var blogs = new Blog[]
            {
                new Blog{ Url="/Blog" }
            };
            foreach(Blog s in blogs)
            {
                context.Blogs.Add(s);
            }
            context.SaveChanges();

            var posts = new Post[]
            {
                new Post{BlogId = 1, Title = "Title 1", Content="Content1", PathToImage = "image1" },
                new Post{BlogId = 1, Title = "Title 2", Content="Content2", PathToImage = "image2" },
                new Post{BlogId = 1, Title = "Title 3", Content="Content3", PathToImage = "image3" },
                new Post{BlogId = 1, Title = "Title 4", Content="Content4", PathToImage = "image4" },
                new Post{BlogId = 1, Title = "Title 5", Content="Content5", PathToImage = "image5" },
                new Post{BlogId = 1, Title = "Title 5", Content="Content5", PathToImage = "image5" },
                new Post{BlogId = 1, Title = "Title 6", Content="Content6", PathToImage = "image6" },
                new Post{BlogId = 1, Title = "Title 7", Content="Content7", PathToImage = "image7" }
            };
            foreach (Post s in posts)
            {
                context.Posts.Add(s);
            }
            context.SaveChanges();

            var tags = new Tag[]
            {
                new Tag{PostId = 1, TagCategory = Tags.CSHARP},
                new Tag{PostId = 1, TagCategory = Tags.DSP2017},
                new Tag{PostId = 1, TagCategory = Tags.QA},
                new Tag{PostId = 2, TagCategory = Tags.CSHARP},
                new Tag{PostId = 2, TagCategory = Tags.DSP2017},
                new Tag{PostId = 3, TagCategory = Tags.DSP2017},
                new Tag{PostId = 4, TagCategory = Tags.DSP2017},
                new Tag{PostId = 5, TagCategory = Tags.CSHARP}
            };
            foreach (Tag s in tags)
            {
                context.Tags.Add(s);
            }
            context.SaveChanges();
        }
    }
}
