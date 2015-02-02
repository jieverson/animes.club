App.factory("AuthService", ["$http", function ($http) {
    var authService = {};

    authService.register = function (username, email, password, captchaResponse) {
        return $http
          .post('/api/register', { username: username, email: email, password: password, captchaResponse: captchaResponse })
          .then(function (result) {
              if (result.data) {
                  return result.data;
              }
              else {
                  return null;
              }
          });
    };

    authService.login = function (username, password, remember) {
        return $http
          .post('/api/login', { username: username, password: password, remember: remember })
          .then(function (result) {
              if (result.data) {
                  return result.data;
              }
              else {
                  return null;
              }
          });
    };

    authService.logout = function (email, password, remember) {
        return $http
          .delete('/api/login');
    };

    authService.checkAuthenticate = function () {
        return $http
          .get('/api/login')
          .then(function (result) {
              if (result.data) {
                  return result.data;
              }
              else {
                  return null;
              }
          });
    };

    return authService;
}]);