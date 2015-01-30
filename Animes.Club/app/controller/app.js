App.controller('App', ['$scope', 'AuthService', function ($scope, AuthService) {
    $scope.currentUser = null;

    $scope.setCurrentUser = function (user) {
        $scope.currentUser = user;
    };

    AuthService
        .checkAuthenticate()
        .then(function (user) {
            $scope.setCurrentUser(user);
        });
}]);