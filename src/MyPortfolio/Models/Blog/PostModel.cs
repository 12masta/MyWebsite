using System.Collections.Generic;

namespace MyPortfolio.Models.Blog
{
    public class Post
    {
        public int PostId { get; set; }
        public int BlogId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string PathToImage { get; set; }

        public virtual Blog Blog { get; set; }
        public virtual ICollection<Tag> Tags { get; set; }
    }
}