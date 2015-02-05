App.controller('Trending', ['$scope', '$http', function ($scope, $http) {    
    $http.get('/api/trending')
      .success(function (data, status, headers, config) {
          $scope.list = data;
      })
      .error(function (data, status, headers, config) {
      });
}]);