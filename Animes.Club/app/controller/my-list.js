App.controller('MyLists', ['$scope', '$http', '$route', 'AnimeService', function ($scope, $http, $route, AnimeService) {
    $http.get('/api/animelist?status=' + $route.current.status).
      success(function (data, status, headers, config) {
          $scope.watching = data;
      }).
      error(function (data, status, headers, config) {
          // called asynchronously if an error occurs
          // or server returns response with an error status.
      });

    //$scope.watching = AnimeService.all();
}]);