"use strict";

var diagramModule = angular.module('Diagram', []);
diagramModule.directive('diagram', function ($compile) {

    var linker = function (scope, element, attrs) {
    }
    return {
        restrict: "E", // only matches element name
        link: linker,
        scope: {
            diagram: '='
        },
    };
});
