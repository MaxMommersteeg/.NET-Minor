namespace Blogging.DAL
{
    public class Post
    {
        public int Id { get; set; }

        public string Title { get; set; }
        public string Message { get; set; }

        public virtual Blog Blog { get; set; }
    }
}
