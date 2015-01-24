App.controller('Search', ['$scope', function($scope) {
	var animes = new Bloodhound({
	    datumTokenizer: Bloodhound.tokenizers.obj.whitespace('value'),
	    queryTokenizer: Bloodhound.tokenizers.whitespace,
	    remote: '/api/search?q=%QUERY'
	});

    animes.initialize();

    $('#search-animes').typeahead({
        hint: true,
        highlight: true,
        minLength: 2
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
                '<a href="/anime/{{id}}/{{address}}">' +
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