App.factory("AnimeService", function () {
    var me = this;

    var animes = [
        { id: 1, name: 'Fairy Tail', picture: 'http://cdn.myanimelist.net/images/anime/6/68563.jpg' },
        { id: 2, name: 'Death note', picture: 'http://cdn.myanimelist.net/images/anime/6/68563.jpg' },
        { id: 3, name: 'Log Horizon', picture: 'http://cdn.myanimelist.net/images/anime/6/68563.jpg' },
    ];

    return {
        all: function () {
            return animes;
        }
    };
});