﻿window.App = angular
    .module('AnimesClub', ['ngResource', 'ngRoute'])
    .config(['$routeProvider', '$locationProvider', function ($routeProvider, $locationProvider) {
        //Root
        $routeProvider.when('/', {
            templateUrl: '/view/lists/watching',
            //controller: 'homeCtrl',
        });

        $routeProvider.when("/watching", { templateUrl: "/view/lists/watching" })
        $routeProvider.when("/completed", { templateUrl: "/view/lists/completed" })
        $routeProvider.when("/todo", { templateUrl: "/view/lists/todo" })
        $routeProvider.when("/dropped", { templateUrl: "/view/lists/dropped" })

        //Handle
        //$routeProvider.otherwise({
        //    redirectTo: '/'
        //});

        // Specify HTML5 mode (using the History APIs) or HashBang syntax.
        $locationProvider.html5Mode(true);
    }]);