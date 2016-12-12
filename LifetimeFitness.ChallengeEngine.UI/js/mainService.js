angular.module('mainService', []).factory('MainService', function ($rootScope) {
    var service = {};
    service.clubValue = 0;
    service.myCategoryValue = 0;
    service.challengeValue = 0;

    service.updateClubValue = function (value) {
        this.clubValue = value;
        $rootScope.$broadcast("valuesUpdated");
    }

    service.updateCategoryValue = function (value) {
        this.myCategoryValue = value;
        $rootScope.$broadcast("valuesUpdated");
    }

    service.updateChallengeValue = function (value) {
        this.challengeValue = value;
        $rootScope.$broadcast("valuesUpdated");
    }

    return service;
});
var app = angular.module('ltfAppTrainer', ['mainService']);