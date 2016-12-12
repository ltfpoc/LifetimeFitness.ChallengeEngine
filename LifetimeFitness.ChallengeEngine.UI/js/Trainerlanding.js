var app = angular.module('ltfAppTrainer', []);

app.controller('myenroll', function ($scope, $http) {
    $scope.eCategorylist = [];
    $scope.eChallengelist = [];
    $scope.eUserlist = [];
    $scope.eClublist = [];


    $http.get("http://localhost:56507/api/Club/GetClub").then(function (responses) {
        console.log(responses);
        $scope.eClublist = responses.data;
        $scope.myClubValue = $scope.eClublist;
    });
    $http.get("http://localhost:56507/api/Category/GetCategory").then(function (responses) {
        console.log(responses);
        $scope.eCategorylist = responses.data;
        $scope.myCategoryValue = $scope.eCategorylist;
    });
    $http.get("http://localhost:56507/api/Challenge/GetChallenges").then(function (responses) {
        console.log(responses);
        $scope.eChallengelist = responses.data;
        $scope.myChallengeValue = $scope.eChallengelist;
    });
    $http.get("http://localhost:56507/api/User/GetUsers").then(function (responses) {
        console.log(responses);
        $scope.eUserlist = responses.data;
        $scope.myUserValue = $scope.eUserlist[0];
    });
    //$scope.getCategory = function (myCategoryValue) {
    //    console.log(myCategoryValue);
    //    console.log(myeCategoryValue);
    //    $scope.myeCategoryValue = myCategoryValue;
    //};
    //$scope.getChallenge = function (myChallengeValue) {
    //    console.log(myCategoryValue);
    //    console.log(myeChallengeValue);
    //    $scope.myeChallengeValue = myChallengeValue;
    //};
    $scope.enrollUser = function (myCategoryValue, myChallengeValue, myUserValue) {
        //var data = {
        //    category: myCategoryValue,
        //    Challenge: myChallengeValue,
        //    User: myUserValue
        //};
        var data = {
            UserId : myUserValue,
            ChallengeId :myChallengeValue  
        };
        console.log(data);
        //var config = {
        //    headers: {
        //        'Content-Type': 'application/json;charset=utf-8;'
        //    }
        //};
        //$http.post('http://localhost:56507/api/Enrollment/PostEnrollment', JSON.stringify(data), config).then(function (response) {
        $http.post('http://localhost:56507/api/Enrollment/PostEnrollment', data).then(function (response) {
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
