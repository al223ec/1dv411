﻿//load the chart library
google.load('visualization', '1', { packages: ['corechart'] });

angular.module("ChartProvider", [])

    .factory("ChartGenerator", ['AppService', function (AppService) {

    return {
        draw: function () {
            console.log("rdfsxz");
            var diagramDataPromise = AppService.getDiagramData(7);
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