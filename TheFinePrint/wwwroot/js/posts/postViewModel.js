var postViewModel = {
    title: ko.observable(),
    subTitle: ko.observable(),
    imageUrl: ko.observable(),
    postUrl: ko.observable(),
    publishedDate: ko.observable(),
    categoryString: ko.observable(),
    categoryUrl: ko.observable(),
    category: ko.observable(),
    contentPreview: ko.observable(),
    content: ko.observable(),

    set: function (data) {
        if (data == null) {
            this.title("");
            this.subTitle("");
            this.imageUrl("");
            this.postUrl("");
            this.publishedDate("");
            this.categoryString("");
            this.categoryUrl("");
            this.category("");
            this.contentPreview("");
            this.content("");
        } else {
            this.title(data.title);
            this.subTitle(data.subTitle);
            this.imageUrl(data.imageUrl || '~/images/blog-1.jpg');
            this.postUrl(data.postUrl);
            this.publishedDate(data.publishedDate);
            this.categoryString(data.labels.join(','));
            this.categoryUrl(data.categoryUrl);
            this.category(data.category);
            this.contentPreview(data.content);
            this.content(data.content);
        }
    }
};

(function () {
    
})();