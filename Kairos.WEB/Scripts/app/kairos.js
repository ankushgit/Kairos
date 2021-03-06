﻿var module = angular.module("kairos", ['ngRoute']);

/*Client Side Routes Configuration*/
module.config(function ($routeProvider) {
    $routeProvider.when("/", {
        controller: "homeController",
        templateUrl: "/Templates/home.html"
    });

    $routeProvider.when("/opportunities", {
        controller: "opportunitiesController",
        templateUrl: "/Templates/opportunities.html"
    });

    $routeProvider.when("/opportunities/add", {
        controller: "addOpportunitiesController",
        templateUrl: "/Templates/addOpportunities.html"
    });

    $routeProvider.when("/opportunities/edit/:id", {
        controller: "editOpportunitiesController",
        templateUrl: "/Templates/editOpportunities.html"
    });

    $routeProvider.otherwise({redirectTo: "/"});
});

/* Directive: data-active-menu */
module.directive("activeMenu", function ($location) {
    var link = function (scope, element) {
        var menuItems = element.children();
        var tabMap = {};
        menuItems.each(function () {
            var li = $(this);
            var key = li.find('a').attr('href').substring(1);
            tabMap[key] = li;
        });
        scope.$watch(function () { return $location.path(); }, function (newPath) {
            menuItems.removeClass("active");
            if (newPath == "")
                newPath = "/";
            if(tabMap[newPath]) //if the map is not defined then no need to add class
                tabMap[newPath].addClass("active");
        });        
    };
    return {
        restrict: 'A',
        link: link
    };
});




