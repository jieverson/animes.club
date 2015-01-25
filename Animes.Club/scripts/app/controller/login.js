App.controller('Login', ['$scope', '$rootScope', '$http', '$routeParams', '$location', 'AuthService', function ($scope, $rootScope, $http, $routeParams, $location, AuthService) {

    $scope.email = "contact@jieverson.com";
    $scope.password = "info3000";
    $scope.remember = true;

    $scope.login = function () {
        AuthService
            .login($scope.email, $scope.password, $scope.remember)
            .then(function (user) {
                $rootScope.$broadcast(AUTH_EVENTS.loginSuccess);
                $scope.setCurrentUser(user);
                $location.path("/watching");
            }, function () {
                $rootScope.$broadcast(AUTH_EVENTS.loginFailed);
            });
    };
}]);