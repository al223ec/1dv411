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

        //TODO:Detta ska flyttas ligger bara här tillfälligt för test av angular chart
        //http://maxklenk.github.io/angular-chart/index.html Angular chart, verkar vettigare än google chart tycker jag
        if (scope.partial.partialType == "Diagram"){
            scope.dataset = scope.partial.data;
            scope.schema = {
                day: {
                    type: 'datetime',
                    format: '%Y-%m-%d_%H:%M:%S',
                    name: 'Date'
                }
            };

            scope.options = {
                rows: [{
                    key: 'orders',
                    type: 'bar'
                }, {
                    key: 'ordersLastYear',
                    type: 'bar'
                }],
                xAxis: {
                    key: 'date',
                    displayFormat: '%Y-%m-%d %H:%M:%S'
                }
            };
        }
    }

    return {
        restrict: "E", // only matches element name
        link: linker,
        scope: {
            partial: '='
        },
    };
});
