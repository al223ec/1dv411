angular.module('ChartFactory', [])
    .factory('monthChart', ['AppService', function (AppService) {
        return {
            draw: function () {
                console.log("rdfsxz");
                var diagramDataPromise = AppService.getDiagramDataByMonth();
                diagramDataPromise.success(function (json) {
                    var orderData = JSON.parse(JSON.stringify(json));

                    var data = new google.visualization.DataTable();

                    data.addColumn('string', 'Datum');
                    data.addColumn('number', 'Ordrar');
                    data.addColumn('number', 'Ordrar Förra Året')


                    orderData.forEach(function (order) {
                        data.addRows([[order.date, order.orders, order.ordersLastYear]])
                    });



                    var options = {
                        title: 'Företagsdata',
                        vAxis: { textPosition: 'none' },
                        enableInteractivity: false
                    };

                    var googleChart = new google.visualization.ColumnChart(document.getElementById("chartDiv"));
                    googleChart.draw(data, options);

                })
            }
        }
    }])

    .factory('weekChart', ['AppService', function (AppService) {
        return {
            draw: function () {
                var weekDays = ['Söndag', 'Måndag', 'Tisdag', 'Onsdag', 'Torsdag', 'Fredag', 'Lördag'];
                var diagramDataPromise = AppService.getDiagramDataByWeek();
                diagramDataPromise.success(function (response) {

                    var data = new google.visualization.DataTable();

                    data.addColumn('string', 'Ordrar');
                    data.addColumn('number', 'Ordrar Förra Året')


                    orderData.forEach(function (order) {
                        data.addRows([[order.date, order.orders, order.ordersLastYear]])
                    });



                    var options = {
                        hAxis{labels: ''},
                        title: 'Företagsdata',
                        vAxis: { textPosition: 'none' },
                        enableInteractivity: false
                    };

                    var googleChart = new google.visualization.ColumnChart(document.getElementById("chartDiv"));
                    googleChart.draw(data, options);

                })
            }
        }
    }])