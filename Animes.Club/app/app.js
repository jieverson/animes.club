window.App = angular
    .module('AnimesClub', ['ngResource', 'ngRoute', 'ui.bootstrap'])
    .config(['$routeProvider', '$locationProvider', function ($routeProvider, $locationProvider) {
        //Root
        $routeProvider.when('/', { templateUrl: "/view/anime/trending", controller: "Trending" });

        //Routes
        $routeProvider.when("/login", { templateUrl: "/view/login/index", controller: "Login" });
        $routeProvider.when("/register", { templateUrl: "/view/login/register", controller: "Register" });
        $routeProvider.when("/trending", { templateUrl: "/view/anime/trending", controller: "Trending" });
        $routeProvider.when("/watching", { templateUrl: "/view/anime/list", controller: "MyLists", status: 1 });
        $routeProvider.when("/completed", { templateUrl: "/view/anime/list", controller: "MyLists", status: 2 });
        $routeProvider.when("/todo", { templateUrl: "/view/anime/list", controller: "MyLists", status: 3 });
        $routeProvider.when("/dropped", { templateUrl: "/view/anime/list", controller: "MyLists", status: 4 });
        $routeProvider.when("/anime/:id/:name", { templateUrl: "/view/anime/profile", controller: "Anime" });
        $routeProvider.when("/user/:username", { templateUrl: "/view/user/profile", controller: "User" });
        $routeProvider.when("/people", { templateUrl: "/view/user/list", controller: "People" });
        $routeProvider.when("/terms", { templateUrl: "/view/login/terms" });

        //Handle
        //$routeProvider.otherwise({
        //    redirectTo: '/'
        //});

        // Specify HTML5 mode (using the History APIs) or HashBang syntax.
        $locationProvider.html5Mode(true);
    }]);