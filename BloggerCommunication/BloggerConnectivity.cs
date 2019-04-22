using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using BloggerConnectivity.Models;

namespace BloggerConnectivity
{
    public class BloggerConnectivity
    {
        private static string apiKey = "AIzaSyCh7GOHKMIPuNDhpvTMUDIdrdA9Xfiw8cc";
        private static string clientSecret = "TxLB-OZdHQgKzWvp4IOQjRHH";
        private static string clientId = "943653425951-ptrlftjunmi2glda5pfde15e16m7s87m.apps.googleusercontent.com";
        private static string blogId = "623136061827290723";
        private static string rootUrl = "https://www.googleapis.com/blogger/v3/blogs/";

        static HttpClient client = new HttpClient();

        public async Task<Blog> GetBlog()
        {
            Blog blog = null;
            HttpResponseMessage response = await client.GetAsync($"{rootUrl}{blogId}?key={apiKey}");
            if (response.IsSuccessStatusCode)
            {
                blog = await response.Content.ReadAsAsync<Blog>();
            }
            return blog;
        }

    }
}
