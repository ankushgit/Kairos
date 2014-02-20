function opportunitiesController($scope, opportunitiesService) {
    $scope.title = "Manage Opportunities";
    $scope.data = opportunitiesService; //TIP: need to bind to the service for angular to perform data binding / UI refresh
    $scope.isBusy = false;
    if (!opportunitiesService.isInit)
    {
        $scope.isBusy = true;
        opportunitiesService.getOpportunities()
        .then(function () {
            //success
        }, function () {
            //error
            alert("Error getting opportunities")
        })
        .then(function () {
            $scope.isBusy = false;
        });
    }
}