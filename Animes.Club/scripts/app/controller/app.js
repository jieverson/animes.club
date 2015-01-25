App.controller('App', ['$scope', '$rootScope', 'AuthService', function ($scope, $rootScope, AuthService) {
    $scope.currentUser = null;

    $scope.setCurrentUser = function (user) {
        $scope.currentUser = user;
    };

    AuthService
        .checkAuthenticate()
        .then(function (user) {
            $rootScope.$broadcast(AUTH_EVENTS.loginSuccess);
            $scope.setCurrentUser(user);
        }, function () {
            $rootScope.$broadcast(AUTH_EVENTS.sessionTimeout);
        });
}]);