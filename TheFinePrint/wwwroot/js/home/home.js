var homeSettings,
    Home = {
        settings: {
            // Main photo carousel
            carousel: document.getElementById('main-carousel'),
            blogSection: document.getElementById('blog'),
            categoriesContainer: document.getElementById('categories-container'),
            homeWrapper: document.getElementById('wrapper'),
            body: document.getElementById('body'),
            activeCategory: document.getElementById('active-category') && document.getElementById('active-category').innerHTML,
            activePost: (document.getElementById('active-post') && document.getElementById('active-post').innerHTML.replace('#', ''))
        },

        init: function () {
            homeSettings = this.settings;
            
            let homeVm = new homeViewModel(this.settings.activePost !== null);
            ko.applyBindings(homeVm, this.settings.body);
            
            //this.bindUIActions();
        },

        bindPosts: function () {

        }

    };

var homeViewModel = function(hasActivePost) {
    var self = this;
    self.posts = ko.observableArray([]);
    self.postsPreview = ko.observableArray([]);
    self.categories = ko.observableArray([]);
    self.latestPosts = ko.observableArray([]);
    self.activeCategoryPosts = ko.observableArray([]);
    self.activePost = ko.observable('');

    if (Blogger !== null) {
        Blogger.getBlogPosts().then(function () {
            let posts = Blogger.settings.posts;
            self.posts(posts || []);
            self.postsPreview(self.posts.slice(0, 3));
            self.categories(getPostCategories(posts || []));
            self.latestPosts(self.posts.slice(0, 5));
            self.activeCategoryPosts(filterPostsByCategory(posts));
            if (hasActivePost) {
                let activePost = getActivePost(posts);
                self.activePost(activePost);
                return activePost;
            }
            Navigation.settings.spinner.hidden = true;
            return self;
        }).catch(function () {
            console.log('Error loading blog.');
            Navigation.settings.spinner.hidden = true;
            ko.renderTemplate('no-data-template', self, null, Home.settings.homeWrapper, 'replaceChildren');
            return;
        }.bind(this));
    }
    
};

(function () {
    Home.init();
})();