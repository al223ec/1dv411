angular.module('ChartFactory', [])
    .factory('ChartGenerator', ['AppService', function (AppService) {
        return {
            draw: function (chartdata) {
                var data = google.visualization.arrayToDataTable([
                    ['Dag', 'Sales', 'Expenses', 'Profit'],
                    ['mån', 1000, 400, 800],
                    ['tis', 1500, 650, 1300],
                    ['ons', 1200, 500, 1000],
                    ['fre', 600, 900, 500]
                ]);

                var options = {
                    title: 'Company Performance',
                    vAxis: { textPosition: 'none' },
                    enableInteractivity: false
                };

                var chart = new google.visualization.ColumnChart(document.getElementById('barchart_material'));
                chart.draw(data, options);
            }
        }
    }])

   