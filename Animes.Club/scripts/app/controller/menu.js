App.controller('Menu', ['$scope', '$location', function ($scope, $location) {
    $scope.items = [
		{ text: 'Home', url: '/', icon: 'fa-home', selected: function () { $location.path() == this.url } },
		{ text: 'Trending', url: '/trending', icon: 'fa-comments', selected: function () { $location.path() == this.url } },
		{ text: 'Recomendations', url: '/recomendations', icon: 'fa-heart', selected: function () { $location.path() == this.url } },
		{ text: 'New Releases', url: '/news', icon: 'fa-newspaper-o', badge: 3, selected: function () { $location.path() == this.url } },
		{ text: 'Current Season', url: '/airing', icon: 'fa-desktop', hint: 'Airing', selected: function () { $location.path() == this.url } },
		{ text: 'People', url: '/people', icon: 'fa-group', selected: function () { $location.path() == this.url } },
		{ group: 'MY LIST' },
	    { text: 'Currently Watching', url: '/watching', icon: 'fa-eye', selected: function () { debugger; $location.path() == this.url } },
        { text: 'Completed', url: '/completed', icon: 'fa-check', selected: function () { $location.path() == this.url } },
        { text: 'Plan to Watch', url: '/todo', icon: 'fa-calendar', selected: function () { $location.path() == this.url } },
        { text: 'Dropped', url: '/dropped', icon: 'fa-trash', selected: function () { $location.path() == this.url } }
    ];
}]);