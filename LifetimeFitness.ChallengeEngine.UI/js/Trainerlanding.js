var app = angular.module('ltfAppTrainer', []);

app.controller('myenroll', function ($scope, $http, $rootScope) {

    var baseUri = "http://localhost:56507/";

    $scope.eCategorylist = [];
    $scope.eChallengelist = [];
    $scope.eUserlist = [];
    $scope.eClublist = [];


    $http.get(baseUri + "api/Club/GetClub").then(function (responses) {
        console.log(responses);
        console.log($rootScope.clubname);
        $scope.eClublist = responses.data;
        $scope.myClubValue = $scope.eClublist;
    });
    $http.get(baseUri + "api/Category/GetCategory").then(function (responses) {
        console.log(responses);
        $scope.eCategorylist = responses.data;
        $scope.myCategoryValue = $scope.eCategorylist;
    });
    $http.get(baseUri + "api/Challenge/GetChallenges").then(function (responses) {
        console.log(responses);
        $scope.eChallengelist = responses.data;
        $scope.myChallengeValue = $scope.eChallengelist;
    });
    $http.get(baseUri + "api/User/GetUsers").then(function (responses) {
        console.log(responses);
        $scope.eUserlist = responses.data;
        $scope.myUserValue = $scope.eUserlist[0];
    });
    $scope.selectedUserId = null;
    $scope.setSelectedUserId = function (idSelected) {
        $scope.selectedUserId = idSelected;
        console.log(idSelected);
    }
    
    $scope.enrollUser = function (myCategoryValue, myChallengeValue, selectedUserId) {
        
        var data = {
            UserId: selectedUserId.UserId,
            ChallengeId :myChallengeValue  
        };
        console.log(data);
        
        $http.post(baseUri + 'api/Enrollment/PostEnrollment', data).then(function (response) {
            if (response.data)
                $scope.msg = "Post Data Submitted Successfully!";
            alert('User enrollment for challenge is successfull');

        }, function (response) {
            $scope.msg = "Service not Exists";
            $scope.statusval = response.status;
            $scope.statustext = response.statusText;
            $scope.headers = response.headers();
        });
    };
});
