var app = angular.module('ltfApp', []);

app.controller('LoginCtrl', function ($scope) {

    $scope.name = "Koushik";


});
app.controller('ClubCtrl', function ($scope, $http) {
    $scope.clubslist = [];
    $http({
        method: 'GET',
        url: 'http://localhost:56507/api/Club/GetClub'
    }).success(function (result) {
        console.log(result);
        $scope.clubslist = result;
    });
});


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