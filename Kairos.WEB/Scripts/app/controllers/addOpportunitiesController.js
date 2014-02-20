function addOpportunitiesController($scope, $window, opportunitiesService) {
    $scope.title = "Add New Opportunity";
    $scope.newOpportunity = {};

    $scope.save = function () {
        opportunitiesService.addOpportunity($scope.newOpportunity)
        .then(function () {
            //success
            $window.location = "#/opportunities";
        }, function () {
            //error
            alert("Cannot save the new Opportunity");
        });
    };
}