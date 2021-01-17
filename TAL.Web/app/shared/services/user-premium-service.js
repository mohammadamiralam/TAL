templatingApp.factory('UserPremiumService', UserPremiumService);

UserPremiumService.$inject = ['$http', '$q', '$sce'];

function UserPremiumService($http,$q, $sce) {
    var service = {};
    service.CalculatePremium = CalculatePremium;
    service.Premium = {};
    return service;

    function CalculatePremium(entity) {
        var deferred = $q.defer();
        
        var wsUrl = templatingApp.commonConstants.API + 'Premium/CalculateMonthlyPremium';
        var trustedUrl = $sce.trustAsResourceUrl(wsUrl);
        $http({
            method: 'POST',
            url: trustedUrl,
            data: JSON.stringify(entity)
        }).then(function (response) {
            service.Premium = response.data;
            deferred.resolve(service.Premium);
        }, function errorCallback(response) {
            console.log(response);
            console.log("Error while calculate premium!");
            deferred.resolve(service.Premium);
        });

        return deferred.promise;
    }
}