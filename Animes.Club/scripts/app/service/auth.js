App.factory("AuthService", function ($http, Session) {
    var authService = {};

    authService.login = function (email, password, remember) {
        return $http
          .post('/api/login', { email: email, password: password, remember: remember })
          .then(function (result) {
              Session.create(result.data.sessionId, result.data.user.id);
              return result.data.user;
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
});