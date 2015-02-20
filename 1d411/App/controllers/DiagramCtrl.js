"use strict";
var diagramModule = angular.module('Diagram', []);

//http://maxklenk.github.io/angular-chart/index.html Angular chart, verkar vettigare än google chart tycker jag
//Denna kontroller ska även uppdatera diagrammet i ett vist tidsintervall
diagramModule.controller('DiagramController', ['$scope', function ($scope) {
    console.log($scope.diagram);
    var data = $scope.partial.data; 
    for (var i = 0; i < data.length; i++) {
        data[i].budget = data[i].ordersLastYear * 1.25; 
    }

    $scope.dataset = $scope.diagram.data;
    $scope.schema = {
        day: {
            type: 'datetime',
            format: '%Y-%m-%d',
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
        },
        {
          key: "budget",
          type: "spline",
          axis : "y",
          color: "#ff000e"
        },
        ],
        xAxis: {
            key: 'date',
            displayFormat: '%Y-%m-%d %H:%M:%S'
        }
    };

    $scope.add = function () {
        console.log("add"); 
        $scope.dataset[1].orders += 1; 
        console.log($scope.dataset[1].orders);
    }
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
    Manage the life-cycle of other components (for example, to create service instances).
    
//Samma funktionalitet som kontrollern men detta genom ett direktiv 
// nås via: <diagram diagram="diagram"></diagram>
diagramModule.directive('diagram', function ($compile) {
    var template = '<angularchart dataset="dataset" schema="schema" options="options"></angularchart>'; 

    var linker = function (scope, element, attrs) {
        scope.dataset = scope.diagram.data;
        console.log(scope.diagram);

        scope.schema = {
            day: {
                type: 'datetime',
                format: '%Y-%m-%d',
                name: 'Date'
            }
        };

        scope.options = {
            rows: [{
                key: 'orders',
                type: 'bar'
            }, {
                key: 'ordersLastYear',
                type: 'bar'
            },
            {
              key: "budget",
              type: "spline",
              axis : "y",
              color: "#ff7f0e"
            },
            ],
            xAxis: {
                key: 'date',
                displayFormat: '%Y-%m-%d %H:%M:%S'
            }
        };
        element.html(template);
        $compile(element.contents())(scope);
    }
    return {
        restrict: "E", // only matches element name
        link: linker,
        scope: {
            diagram: '='
        },
    };
});
    
    
    
    */