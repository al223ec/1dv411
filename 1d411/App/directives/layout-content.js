// If module dependencies, add them to the array in second parameter.
angular.module('chartDirectives', [])
     // append a custom directive (inventoryChart) to the module chartDirectives. 
    .directive('partialContent', function () {
        return {
            restrict: 'E',
            scope: {},
            template: '<div class="content" ng-transclude></div>',
            tansclude: true
        }
    });