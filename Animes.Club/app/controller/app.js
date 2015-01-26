App.controller('App', ['$scope', '$rootScope', '$location', 'AuthService', function ($scope, $rootScope, $location, AuthService) {
    $scope.currentUser = null;

    $scope.setCurrentUser = function (user) {
        $scope.currentUser = user;
    };

    AuthService
        .checkAuthenticate()
        .then(function (user) {
            $rootScope.$broadcast(AUTH_EVENTS.loginSuccess);
            $scope.setCurrentUser(user);
            $location.path("/watching");
        }, function () {
            $rootScope.$broadcast(AUTH_EVENTS.sessionTimeout);
        });
}]);