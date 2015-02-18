"use strict";

var partial = angular.module('Partial', []);

partial.directive('partial', function ($compile, PartialHtmlService) {
    // https://docs.angularjs.org/api/ng/service/$compile
    // https://github.com/simpulton/angular-dynamic-templates

    var linker = function (scope, element, attrs) {
        PartialHtmlService.getPartialHtml(scope.partial.partialType).then(function (response) {
            var partialTemplates = response.data;

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
