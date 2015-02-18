"use strict";

var diagramModule = angular.module('Diagram', []);
diagramModule.directive('diagram', function ($compile, appConfig, chartFactory) {

    var linker = function (scope, element, attrs) {
        var div = document.createElement("div"); 
        chartFactory.draw(div, scope.data);

        element.html(div);
        $compile(element.contents())(scope);
    }

    return {
        restrict: "E", // only matches element name
        link: linker,
        scope: {
            data: '='
        },
    };
});
