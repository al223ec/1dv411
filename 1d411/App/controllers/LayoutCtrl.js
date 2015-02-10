"use strict";
var layoutCtrl = angular.module('Layout', []);

layoutCtrl.controller('LayoutController', ['$scope', 'AppService', function ($scope, AppService) {

}]);

layoutCtrl.controller('LayoutDetailsController', ['$scope', 'AppService', function ($scope, AppService) {

}]);

layoutCtrl.controller('monthCtrl', ['$scope', 'AppService', function ($scope, AppService) {
    console.log(AppService);
    var getFakeData = function(){
        
        return (
                [
                    {
                        "date": "2015-01-10",
                        "orders": 2345,
                        "ordersLastYear": 2320
                    }
                ]
            )
    }

    var getData = function () {
        var diagramDataPromise = AppService.getDiagramDataByMonth();
        diagramDataPromise.success(function (data) {
            console.log(data);
        })

        return "error";
    }

    var data = getData();

    $scope.header = "MånadsVy";
    $scope.chartDiv = document.createElement("div");
    $scope.getPartial = function () {
        return 'Vievs/Partials/diagramData.html';
    }
    var orderData = getFakeData();
    google.load('visualization', '1', { packages: ['corechart'] });
    //google.setOnLoadCallback(function () {
        console.log("load");
        var data = new google.visualization.DataTable();

        data.addColumn('string', 'Datum');
        data.addColumn('number', 'Ordrar den här månaden');
        data.addColumn('number', 'Ordrar den här månaden Förra Året')


        orderData.forEach(function (order) {
            data.addRows([[order.date, order.orders, order.ordersLastYear]])
        });



        var options = {
            title: 'Företagsdata',
            vAxis: { textPosition: 'none' },
            enableInteractivity: false
        };

        // console.log(document.getElementById($scope.chartDiv).id);
   
      
        var googleChart = new google.visualization.ColumnChart(document.getElementById("chartDiv"));
        googleChart.draw(data, options);
        
        
       
    //});

   

}]);

