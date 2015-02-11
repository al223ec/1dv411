// If module dependencies, add them to the array in second parameter.
angular.module('chartDirectives', [])
     // append a custom directive (inventoryChart) to the module chartDirectives. 
    .directive('inventoryChart', ['ChartGenerator', function (ChartGenerator) {
        return {
            restrict: 'E',
            templateUrl: 'Views/App/inventory-chart.html',
            controller: function () {
                console.log('inventory chart controller running');
                // Test Code
                this.test = true;
                this.isTest = function () {

                    return this.test;
                }
                
                // Generate chart
                ChartGenerator.draw();
            },
            controllerAs: 'testController'
        }
    }])
    .directive('layoutContent', function () {
        return {
            restrict: 'E',
            transclude: true,
            scope: {
                layoutname: "@"
            },
            template: '<div ng-transclude></div>',
            controller: function () {
                
                console.log('running');
            },
            replace: true
        }
    });
