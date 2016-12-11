var app = angular.module('ltfApp', []);

app.controller('LoginCtrl', function ($scope, $http) {

    $scope.name = "Koushik";

    $scope.login = function (loginData) {
        var serviceBase = 'http://localhost:56507/'
        var data = JSON.stringify( "grant_type=password&username=" + loginData.userName + "&password=" + loginData.password);

        $http.post(serviceBase + 'token', data, { headers: { 'Content-Type': 'application/x-www-form-urlencoded', 'Access-Control-Allow-Origin': '*' } }).success(function (response) {

            alert(response.data);
            localStorageService.set('authorizationData', { token: response.access_token, userName: loginData.userName });

            _authentication.isAuth = true;
            _authentication.userName = loginData.userName;

            $("#login").hide();
            $("#Choose_club").show();

        }).error(function (err, status) {
            //_logOut();
        });
       
    };


});
app.controller('ClubCtrl', function ($scope, $http,$window) {
    $scope.clubslist = {};
    $http({
        method: 'GET',
        url: 'http://localhost:56507/api/Club/GetClub'
    }).success(function (result) {
        console.log(result);
        $scope.clubslist = result;
    });
    $scope.shareClub = function () {
        var $popup = $window.open("landingpage1.html", "landingpage1", "width=100%,height=100%");
                $popup.myClubValue = $scope.myClubValue;
    }
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


    //$scope.Students = [
    //    { Name: "Akhilesh", Address: "Kolkata", Email: "xxxx@gmail.com" },
    //    { Name: "Mukesh", Address: "Delhi", Email: "yyyy@gmail.com" },
    //    { Name: "Rakesh", Address: "Mumbai", Email: "zzzz@gmail.com" },
    //]

    //$scope.Edit = function (d) {
    //    myFactory.set(d);
    //    $location.path('/EditData');
    //}


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