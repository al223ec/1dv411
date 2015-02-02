// This is not active nor functional right now, just an idea for later.

var charts = angular.module('chartDirectives', []);

charts.factory('ChartGenerator', ['AppService', function (AppService) {

    var data = {};

    //AppService.getDiagramData(query)
    //    .then(function (response) {

    //        data = response.data;
    //        console.log(response)
    //    })
    //    .error(function (data, status, headers, config) {

    //        //Do something on failure
    //        console.log("Failure");
    //    });

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

        return chart;
    }

}]);