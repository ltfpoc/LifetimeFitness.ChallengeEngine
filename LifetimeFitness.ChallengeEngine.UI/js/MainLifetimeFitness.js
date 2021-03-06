﻿var app = angular.module('ltfApp', ['ngRoute', 'LocalStorageModule']);



app.controller('ClubCtrl', function ($scope, $http, $location, $log, $window) {
    $scope.clubslist = [];
    $http({
        method: 'GET',
        url: 'http://localhost:56507/api/Club/GetClub'
    }).success(function (result) {
        $scope.clubslist = result;
    });
    $scope.shareClub = function (myClubValue) {
        var url = "http://" + $window.location.host + "/landingpage1.html";
        if ($window.localStorage.getItem("clubname") === null) {
            $window.localStorage.setItem("clubname", myClubValue);
        }
        else {
            $window.localStorage.removeItem("clubname");
            $window.localStorage.setItem("clubname", myClubValue);
        }
        $window.location.href = url;
    };
});



app.run(['authService', function (authService) {
    authService.fillAuthData();
}]);


'use strict';
app.factory('authService', ['$http', '$q', 'localStorageService', function ($http, $q, localStorageService) {

    var serviceBase = 'http://localhost:56507/';
    var authServiceFactory = {};

    var _authentication = {
        isAuth: false,
        userName: ""
    };

    var _saveRegistration = function (registration) {

        _logOut();

        return $http.post(serviceBase + 'api/account/register', registration).then(function (response) {
            return response;
        });

    };

    var _login = function (loginData) {

        var data = "grant_type=password&username=" + loginData.userName + "&password=" + loginData.password;
        var deferred = $q.defer();

        $http.post(serviceBase + 'token', data, { headers: { 'Content-Type': 'application/x-www-form-urlencoded' } }).success(function (response) {

            localStorageService.set('authorizationData', { token: response.access_token, userName: loginData.userName });

            _authentication.isAuth = true;
            _authentication.userName = loginData.userName;

            deferred.resolve(response);

        }).error(function (err, status) {
            _logOut();
            deferred.reject(err);
        });

        return deferred.promise;

    };

    var _logOut = function () {

        localStorageService.remove('authorizationData');

        _authentication.isAuth = false;
        _authentication.userName = "";

    };

    var _fillAuthData = function () {

        var authData = localStorageService.get('authorizationData');
        if (authData) {
            _authentication.isAuth = true;
            _authentication.userName = authData.userName;
        }

    }

    authServiceFactory.saveRegistration = _saveRegistration;
    authServiceFactory.login = _login;
    authServiceFactory.logOut = _logOut;
    authServiceFactory.fillAuthData = _fillAuthData;
    authServiceFactory.authentication = _authentication;

    return authServiceFactory;
}]);


'use strict';
app.controller('LoginCtrl', ['$scope', '$location', 'authService','$window', function ($scope, $location, authService,$window) {

    $scope.loginData = {
        userName: "",
        password: ""
    };

    $scope.message = "";

    $scope.login = function () {
        authService.login($scope.loginData).then(function (response) {

            if (response.userRole === "Admin" || response.userRole === "Participant") {
                $("#login").hide();
                $("#Choose_club").hide();
                $("#Choose_admin").show();
            }
            else { 
                $("#login").hide();
                $("#Choose_admin").hide();
                $("#Choose_club").show();
            }
            

        },
         function (err) {
             //$scope.message = err.error_description;
         });
    };

    $scope.LoadLoginScreen = function()
    {
        authService.logOut();
        var url = "http://" + $window.location.host + "/index.html";
        $window.location.href = url;
    }
}]);



'use strict';
app.factory('authInterceptorService', ['$q', '$location', 'localStorageService', function ($q, $location, localStorageService) {

    var authInterceptorServiceFactory = {};

    var _request = function (config) {

        config.headers = config.headers || {};

        var authData = localStorageService.get('authorizationData');
        if (authData) {
            config.headers.Authorization = 'Bearer ' + authData.token;
        }

        return config;
    }

    var _responseError = function (rejection) {
        if (rejection.status === 401) {
            $location.path('/login');
        }
        return $q.reject(rejection);
    }

    authInterceptorServiceFactory.request = _request;
    authInterceptorServiceFactory.responseError = _responseError;

    return authInterceptorServiceFactory;
}]);

app.config(function ($httpProvider) {
    $httpProvider.interceptors.push('authInterceptorService');
});


