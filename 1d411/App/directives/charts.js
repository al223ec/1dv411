// If module dependencies, add them to the array in second parameter.
angular.module('chartDirectives', [])
     // append a custom directive (inventoryChart) to the module chartDirectives. 
    .directive('inventoryChart', ['ChartGenerator', function (ChartGenerator) {
        return {
            restrict: 'E',
            templateUrl: 'Views/App/inventory-chart.html',
            controller: function () {

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
}]);
