App.controller('User', ['$scope', '$routeParams', function ($scope, $routeParams) {
    $scope.username = $routeParams.username;
}]);