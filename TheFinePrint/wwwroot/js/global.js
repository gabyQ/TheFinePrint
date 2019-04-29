
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
    let allCategories = posts.flatMap(p => p.labels).filter(l => l !== null);
    // Get the distinct categories
    return Array.from(new Set(allCategories));
}

function filterPostsByCategory(posts) {
    if (posts === null) {
        return [];
    }

    if (Home !== null && Home.settings.activeCategory !== null) {
        return posts.filter(function (p) {
            if (p.labels !== null && p.labels.includes(Home.settings.activeCategory)) {
                return p;
            }
        });
    }
    
    return [];
}

function getActivePost(posts) {
    let activePostId = Home && Home.settings && Home.settings.activePost;
    if (posts === null || activePostId === null) {
        return null;
    }
    return posts.find(function (p) {
        return p.id == activePostId;
    });
}

function navigateHome() {
    window.location.href = '/';
}

function navigateToCategory(clicked) {
    let category = clicked.innerHTML;
    window.location.href = '/Category/' + category;
}