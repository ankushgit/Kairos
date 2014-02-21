module.factory("opportunitiesService", function ($http,$q) {
    var _url = "/api/opportunities/";
    var _opportunities = [];
    var _isInit = false;

    var _getOpportunities = function () {
        var deferred = $q.defer();
        $http.get(_url)
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

    var _getOpportunity = function (id) {
        var deferred = $q.defer();
        if (_isInit)
        {
            var index = _indexOf(id);
            if (index != -1)
                deferred.resolve(_opportunities[index]);
            else
                deferred.reject();
        }
        else
        {
            $http.get(_url + id)
                .then(function (result) {
                    //Success
                    deferred.resolve(result.data);
                },
                function () {
                    //Error
                    deferred.reject();
                });

        }
        return deferred.promise;
    };

    //Private Function
    var _indexOf = function (id) {
        for (var i = 0; i < _opportunities.length; i++) {
            if (_opportunities[i].id == id) {
                return i;
            }
        }
        return -1;
    };

    var _addOpportunity = function (newOpportunity) {
        var deferred = $q.defer();

        $http.post(_url, newOpportunity)
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

    var _editOpportunity = function (opportunity) {
        var deferred = $q.defer();

        $http.put(_url + opportunity.id, opportunity)
            .then(function (result) {
                //success
                var editedOpportunity = result.data;
                //update the opportunities collection with the edited opportunity
                var index = _indexOf(editedOpportunity.id);
                if (index != -1)
                    _opportunities[index] = editedOpportunity;
                deferred.resolve(editedOpportunity);
            },
            function () {
                //error
                deferred.reject();
            });
        return deferred.promise;
    };
    var _deleteOpportunity = function (id) {
        var deferred = $q.defer();
        $http.delete(_url + id)
        .then(function () {
            //success
            var index = _indexOf(id);
            if (index != -1)
                _opportunities.splice(index, 1);
            deferred.resolve();
        }, function () {
            //error
            deferred.reject();
        });
        return deferred.promise;
    };
    return {
        opportunities: _opportunities,
        getOpportunities: _getOpportunities,
        getOpportunity: _getOpportunity,
        addOpportunity: _addOpportunity,
        editOpportunity: _editOpportunity,
        deleteOpportunity: _deleteOpportunity,
        isInit: _isInit
    };
});