

//load the chart library
google.load('visualization', '1', { packages: ['corechart'] });

angular.module("google", [])

    .factory("chartData",['AppService', function (AppService) {

        return {
            draw: function () {
                var data1 = {};
                data1 = new google.visualization.arrayToDataTable([
                    ['Year', 'Sales', 'Expenses', 'Profit'],
                    ['2014', 1000, 400, 800],
                    ['2015', 1500, 650, 1300],
                    ['2016', 1200, 500, 1000],
                    ['2017', 600, 900, 500]
                ]);

                var options = {
                    title: 'Company Performance',
                    vAxis: { textPosition: 'none' },
                    enableInteractivity: false
                };

                var googleChart = new google.visualization.ColumnChart(document.getElementById("chartDiv"));
                googleChart.draw(data1, options);

            }
        }

    }])

    .directive("googleChart", ['chartData', function (chartData) {
        return {
            restrict: "E",
            templateUrl: 'Views/App/google-chart.html',

            controller: function () {
                chartData.draw();
            },
            controllerAs: 'GoogelCtrl'
        }
    }])