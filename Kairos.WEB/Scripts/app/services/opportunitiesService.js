module.factory("opportunitiesService", function ($http,$q) {
    var _opportunities = [];

    var _getOpportunities = function () {
        var deferred = $q.defer();
        $http.get("/api/opportunities")
            .then(function (result) {
                //Success
                angular.copy(result.data, _opportunities);
                deferred.resolve();
            },
            function () {
                //Error
                deferred.reject();
            });
        return deferred.promise;
    };
    return {
        opportunities: _opportunities,
        getOpportunities: _getOpportunities
    };
});