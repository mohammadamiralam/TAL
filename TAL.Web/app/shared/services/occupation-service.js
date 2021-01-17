templatingApp.factory('OccupationService', OccupationService);

OccupationService.$inject = ['$http', '$q', '$sce'];

function OccupationService($http, $q, $sce) {
    var service = {};
    service.GetOccupations = GetOccupations;

    service.Occupations = [];
    return service;

    function GetOccupations() {
        var deferred = $q.defer();
        var wsUrl = templatingApp.commonConstants.API + 'Occupation/GetOccupations';
        
        var trustedUrl = $sce.trustAsResourceUrl(wsUrl);
        $http({
            method: 'GET',
            url: trustedUrl
        }).then(function (response) {
            service.Occupations = response.data;
            deferred.resolve(service.Occupations);
        }, function errorCallback(response) {
            console.log("Error while fetching Occupations!");
            deferred.resolve(service.Occupations);
        });

        return deferred.promise;
    }
}