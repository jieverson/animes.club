App.factory("AnimeService", function () {
    var me = this;

    var animes = [
        { id: 70491, name: 'Fairy Tail', picture: 'http://cdn.myanimelist.net/images/anime/5/18179.jpg' },
        { id: 69117, name: 'Death note', picture: 'http://cdn.myanimelist.net/images/anime/9/9453.jpg' },
        { id: 72788, name: 'Log Horizon', picture: 'http://cdn.myanimelist.net/images/anime/6/60613.jpg' },
    ];

    return {
        all: function () {
            return animes;
        }
    };
});