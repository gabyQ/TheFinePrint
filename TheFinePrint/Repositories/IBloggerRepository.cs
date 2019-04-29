using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using static Google.Apis.Blogger.v3.Data.Post;

namespace Blogger.Repository
{
    public class ClientSecrets
    {
        public string client_id { get; set; }
        public string project_id { get; set; }
        public string ApiKey { get; set; }
        public string token_uri { get; set; }
    }

    /// <summary>Blog data contact.</summary>
    public class Blog
    {
        /// <summary>Gets or sets the blog id.</summary>
        public string Id { get; set; }
        /// <summary>Gets or sets the blog name.</summary>
        public string Name { get; set; }
        /// <summary>Gets or sets the blog description.</summary>
        public string Description { get; set; }

        public static Blog ToBlog(Google.Apis.Blogger.v3.Data.Blog gBlog)
        {
            return new Blog()
            {
                Id = gBlog.Id,
                Name = gBlog.Name,
                Description = gBlog.Description
            };
        }
    }

    /// <summary>Post data contact.</summary>
    public class Post
    {
        public string Id { get; set; }
        /// <summary>Gets or sets the post title.</summary>
        public string Title { get; set; }
        /// <summary>Gets or sets the post content.</summary>
        public string Content { get; set; }
        public string ContentPreview { get; set; }
        public string ImageUrl { get; set; }
        public string PostUrl { get; set; }
        public string Category { get; set; }
        public AuthorData Author { get; set; }
        public string PublishedDate { get; set; }
        public string UpdatedDate { get; set; }
        public long NumComments { get; set; }
        public string CommentUrl { get; set; }
        public IList<string> Labels { get; set; }

        public static Post ToPost(Google.Apis.Blogger.v3.Data.Post gPost)
        {
            return new Post()
            {
                Id = gPost.Id,
                Title = gPost.Title,
                Content = gPost.Content,
                Category = gPost.Labels?.Count > 0 ? gPost.Labels[0] : null,
                Author = gPost.Author,
                PublishedDate = gPost.Published?.ToString("MMMM dd, yyyy"),
                UpdatedDate = gPost.Updated?.ToString("MMMM dd, yyyy"),
                NumComments = gPost.Replies.TotalItems ?? 0,
                CommentUrl = gPost.Replies.SelfLink,
                PostUrl = "/Content/" + gPost.Id,
                ImageUrl = gPost.Images?.Count > 0 ? gPost.Images[0].Url : "/images/blog-1.jpg",
                Labels = gPost.Labels
            };
        }
    }

    public class Author
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public string ImageUrl { get; set; }
    }

    public class Comment
    {
        public string Id { get; set; }
        public DateTime PublishedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string Content { get; set; }
        public Author Author { get; set; }
    }

    /// <summary>Blogger repository for retrieving blogs and posts.</summary>
    public interface IBloggerRepository
    {
        /// <summary>Gets all post for the specified blog.</summary>
        Task<IEnumerable<Post>> GetPostsAsync(string blogId);

        /// <summary>Get a post by ID.</summary>
        Task<Post> GetPost(string postId);

        /// <summary>Search for a post by a query string.</summary>
        Task<IEnumerable<Post>> SearchPosts(string queryString);

        /// <summary>Get a blog by ID.</summary>
        Task<Blog> GetBlogByIdAsync(string id);

        /// <summary>Get all user's blogs.</summary>
        Task<IEnumerable<Blog>> GetBlogsAsync();


    }
}