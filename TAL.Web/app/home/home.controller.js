
templatingApp.controller('HomeController', ['$scope', 'OccupationService', 'UserPremiumService', function ($scope, OccupationService, UserPremiumService) {
    $scope.message = "Welcome to Premium Calculator Home Page!";
    $scope.entity = {};
    $scope.showDOBError = false;
    OccupationService.GetOccupations().then(function (response) {
        $scope.occupations = response;
    }, function errorCallback(response) {

    });

    function getAge(dateString) 
    {
        var today = new Date();
        var birthDate = new Date(dateString);
        var age = today.getFullYear() - birthDate.getFullYear();
        var m = today.getMonth() - birthDate.getMonth();
        if (m < 0 || (m === 0 && today.getDate() < birthDate.getDate())) 
        {
            age--;
        }
        return age;
    }

    $scope.calculateAge = function () {
        $scope.showDOBError = false;
        var age = getAge($scope.entity.dob);
        if ($scope.entity.age < age)
            $scope.showDOBError = true;
    }

    $scope.confirmSubmit = function () {
        
        UserPremiumService.CalculatePremium($scope.entity).then(function (response) {
            $scope.Premium = response;
            $scope.showPremiumAmount = true;
            console.log($scope.Premium);
        }, function errorCallback(response) {

        });
    }

}]);
