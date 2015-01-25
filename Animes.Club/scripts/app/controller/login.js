App.controller('Login', ['$scope', '$http', '$routeParams', function ($scope, $http, $routeParams) {

    $scope.email = "";
    $scope.password = "";
    $scope.remember = true;

    $scope.login = function () {
        $http.post('/api/login', { email: $scope.email, password: $scope.password, remember: $scope.remember }).
          success(function (data, status, headers, config) {
              debugger;
          }).
          error(function (data, status, headers, config) {
              alert('erro');
              // called asynchronously if an error occurs
              // or server returns response with an error status.
          });
    };
}]);