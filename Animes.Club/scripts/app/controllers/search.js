App.controller('Search', ['$scope', function($scope) {
    states = [ 'Alabama', 'Alaska', 'Arizona', 'Arkansas', 'California',
	  'Colorado', 'Connecticut', 'Delaware', 'Florida', 'Georgia', 'Hawaii',
	  'Idaho', 'Illinois', 'Indiana', 'Iowa', 'Kansas', 'Kentucky', 'Louisiana',
	  'Maine', 'Maryland', 'Massachusetts', 'Michigan', 'Minnesota',
	  'Mississippi', 'Missouri', 'Montana', 'Nebraska', 'Nevada', 'New Hampshire',
	  'New Jersey', 'New Mexico', 'New York', 'North Carolina', 'North Dakota',
	  'Ohio', 'Oklahoma', 'Oregon', 'Pennsylvania', 'Rhode Island',
	  'South Carolina', 'South Dakota', 'Tennessee', 'Texas', 'Utah', 'Vermont',
	  'Virginia', 'Washington', 'West Virginia', 'Wisconsin', 'Wyoming'];

	states = new Bloodhound({
	    datumTokenizer: Bloodhound.tokenizers.obj.whitespace('value'),
	    queryTokenizer: Bloodhound.tokenizers.whitespace,
	    local: $.map(states, function(state) { return { value: state, picture: 'http://cdn.myanimelist.net/images/anime/13/60471.jpg' } } )
	});
 
    states.initialize();
 
    $('#search-animes').typeahead({
        hint: true,
        highlight: true,
        minLength: 1
    },
    {
        name: 'states',
        displayKey: 'value',
        source: states.ttAdapter(),
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
                            '{{value}}' +
                        '</li>' +
                    '</ul>' +
                '</a>'
            ].join('\n'))
        }
    });
}]);