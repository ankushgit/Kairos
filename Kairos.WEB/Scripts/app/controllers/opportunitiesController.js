function opportunitiesController($scope, $http, opportunitiesService) {
    $scope.title = "Manage Opportunities";
    $scope.data = opportunitiesService; //TIP: need to bind to the service for angular to perform data binding / UI refresh
    $scope.isBusy = true;

    opportunitiesService.getOpportunities()
    .then(function () {
        //success
    }, function () {
        alert("Error getting opportunities")
    })
    .then(function () {
        $scope.isBusy = false;
    });
}