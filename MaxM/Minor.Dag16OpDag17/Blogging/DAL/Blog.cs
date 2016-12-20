using System.Collections.Generic;

namespace Blogging.DAL
{
    public class Blog
    {
        public int BlogId { get; set; }
        public string Url { get; set; }

        public virtual ICollection<Post> Posts { get; set; }
    }
}
