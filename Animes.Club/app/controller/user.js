App.controller('User', ['$scope', '$http', '$routeParams', function ($scope, $http, $routeParams) {
    $http.get('/api/user/' + $routeParams.username).
      success(function (data, status, headers, config) {
          $scope.user = data;
      }).
      error(function (data, status, headers, config) {
          // called asynchronously if an error occurs
          // or server returns response with an error status.
      });
}]);