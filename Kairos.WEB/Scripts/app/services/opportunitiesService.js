module.factory("opportunitiesService", function ($http,$q) {
    var _opportunities = [];
    var _isInit = false;

    var _getOpportunities = function () {
        var deferred = $q.defer();
        $http.get("/api/opportunities")
            .then(function (result) {
                //Success
                angular.copy(result.data, _opportunities);
                _isInit = true;
                deferred.resolve();
            },
            function () {
                //Error
                deferred.reject();
            });
        return deferred.promise;
    };

    var _addOpportunity = function (newOpportunity) {
        var deferred = $q.defer();

        $http.post("/api/opportunities", newOpportunity)
            .then(function (result) {
                //success
                var addedOpportunity = result.data;
                _opportunities.splice(0, 0, addedOpportunity); //add to the list of opportunities
                deferred.resolve(addedOpportunity);
            },
            function () {
                //error
                deferred.reject();
            });
        return deferred.promise;
    };

    return {
        opportunities: _opportunities,
        getOpportunities: _getOpportunities,
        addOpportunity: _addOpportunity,
        isInit: _isInit
    };
});