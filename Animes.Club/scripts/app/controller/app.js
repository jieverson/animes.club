App.controller('App', ['$scope', function ($scope) {
    $scope.currentUser = null;

    $scope.setCurrentUser = function (user) {
        $scope.currentUser = user;
    };
}]);