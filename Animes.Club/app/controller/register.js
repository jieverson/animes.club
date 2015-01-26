App.controller('Register', ['$scope', '$rootScope', '$http', '$routeParams', '$location', 'AuthService', function ($scope, $rootScope, $http, $routeParams, $location, AuthService) {
    $scope.username = null;
    $scope.email = null;
    $scope.password = null;
    $scope.agree = false;

    $scope.register = function (a, b, c) {
        if (grecaptcha.getResponse()) {
            AuthService
            .register($scope.username, $scope.email, $scope.password, grecaptcha.getResponse())
            .then(function (user) {
                $rootScope.$broadcast(AUTH_EVENTS.loginSuccess);
                $scope.setCurrentUser(user);
                alertify.success("Welcome " + user.username + "!");
                $location.path("/");
            }, function () {
                alertify.error("Username taken or email already registered.");
                $rootScope.$broadcast(AUTH_EVENTS.loginFailed);
            });
        }
        else {
            alertify.error("Are you sure you are not a robot?");
        }
    };
}]);