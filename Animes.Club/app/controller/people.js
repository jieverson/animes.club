App.controller('People', ['$scope', '$http', function ($scope, $http) {
    $http.get('/api/people')
      .success(function (data, status, headers, config) {
          $scope.list = data;
      })
     .error(function (data, status, headers, config) {
     });

}]);