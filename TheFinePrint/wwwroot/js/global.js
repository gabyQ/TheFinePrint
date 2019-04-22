
function ajaxGet(url) {
    return new Promise(function (resolve, reject) {
        var xhr = new XMLHttpRequest();
        xhr.onload = function () {
            resolve(this.responseText);
        };
        xhr.onerror = reject;
        xhr.open('GET', '/api/BlogApi/' + url);
        xhr.send();
    });
}


function ajaxPost() {

}

function getPostCategories(posts) {
    if (posts == null) {
        return [];
    }

    // Get all categories from all posts
    let allCategories = posts.map(p => p.labels);
    // Get the distinct categories
    return Array.from(new Set(allCategories));
}