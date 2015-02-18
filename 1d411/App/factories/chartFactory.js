//load the chart library
google.load('visualization', '1', { packages: ['corechart'] });

var chartModule = angular.module("ChartProvider", []); 

chartModule.factory("chartFactory", [function () {
      
        var days = ['Sön', 'Mån', 'Tis', 'Ons', 'Tor', 'Fre', 'Lör'];

    return {
        draw: function (div, orderData) {
            var data = new google.visualization.DataTable();
            var currentYear = new Date();

            data.addColumn('string', 'Datum');
            data.addColumn('number', currentYear.getFullYear());
            data.addColumn('number', currentYear.getFullYear() - 1)
               

            orderData.forEach(function (order) {
                data.addRows([[days[new Date(order.date).getDay()], order.orders, order.ordersLastYear]])
            });

            var options = {
                title: 'Desing Onlines Orderdata',
                vAxis: { textPosition: 'none' },
                enableInteractivity: false
            };

            var googleChart = new google.visualization.ColumnChart(div);
            googleChart.draw(data, options);
        }
    }

}])