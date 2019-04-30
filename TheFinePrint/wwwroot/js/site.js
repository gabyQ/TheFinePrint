var navigationSettings,
    Navigation = {

        settings: {
            // Sticky Header
            header: document.getElementById('header'),
            stickyWrapper: document.getElementById('sticky-wrapper'),
            sticky: document.getElementById('sticky-wrapper').offsetTop,
            // Sidebar hamburger button in header
            sideNavButton: document.getElementById('side-nav-button'),
            // Sidebar
            sidebar: document.getElementById('side-bar'),
            // Button to close the navigation side bar
            closeSideNavButton: document.getElementById('close-nav-button'),
            spinner: document.getElementById('preloader-background')
        },

        init: function () {
            navigationSettings = this.settings;
            this.bindUIActions();
        },

        bindUIActions: function () {
            window.onscroll = function () { Navigation.onScroll() };
            //navigationSettings.sideNavButton.onclick = function () {
            //    Navigation.openNav();
            //};
            //navigationSettings.closeSideNavButton.onclick = function () {
            //    Navigation.closeNav();
            //};
        },

        goToPage: function (pageName) {
            window.location.href = pageName;
        },

        onScroll: function () {
            if (window.pageYOffset > Navigation.settings.sticky) {
                Navigation.settings.stickyWrapper.classList.add('sticky');
            } else {
                Navigation.settings.stickyWrapper.classList.remove('sticky');
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