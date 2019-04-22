using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Blogger.Repository;
using Google.Apis.Blogger.v3;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TheFinePrint.Utils;

namespace TheFinePrint.Controllers.api
{
    [Route("api/BlogApi")]
    [Produces("application/json")]
    public class BlogApiController : ControllerBase
    {
        private BloggerRepository bloggerRepository;
        public IBloggerRepository repository;

        public BlogApiController()
        {
            this.bloggerRepository = new BloggerRepository();
        }

        [HttpGet]
        [Route("GetBlog")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Blog>> GetBlogAsync()
        {
            Blog blog = await bloggerRepository.GetBlogByIdAsync();
            if (blog == null)
            {
                return NotFound();
            }
            return blog;
        }

        [HttpGet]
        [Route("GetPosts")]
        public async Task<IEnumerable<Post>> GetPostsAsync()
        {
            IEnumerable<Post> posts = await bloggerRepository.GetPostsAsync(Constants.blogId);
            return posts;
        }

        [HttpGet]
        [Route("GetPostById")]
        public async Task<ActionResult<Post>> GetPostByIdAsync(string postId)
        {
            Post post = await bloggerRepository.GetPost(postId);
            return post;
        }

    }
}