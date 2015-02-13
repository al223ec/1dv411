"use strict";
var screenModule = angular.module('Screen', []);

screenModule.controller('ScreenController', ['$scope', 'ScreenService', '$routeParams', 'appConfig',
    function ($scope, ScreenService, $routeParams, appConfig) {

    var req = ScreenService.getLayoutForScreen($routeParams.id);
    req.error(function () {
    });

    req.then(function (response) {
        if (response.data != null) { //I dagsläget returnerar servern en 200 även om id inte finns i databasen

            $scope.templateUrl = response.data.templateUrl; //TODO:Fixa detta på serversida, att det är riktig data
            $scope.templateUrl = appConfig.templateUrlRoot + "default_template" + ".html";

            var partials = response.data.partials;
            var sortedPartials = []; 

            for (var i = 0; i < partials.length; i++) {
                sortedPartials[partials[i].position] = partials[i]; 
            }
            $scope.partials = sortedPartials;
        }
    });
}]);

screenModule.directive('partial', function ($compile, PartialHtmlService) {
    // https://docs.angularjs.org/api/ng/service/$compile
    // https://github.com/simpulton/angular-dynamic-templates

    var linker = function (scope, element, attrs) {
        PartialHtmlService.getPartialHtml(scope.partial.partialType).then(function (response) {
            var templates = response.data;

            element.html(templates);
            $compile(element.contents())(scope);
        });
    }
    return {
        restrict: "E", // only matches element name
        link: linker,
        scope: {
            partial:'='
        },
    };
});