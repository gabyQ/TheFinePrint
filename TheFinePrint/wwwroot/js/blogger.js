var bloggerSettings,
    Blogger = {

        blog: null,
        settings: {
            posts: null,
            activePost: null
        },

        init: function () {
            // Get the blog to get the associated posts
            return this.getBlog();
        },

        getBlog: function () {
            return new Promise(function (resolve, reject) {
                ajaxGet('GetBlog')
                    .then(function (result) {
                        this.blog = result;
                        resolve();
                    }.bind(this))
                    .catch(function () {
                        // An error occurred
                    });
            });
        }, 

        getBlogPosts: function () {
            if (this.settings.posts == null) {
                return ajaxGet('GetPosts')
                    .then(function (result) {
                        this.settings.posts = JSON.parse(result);
                    }.bind(this))
                    .catch(function () {
                        // An error occurred
                    });
            } else {
                return this.settings.posts;
            }
        },

        getPostById: function (id) {
            return ajaxGet('GetPostById/' + id)
                .then(function (result) {
                    this.settings.activePost = JSON.parse(result);
                }.bind(this))
                .catch(function () {
                    // An error occurred
                });
        }

    };


(function () {
    Blogger.init();
})();