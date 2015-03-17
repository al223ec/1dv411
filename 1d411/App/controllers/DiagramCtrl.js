"use strict";
var diagramModule = angular.module('Diagram', []);

//http://maxklenk.github.io/angular-chart/index.html Angular chart, verkar vettigare än google chart tycker jag
//Denna kontroller ska även uppdatera diagrammet i ett vist tidsintervall
diagramModule.controller('DiagramController', ['$scope', function ($scope) {
    var data = $scope.partial.data;
    for (var i = 0; i < data.length; i++) {
        data[i].budget = data[i].ordersLastYear * 1.10; 
    }

    $scope.dataset = $scope.diagram.data;

    $scope.options = {
        rows: [
            {
                key: 'orders',
                name: 'This year',
                type: 'bar'
            },
            {
                key: 'ordersLastYear',
                name: 'Last Year',
                type: 'bar'
            },
            {
                key: 'budget',
                name: 'Budget',
                type: 'spline',
                axis : 'y',
                color: '#000000'
            },
        ],
        xAxis: {
            key: 'date'
        }
    };
}]);