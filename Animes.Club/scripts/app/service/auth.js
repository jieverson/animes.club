App.factory("AuthService", ["$http", "Session", function ($http, Session) {
    var authService = {};

    authService.register = function (username, email, password) {
        return $http
          .post('/api/register', { username: username, email: email, password: password })
          .then(function (result) {
              if (result.data) {
                  Session.create(result.data.sessionId, result.data.user.id);
                  return result.data.user;
              }
              else {
                  return null;
              }
          });
    };

    authService.login = function (email, password, remember) {
        return $http
          .post('/api/login', { email: email, password: password, remember: remember })
          .then(function (result) {
              if (result.data) {
                  Session.create(result.data.sessionId, result.data.user.id);
                  return result.data.user;
              }
              else {
                  return null;
              }
          });
    };

    authService.logout = function (email, password, remember) {
        return $http
          .delete('/api/login')
          .then(function (result) {
              Session.destroy();
              return null;
          });
    };

    authService.checkAuthenticate = function () {
        return $http
          .get('/api/login')
          .then(function (result) {
              if (result.data) {
                  Session.create(result.data.sessionId, result.data.user.id);
                  return result.data.user;
              }
              else {
                  return null;
              }
          });
    };

    authService.isAuthenticated = function () {
        return !!Session.userId;
    };

    authService.isAuthorized = function (authorizedRoles) {
        if (!angular.isArray(authorizedRoles)) {
            authorizedRoles = [authorizedRoles];
        }
        return (authService.isAuthenticated() &&
          authorizedRoles.indexOf(Session.userRole) !== -1);
    };

    return authService;
}]);