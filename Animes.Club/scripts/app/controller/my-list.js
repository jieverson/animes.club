App.controller('MyLists', ['$scope', 'AnimeService', function ($scope, AnimeService) {
    $scope.watching = AnimeService.all();
}]);