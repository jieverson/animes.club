App.controller('Search', ['$scope', function($scope) {
	var animes = new Bloodhound({
	    datumTokenizer: Bloodhound.tokenizers.obj.whitespace('value'),
	    queryTokenizer: Bloodhound.tokenizers.whitespace,
	    remote: '/api/anime?q=%QUERY'
	});

    animes.initialize();

    $('#search-animes').typeahead({
        hint: true,
        highlight: true,
        minLength: 1
    },
    {
        name: 'animes',
        displayKey: 'value',
        source: animes.ttAdapter(),
        templates: {
            empty: [
              '<div class="empty-message">',
              'unable to find any Best Picture winners that match the current query',
              '</div>'
            ].join('\n'),
            suggestion: Handlebars.compile([
                '<a href="/anime/999/{{value}}">' +
                    '<ul style="list-style-type: none;">' +
                        '<li style="display: inline;">' +
                            '<img src="{{picture}}" class="img-circle" style="width:50px;height:50px;"/>' +
                        '</li>' +
                        '<li style="display: inline;">' +
                            '{{name}}' +
                        '</li>' +
                    '</ul>' +
                '</a>'
            ].join('\n'))
        }
    });
}]);