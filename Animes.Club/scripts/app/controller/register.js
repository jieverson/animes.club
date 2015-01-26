App.controller('Register', ['$scope', '$rootScope', '$http', '$routeParams', '$location', 'AuthService', function ($scope, $rootScope, $http, $routeParams, $location, AuthService) {
    $scope.username = null;
    $scope.email = null;
    $scope.confirmEmail = null;
    $scope.password = null;

    $scope.register = function () {
        debugger;
        if ($scope.email == $scope.confirmEmail) {
            AuthService
                .register($scope.username, $scope.email, $scope.password)
                .then(function (user) {
                    $rootScope.$broadcast(AUTH_EVENTS.loginSuccess);
                    $scope.setCurrentUser(user);
                    $location.path("/");
                }, function () {
                    $rootScope.$broadcast(AUTH_EVENTS.loginFailed);
                });
        }
    };
}]);