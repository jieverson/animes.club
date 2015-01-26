App.controller('Login', ['$scope', '$rootScope', '$http', '$routeParams', '$location', 'AuthService', function ($scope, $rootScope, $http, $routeParams, $location, AuthService) {
    $scope.username = null;
    $scope.password = null;
    $scope.remember = true;

    $scope.login = function () {
        AuthService
            .login($scope.username, $scope.password, $scope.remember)
            .then(function (user) {
                $rootScope.$broadcast(AUTH_EVENTS.loginSuccess);
                $scope.setCurrentUser(user);
                alertify.success("Hello " + user.username + "!");
                $location.path("/watching");
            }, function () {
                alertify.error("Username and password does not match.");
                $rootScope.$broadcast(AUTH_EVENTS.loginFailed);
            });
    };

    $scope.logout = function () {        
        AuthService
            .logout()
            .then(function (user) {
                $rootScope.$broadcast(AUTH_EVENTS.logoutSuccess);
                $scope.setCurrentUser(null);
                alertify.success("See you later!");
                $location.path("/");
            }, function () {
                //$rootScope.$broadcast(AUTH_EVENTS.logoutFailed);
            });
    };
}]);