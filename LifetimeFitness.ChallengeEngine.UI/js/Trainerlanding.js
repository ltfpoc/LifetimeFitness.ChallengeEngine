var app = angular.module('ltfAppTrainer', []);

app.controller('myenroll', function ($scope, $http, $rootScope, $window) {

    var baseUri = "http://localhost:56507/";

    $scope.eCategorylist = [];
    $scope.eChallengelist = [];
    $scope.eUserlist = [];
    $scope.eClublist = [];
    $scope.myClubValue = 5;
    $scope.UserChalist = [];
    //$window.localStorage.setItem("clubname",5);
    $scope.challengeClubRelationshipId = 0;

    $http.get(baseUri + "api/Club/GetClub").then(function (responses) {
        $scope.eClublist = responses.data;
        var getclub = $window.localStorage.getItem("clubname");
        $scope.myClubValue = getclub;// $window.localStorageService.get("clubname");
    });
    $http.get(baseUri + "api/Category/GetCategory").then(function (responses) {
        $scope.eCategorylist = responses.data;
        $scope.myCategoryValue = $scope.eCategorylist;
    });
    $scope.GetChallenges = function () {
        var myparam = "Category/" + $scope.myCategoryValue + '/Club/' + $scope.myClubValue;
        $http.get(baseUri + "api/Challenge/GetChallenges/" + myparam).then(function (responses) {
            console.log(responses);
            $scope.eChallengelist = responses.data;
            $scope.myChallengeValue = $scope.eChallengelist;
        });
    }
    $scope.GetChallengesPopup = function () {
        var myparam = "Category/" + $scope.myeCategoryValue + '/Club/' + $scope.myClubValue;
        $http.get(baseUri + "api/Challenge/GetChallenges/" + myparam).then(function (responses) {
            console.log(responses);
            $scope.eChallengelist = responses.data;
            $scope.myeChallengeValue = $scope.eChallengelist;
        });
    }
    $scope.GetSelectin = function ()
    {
        $scope.myeCategoryValue = $scope.myCategoryValue;
        $scope.myeChallengeValue = $scope.myChallengeValue;
    }

    $http.get(baseUri + "api/User/GetUsers").then(function (responses) {
        
        $scope.eUserlist = responses.data;
        $scope.myUserValue = $scope.eUserlist[0];
    });
    $scope.GetUsersNotInChallenge = function () {
        console.log("Pritesh");
        $http.get(baseUri + "api/User/GetUsers/Challenge/" + $scope.myeChallengeValue + "/Club/" + $scope.myClubValue).then(function (responses) {
            console.log(baseUri + "api/User/GetUsers/Challenge/" + $scope.myeChallengeValue + "/Club/" + $scope.myClubValue);
            $scope.UserChalist = responses.data;
            $scope.myUserValue = $scope.UserChalist[0];
        });
    }
    $scope.selectedUserId = null;
    $scope.setSelectedUserId = function (idSelected) {
        $scope.selectedUserId = idSelected;
        console.log(idSelected);
    }

    $scope.enrollUser = function (myCategoryValue, myChallengeValue, selectedUserId, myClubValue) {
        //"api/Challenge/GetChallengeClubRelationship/Club/{clubid}/Challenge/{challengeId}")
         debugger;
        $http.get(baseUri + "api/Challenge/GetChallengeClubRelationship/Club/" + $scope.myClubValue + "/Challenge/" + $scope.myeChallengeValue).then(function (responses) {
            $scope.challengeClubRelationshipId = responses.data.ChallengeClubRelationId;
            //$scope.myUserValue = $scope.UserChalist[0];
        });

        var data = {
            UserId: selectedUserId.UserId,
            ChallengeId: myChallengeValue,
            ChallengeClubRelationId :  $scope.challengeClubRelationshipId
        };
        console.log(selectedUserId.UserId);

        $http.post('http://localhost:56507/api/Enrollment/PostEnrollment', data).then(function (response) {
            if (response.data)
                $scope.msg = "Post Data Submitted Successfully!";
            alert('User enrollment for challenge is successfull');
            debugger;
            $scope.GetUsersNotInChallenge();

        }, function (response) {
            $scope.msg = "Service not Exists";
            $scope.statusval = response.status;
            $scope.statustext = response.statusText;
            $scope.headers = response.headers();
        });
    };
});




