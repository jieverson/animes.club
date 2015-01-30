App.controller('MyLists', ['$scope', '$http', '$route', function ($scope, $http, $route) {
    var status = $route.current.status;

    $http.get('/api/animelist?status=' + status).
      success(function (data, status, headers, config) {
          $scope.list = data;
      });

    var title;
    switch (status) {
        case 1:
            title = "Current Watching";
            break;
        case 2:
            title = "Completed";
            break;
        case 3:
            title = "Plan to Watch";
            break;
        case 4:
            title = "Dropped";
            break;
    }
    
    $scope.title = title;
}]);