App.controller('Anime', ['$scope', '$http', '$routeParams', function ($scope, $http, $routeParams) {
    $scope.id = $routeParams.id;
    
    $http.get('/api/search/' + $routeParams.id).
      success(function (data, status, headers, config) {
          $scope.anime = data;
      }).
      error(function(data, status, headers, config) {
          // called asynchronously if an error occurs
          // or server returns response with an error status.
      });
}]);