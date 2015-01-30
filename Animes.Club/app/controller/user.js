App.controller('User', ['$scope', '$routeParams', function ($scope, $routeParams) {
    $scope.username = $routeParams.username;

    $http.get('/api/anime/' + $scope.username).
      success(function (data, status, headers, config) {
          $scope.user = data;
      }).
      error(function (data, status, headers, config) {
          // called asynchronously if an error occurs
          // or server returns response with an error status.
      });
}]);