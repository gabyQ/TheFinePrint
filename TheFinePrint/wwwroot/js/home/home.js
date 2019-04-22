var homeSettings,
    Home = {
        settings: {
            // Main photo carousel
            carousel: document.getElementById('main-carousel'),
            blogSection: document.getElementById('blog'),
            categoriesContainer: document.getElementById('categories-container'),
            homeWrapper: document.getElementById('wrapper'),
        },

        init: function () {
            homeSettings = this.settings;

            
            let homeVm = new homeViewModel();
            ko.applyBindings(homeVm, this.settings.homeWrapper);
            //this.bindUIActions();
        },

        bindPosts: function () {

        }

    };

var homeViewModel = function() {
    var self = this;
    self.posts = ko.observableArray([]);
    self.postsPreview = ko.observableArray([]);
    self.categories = ko.observableArray([]);

    if (Blogger != null) {
        Blogger.getBlogPosts().then(function () {
            let posts = Blogger.settings.posts;
            self.posts(posts || []);
            self.postsPreview(self.posts.slice(0, 2));
            self.categories(getPostCategories(posts || []));
        });
    }


    
};

(function () {
    Home.init();
})();