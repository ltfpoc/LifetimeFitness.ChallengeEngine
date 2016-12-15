var app = angular.module('ltfAppTrainer', []);

app.controller('myenroll', function ($scope, $http, $rootScope, $window) {

    var baseUri = "http://localhost:56507/";

    $scope.eCategorylist = [];
    $scope.eChallengelist = [];
    $scope.eUserlist = [];
    $scope.eClublist = [];
    $scope.UserChalist = [];
    $scope.challengeClubRelationshipId = 0;
    $scope.myClubValue = 0;
    //if ($window.localStorage.getItem("clubname") === null) {
    //    $window.localStorage.setItem("clubname", myClubValue);
    //}
    //else {
    //    $window.localStorage.removeItem("clubname");
    //    $window.localStorage.setItem("clubname", myClubValue);
    //}

    $http.get(baseUri + "api/Club/GetClub").then(function (responses) {
        $scope.eClublist = responses.data;
        var getclub = $window.localStorage.getItem("clubname");
        $scope.myClubValue = getclub;
    });
    $http.get(baseUri + "api/Category/GetCategory").then(function (responses) {
        $scope.eCategorylist = responses.data;
        $scope.myCategoryValue = $scope.eCategorylist;
    });
    $scope.GetChallenges = function () {
        var myparam = "Category/" + $scope.myCategoryValue + '/Club/' + $scope.myClubValue;
        $http.get(baseUri + "api/Challenge/GetChallenges/" + myparam).then(function (responses) {
            $scope.eChallengelist = responses.data;
            $scope.myChallengeValue = $scope.eChallengelist;
        });
    }
    $scope.GetChallengesPopup = function () {
        var myparam = "Category/" + $scope.myeCategoryValue + '/Club/' + $scope.myClubValue;
        $http.get(baseUri + "api/Challenge/GetChallenges/" + myparam).then(function (responses) {
            $scope.eChallengelist = responses.data;
            $scope.myeChallengeValue = $scope.eChallengelist;
        });
    }
    $scope.GetSelectin = function () {
        $scope.myeCategoryValue = $scope.myCategoryValue;
        $scope.myeChallengeValue = $scope.myChallengeValue;
    }

    $http.get(baseUri + "api/User/GetUsers").then(function (responses) {

        $scope.eUserlist = responses.data;
        $scope.myUserValue = $scope.eUserlist[0];
    });
    $scope.GetUsersNotInChallenge = function () {
        
        if ($scope.myeChallengeValue != "" && $scope.myClubValue != "")
        {
            $http.get(baseUri + "api/User/GetUsers/Challenge/" + $scope.myeChallengeValue + "/Club/" + $scope.myClubValue).then(
            function (responses) {
                $scope.UserChalist = [];
                $scope.UserChalist = responses.data;
            });
        }
        else
        {
            $scope.UserChalist = [];
        }
    }
    $scope.selectedUserId = null;
    $scope.setSelectedUserId = function (idSelected) {
        $scope.selectedUserId = idSelected;
    }
    $scope.GetChallengeClubRelation = function () {
        $http.get(baseUri + "api/Challenge/GetChallengeClubRelationship/Club/" + $scope.myClubValue + "/Challenge/" + $scope.myeChallengeValue).then(function (responses) {
            $scope.challengeClubRelationshipId = responses.data.ChallengeClubRelationId;
        });
    }
    $scope.enrollUser = function (myCategoryValue, myChallengeValue, myClubValue) {
        var data = {
            UserId: $scope.selectedUserId.UserId,
            ChallengeId: $scope.myeChallengeValue,
            ClubId: myClubValue
        };

        $http.post('http://localhost:56507/api/Enrollment/PostEnrollment', data).then(function (response) {
            if (response.data) {
                alert('User enrollment for challenge is successfull');
                $scope.GetUsersNotInChallenge();
            }
        }, function (response) {
            $scope.msg = "Service not Exists";
            $scope.statusval = response.status;
            $scope.statustext = response.statusText;
            $scope.headers = response.headers();
        });
    };
});




