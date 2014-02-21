function editOpportunitiesController($scope, $window, $routeParams, opportunitiesService) {
    $scope.title = "Edit Opportunities";

    $scope.opportunity = null;

    opportunitiesService.getOpportunity($routeParams.id)
    .then(function (opp) {
        $scope.opportunity = opp;
    }, function () {
        alert("Error getting the Opportunity");
    });

    $scope.save = function () {
        opportunitiesService.editOpportunity($scope.opportunity)
        .then(function () {
            //success
            $window.location = "#/opportunities";
        }, function () {
            //error
            alert("Cannot save the new Opportunity");
        });
    };

}