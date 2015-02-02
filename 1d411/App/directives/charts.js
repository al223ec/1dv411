// If module dependencies, add them to the array in second parameter.
var charts = angular.module('chartDirectives', []);

// append a custom directive (inventoryChart) to the module chartDirectives. 
charts.directive('inventoryChart', function () {
    return {
        restrict: 'E',
        //template: "<div><p>Below is a custom directive.</p><p ng-show='testController.isTest()'>test</p></div>" +
        //    "<div id='chart'></div>",
        templateUrl: "Views/App/inventory-chart.html",
        controller: function () {

            this.test = true;
            this.isTest = function () {

                console.log(c3);
                console.log(d3);
                return this.test;
            }

            // Generate logic below should be moved to an angular factory that is prepared in factories/ChartGenerator.
            this.generateChart = function () {

                var chart = c3.generate({
                    bindto: '#chart',
                    data: {
                        columns: [
                            ['data1', 30, 200, 100, 400, 150, 250],
                            ['data2', 50, 20, 10, 40, 15, 25]
                        ],
                        axes: {
                            data2: 'y2'
                        },
                        types: {
                            data2: 'bar' // ADD
                        }
                    },
                    axis: {
                        y: {
                            label: {
                                text: 'Y Label',
                                position: 'outer-middle'
                            }
                        },
                        y2: {
                            show: true,
                            label: {
                                text: 'Y2 Label',
                                position: 'outer-middle'
                            }
                        }
                    }
                });
            }
            this.generateChart();
        },
        controllerAs: 'testController'
    }
});