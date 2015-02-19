"use strict";

//AngularJS: What is the need of the directive's link function when we already had directive's controller with scope?
//http://stackoverflow.com/questions/20018507/angularjs-what-is-the-need-of-the-directives-link-function-when-we-already-had

var partial = angular.module('Partial', []);
partial.directive('partial', function ($compile, PartialHtmlService) {
    // https://docs.angularjs.org/api/ng/service/$compile
    // https://github.com/simpulton/angular-dynamic-templates

    var linker = function (scope, element, attrs) {

        scope[scope.partial.partialType.toLowerCase()] = scope.partial; //Sätter partial namnet på scopet så att det kan nås via detta attr

        PartialHtmlService.getPartialHtml(scope.partial.partialType).success(function (data) {
            var partialTemplates = data;
            element.html(partialTemplates);
            $compile(element.contents())(scope);
        });
    }

    return {
        restrict: "E", // only matches element name
        link: linker,
        scope: {
            partial: '='
        },
    };
});
