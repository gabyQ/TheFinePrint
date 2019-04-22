using System;
using System.Collections.Generic;

namespace TheFinePrint.Models
{
    public class Blog
    {
        public string Id { get; set; }
        public string Kind { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime PublishedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string URL { get; set; }
        public string SelfLink { get; set; }
        public List<Post> Posts { get; set; }
        public List<Page> Pages { get; set; }
        public Locale Locale { get; set; }
    }

    public class Post
    {
        public int TotalItems { get; set; } = 0;
        public string SelfLink { get; set; }
    }

    public class Page
    {
        public int TotalItems { get; set; } = 0;
        public string SelfLink { get; set; }
    }

    public class Locale
    {
        public string Language { get; set; } = "en";
        public string Country { get; set; } = "Canada";
        public string Variant { get; set; }
    }
}
