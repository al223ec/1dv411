"use strict";
var diagramModule = angular.module('Diagram', []);

//http://maxklenk.github.io/angular-chart/index.html Angular chart, verkar vettigare än google chart tycker jag
//Denna kontroller ska även uppdatera diagrammet i ett vist tidsintervall

diagramModule.controller('DiagramController', ['$scope', function ($scope) {

    $scope.dataset = $scope.diagram.data;
    $scope.schema = {
        day: {
            type: 'datetime',
            format: '%Y-%m-%d_%H:%M:%S',
            name: 'Date'
        }
    };

    $scope.options = {
        rows: [{
            key: 'orders',
            type: 'bar'
        }, {
            key: 'ordersLastYear',
            type: 'bar'
        }],
        xAxis: {
            key: 'date',
            displayFormat: '%Y-%m-%d %H:%M:%S'
        }
    };
}]);
/**
Use controllers to:
    Set up the initial state of the $scope object.
    Add behavior to the $scope object.

Do not use controllers to:

    Manipulate DOM — Controllers should contain only business logic. Putting any presentation logic into Controllers significantly affects its testability. Angular has databinding for most cases and directives to encapsulate manual DOM manipulation.
    Format input — Use angular form controls instead.
    Filter output — Use angular filters instead.
    Share code or state across controllers — Use angular services instead.
    Manage the life-cycle of other components (for example, to create service instances).*/