// This is not active nor functional right now, just an idea for later.

angular.module('ChartGenerator', [])

    .factory('ChartGenerator', ['AppService', function (AppService) {

        //AppService.getDiagramData(query)
        //    .then(function (response) {

        //        data = response.data;
        //        console.log(response)
        //    })
        //    .error(function (data, status, headers, config) {

        //        //Do something on failure
        //        console.log("Failure");
        //    });
        return {
            draw: function () {

                var diagramDataPromise = AppService.getDiagramData();
                diagramDataPromise.success(function (json) {
                    var orderData = JSON.parse(JSON.stringify(json));

                    console.log(orderData);
                    console.log(orderData[0].orders);
                    console.log(orderData[0].ordersLastYear);
                    var chart = c3.generate({
                        bindto: '#chart',
                        data: {
                            columns: [
                                ['2015', json[0].orders],
                                ['2014', json[0].ordersLastYear]
                            ],
                            type: 'bar',
                            axes: {
                                data2: 'y2'
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
                                show: false,
                                label: {
                                    text: 'Y2 Label',
                                    position: 'outer-middle'
                                }
                            }
                        }
                    });

                    return chart;
                });
            }
        };
}]);