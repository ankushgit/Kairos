var module = angular.module("kairos", ['ngRoute']);

module.config(function ($routeProvider) {
    $routeProvider.when("/", {
        controller: "homeController",
        templateUrl: "/Templates/home.html"
    });

    $routeProvider.when("/opportunities", {
        controller: "opportunitiesController",
        templateUrl: "/Templates/opportunities.html"
    });

    $routeProvider.when("/projects", {
        controller: "projectsController",
        templateUrl: "/Templates/projects.html"
    });

    $routeProvider.otherwise({redirectTo: "/"});
});