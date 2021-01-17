
templatingApp.controller('HomeController', ['$scope', 'OccupationService', 'UserPremiumService', function ($scope, OccupationService, UserPremiumService) {
    $scope.message = "Welcome to Premium Calculator Home Page!";
    $scope.entity = {};
    OccupationService.GetOccupations().then(function (response) {
        $scope.occupations = response;
    }, function errorCallback(response) {

    });

    $scope.confirmSubmit = function () {
        UserPremiumService.CalculatePremium($scope.entity).then(function (response) {
            $scope.Premium = response;
            $scope.showPremiumAmount = true;
            console.log($scope.Premium);
        }, function errorCallback(response) {

        });
    }

}]);
