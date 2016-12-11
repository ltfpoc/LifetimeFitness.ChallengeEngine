var app = angular.module('ltfApp', ['ngRoute', 'LocalStorageModule']);

//app.controller('LoginCtrl', function ($scope, $http) {

//    $scope.name = "Koushik";

//    $scope.login = function (loginData) {
//        var serviceBase = 'http://localhost:56507/'
//        //var data = JSON.stringify( "grant_type=password&username=" + loginData.userName + "&password=" + loginData.password);
//        var data = "grant_type=password&username=" + loginData.userName + "&password=" + loginData.password;

//        //, 'Access-Control-Allow-Origin': '*' 
//        $http.post(serviceBase + 'token', data, { headers: { 'Content-Type': 'application/x-www-form-urlencoded', 'Access-Control-Allow-Origin': '*' } }).success(function (response) {

//            alert(response.data);
//            //localStorageService.set('authorizationData', { token: response.access_token, userName: loginData.userName });

//            //_authentication.isAuth = true;
//            //_authentication.userName = loginData.userName;

//            $("#login").hide();
//            $("#Choose_club").show();

//        }).error(function (err, status) {
//            //_logOut();
//            alert(err);
//        });
       
//    };


//});



app.controller('ClubCtrl', function ($scope, $http,  $location, $window) {
    $scope.clubslist = [];
    $http({
        method: 'GET',
        url: 'http://localhost:56507/api/Club/GetClub'
    }).success(function (result) {
        console.log(result);
        $scope.clubslist = result;
    });

    $scope.go = function (path) {
        $window.location.href = '/landingpage1.html';
    };
    
});
   
//app.controller("showCtrl", function ($scope, $window) {
//    console.log($scope.myClubValue);
//    $scope.shareClub = function () {
//        var $popup = $window.open("landingpage1.html", "landingpage1", "width=100%,height=100%");
//        $popup.myClubValue = $scope.myClubValue;
//    }
//});


app.controller('CategoryCtrl', function ($scope, $http) {
    $scope.clubslist = [];
    $http({
        method: 'GET',
        url: 'http://localhost:56507/api/Category/GetCategory'
    }).success(function (result) {
        console.log(result);
        $scope.clubslist = result;
    });
});



app.controller('ChallengeCtrl', function ($scope, $http) {
    $scope.clubslist = [];
    $http({
        method: 'GET',
        url: 'http://localhost:56507/api/Challenge/GetChallenges'
    }).success(function (result) {
        console.log(result);
        $scope.clubslist = result;
    });
});


    //$http.get("http://localhost:56507/api/Club/GetClub").success(function (response) {
    //    var clubs = response.data;

    //    //$.map(data, function (clubs) {
    //    //    arrclubs.push(clubs.ClubName + "," + clubs.City);
    //    //});
    //    $scope.clubslist = arrclubs;
    //}).error(function (status) {
    //    alert(status);
    //});

//});


//var app = angular.module('AngularAuthApp', ['ngRoute', 'LocalStorageModule', 'angular-loading-bar']);

app.config(function ($routeProvider) {

    $routeProvider.when("/trainerLanding", {
        templateUrl: "http://localhost:59837/landingpage1.html"
    });

    //$routeProvider.when("/login", {
    //    controller: "loginController",
    //    templateUrl: "/app/views/login.html"
    //});

    //$routeProvider.when("/signup", {
    //    controller: "signupController",
    //    templateUrl: "/app/views/signup.html"
    //});

    //$routeProvider.when("/orders", {
    //    controller: "ordersController",
    //    templateUrl: "/app/views/orders.html"
    //});

    //$routeProvider.otherwise({ redirectTo: "/home" });
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

            console.log(response);
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
app.controller('LoginCtrl', ['$scope', '$location', 'authService', function ($scope, $location, authService) {
   
    $scope.loginData = {
        userName: "",
        password: ""
    };

    $scope.message = "";

    $scope.login = function () {
        alert('login');
        authService.login($scope.loginData).then(function (response) {

            //$location.path('/orders');
            $("#login").hide();
            $("#Choose_club").show();

        },
         function (err) {
             console.log(err);
             //$scope.message = err.error_description;
         });
    };

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


