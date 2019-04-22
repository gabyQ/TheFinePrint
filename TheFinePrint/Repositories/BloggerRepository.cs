using System.Collections.Generic;
using System.IO;
using System.Linq;
using TheFinePrint.Utils;
using System.Threading;
using System.Threading.Tasks;

using Google.Apis.Auth.OAuth2;
using Google.Apis.Blogger.v3;
using Google.Apis.Services;
using Google.Apis.Blogger.v3.Data;

namespace Blogger.Repository
{
    public class BloggerRepository : IBloggerRepository
    {
        private UserCredential credential;
        private BloggerService service;
        private List<Post> posts;
        private GoogleClientSecrets clientSecrets;

        public BloggerRepository()
        {
            //Task.Run(() => this.AuthenticateAsync()).Wait();
            InitializeClientService();
        }

        private void InitializeClientService()
        {
            if(service == null)
            {
                ClientSecrets clientSecrets = Newtonsoft.Json.JsonConvert.DeserializeObject<ClientSecrets>(
                File.ReadAllText("Assets/client_secrets.json"));

                var initializer = new BaseClientService.Initializer()
                {
                    ApplicationName = "TheFinePrint",
                    ApiKey = clientSecrets.ApiKey
                };
                service = new BloggerService(initializer);
            }
        }

        private async Task AuthenticateAsync()
        {
            if (service != null)
                return;

            GoogleClientSecrets clientSecrets = Newtonsoft.Json.JsonConvert.DeserializeObject<GoogleClientSecrets>(
                File.ReadAllText("Assets/client_secrets.json"));
            credential = await GoogleWebAuthorizationBroker.AuthorizeAsync(
            clientSecrets.Secrets,
            new[] { BloggerService.Scope.BloggerReadonly },
            "user",
            CancellationToken.None);

            var initializer = new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = "TheFinePrint",
            };

            service = new BloggerService(initializer);
        }

        #region IBloggerRepository members

        public async Task<IEnumerable<Blog>> GetBlogsAsync()
        {
            await AuthenticateAsync();

            var list = await service.Blogs.ListByUser("self").ExecuteAsync();
            if (list.Items == null) return Enumerable.Empty<Blog>();

            return from blog in list.Items
                   select new Blog
                   {
                       Id = blog.Id,
                       Name = blog.Name
                   };
        }

        public async Task<IEnumerable<Post>> GetPostsAsync()
        {
            await AuthenticateAsync();
            var list = await service.Posts.List(Constants.blogId).ExecuteAsync();
            return from post in list.Items
                   select new Post
                   {
                       Title = post.Title,
                       Content = post.Content
                   };
        }

        public async Task<Blog> GetBlogByIdAsync()
        {
            var blog = await service.Blogs.Get(Constants.blogId).ExecuteAsync();
            return Blog.ToBlog(blog);
        }

        public Task<Post> GetPost(string postId)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Post>> SearchPosts(string queryString)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<Post>> GetPostsAsync(string blogId)
        {
            var posts = await service.Posts.List(blogId).ExecuteAsync();
            return posts.Items
                .OrderByDescending(p => p.Published)
                .Select(p => Post.ToPost(p))
                .ToList();
        }

        public Task<Blog> GetBlogByIdAsync(string id)
        {
            throw new System.NotImplementedException();
        }

        #endregion
    }
}