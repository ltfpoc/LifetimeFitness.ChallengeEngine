var app = angular.module('ltfAppTrainer', []);

app.controller('CategoryCtrl', function ($scope, $http) {
    $scope.Categorylist = [];
    $http({
        method: 'GET',
        url: 'http://localhost:56507/api/Category/GetCategory'
    }).success(function (result) {
        console.log(result);
        $scope.Categorylist = result;
    });
});

app.controller('ChallengeCtrl', function ($scope, $http) {
    $scope.Challengelist = [];
    $http({
        method: 'GET',
        url: 'http://localhost:56507/api/Challenge/GetChallenges'
    }).success(function (result) {
        console.log(result);
        $scope.Challengelist = result;
    });
});

app.controller('myenroll', function ($scope, $http) {
    $scope.eCategorylist = [];
    $scope.eChallengelist = [];
    $scope.eUserlist = [];
    $http.get("http://localhost:56507/api/Category/GetCategory").then(function (responses) {
        console.log(responses);
        $scope.eCategorylist = responses.data;
        $scope.myCategoryValue = $scope.eCategorylist[0];
    });
    $http.get("http://localhost:56507/api/Challenge/GetChallenges").then(function (responses) {
        console.log(responses);
        $scope.eChallengelist = responses.data;
        $scope.myChallengeValue = $scope.eChallengelist[0];
    });
    $http.get("http://localhost:56507/api/User/GetUsers").then(function (responses) {
        console.log(responses);
        $scope.eUserlist = responses.data;
        $scope.myUserValue = $scope.eUserlist[0];
    });
    $scope.enrollUser = function (myCategoryValue, myChallengeValue, myUserValue) {
        var data = {
            category: myCategoryValue,
            Challenge: myChallengeValue,
            User: myUserValue
        };
        console.log(data);
        var config = {
            headers: {
                'Content-Type': 'application/json;charset=utf-8;'
            }
        };
        $http.post('http://localhost:56507/api/Enrollment/PostEnrollment', JSON.stringify(data), config).then(function (response) {
            if (response.data)
                $scope.msg = "Post Data Submitted Successfully!";
        }, function (response) {
            $scope.msg = "Service not Exists";
            $scope.statusval = response.status;
            $scope.statustext = response.statusText;
            $scope.headers = response.headers();
        });
    };
});

//app.controller('UserCtrl', function ($scope, $http) {
//    $scope.Userlist = [];
//    $http({
//        method: 'GET',
//        url: 'http://localhost:56507/api/User/GetUsers'
//    }).success(function (result) {
//        console.log(result);
//        $scope.Userlist = result;
//    });
//    var data = { UName: $scopeuserValue ,CName:$scope.    }
//    $scope.enrollUser = function () {
//        $http({
//            method: 'POST',
//            url: 'http://localhost:56507/api/Enrollment/PostEnrollment',

//        });
//    };
//});





//app.controller('ClubCtrl', function ($scope, $http) {
//    $scope.clubslist = [];
//    $http({
//        method: 'GET',
//        url: 'http://localhost:56507/api/Club/GetClub'
//    }).success(function (result) {
//        console.log(result);
//        $scope.clubslist = result;
//    });
//});
//app.controller("showCtrl", function ($scope, $location, myFactory) {
//    $scope.Students = [
//        { Name: "Akhilesh", Address: "Kolkata", Email: "xxxx@gmail.com" },
//        { Name: "Mukesh", Address: "Delhi", Email: "yyyy@gmail.com" },
//        { Name: "Rakesh", Address: "Mumbai", Email: "zzzz@gmail.com" },
//    ]

//    $scope.Edit = function (d) {
//        myFactory.set(d);
//        $location.path('/EditData');
//    }
//});

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