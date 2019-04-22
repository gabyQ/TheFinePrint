
var navigationSettings,
    Navigation = {

        settings: {
            // Sticky Header
            header: document.getElementById('header'),
            sticky: this.header.offsetTop,
            // Sidebar hamburger button in header
            sideNavButton: document.getElementById('side-nav-button'),
            // Sidebar
            sidebar: document.getElementById('side-bar'),
            // Button to close the navigation side bar
            closeSideNavButton: document.getElementById('close-nav-button')
        },

        init: function () {
            navigationSettings = this.settings;
            this.bindUIActions();
        },

        bindUIActions: function () {
            window.onscroll = function () { Navigation.onScroll() };
            navigationSettings.sideNavButton.onclick = function () {
                Navigation.openNav();
            };
            navigationSettings.closeSideNavButton.onclick = function () {
                Navigation.closeNav();
            };
        },

        goToPage: function (pageName) {
            window.location.href = pageName;
        },

        onScroll: function () {
            if (window.pageYOffset > Navigation.settings.sticky) {
                Navigation.settings.header.classList.add('sticky');
            } else {
                Navigation.settings.header.classList.remove('sticky');
            }
        },

        openNav: function () {
            navigationSettings.sidebar.style.width = '250px';
        },

        closeNav: function () {
            navigationSettings.sidebar.style.width = '0';
        }
    };




(function () {
    Navigation.init();
})();