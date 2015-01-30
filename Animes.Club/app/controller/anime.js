App.controller('Anime', ['$scope', '$http', '$routeParams', function ($scope, $http, $routeParams) {
    $scope.id = $routeParams.id;
    $scope.anime = null;
    
    $scope.save = function () {
        return $http
          .post('/api/animelist', { id: $scope.id, status: $scope.anime.status, rating: $scope.anime.rating })
          .then(function (result) {
              alertify.success("Saved");
          });
    };

    $http.get('/api/anime/' + $routeParams.id).
      success(function (data, status, headers, config) {
          $scope.anime = data;
      }).
      error(function(data, status, headers, config) {
          // called asynchronously if an error occurs
          // or server returns response with an error status.
      });
}]);