//load the chart library
google.load('visualization', '1', { packages: ['corechart'] });

angular.module("ChartProvider", [])

    .factory("ChartGenerator", ['AppService', function (AppService) {
    
    return {
        draw: function (id) {
            console.log("rdfsxz");
            var diagramDataPromise = AppService.getDiagramDataByWeek();
            //var diagramDataPromise = AppService.getDiagramDataByMonth();
            diagramDataPromise.success(function (json) {
                console.log(json);
                var orderData = JSON.parse(JSON.stringify(json));

                var data = new google.visualization.DataTable();

                data.addColumn('datetime', 'Datum');
                data.addColumn('number', 'Ordrar');
                data.addColumn('number', 'Ordrar Förra Året')
               

                orderData.forEach(function (order) {
                    data.addRows([[new Date(order.date), order.orders, order.ordersLastYear]])
                });

              
               
                var options = {
                    title: 'Företagsdata',
                    vAxis: { textPosition: 'none' },
                    enableInteractivity: false
                };

                var div = document.createElement("div");
                var googleChart = new google.visualization.ColumnChart(document.getElementById(id));
                googleChart.draw(data, options);

                })
            }
    }

}])