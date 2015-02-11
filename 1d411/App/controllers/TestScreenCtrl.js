"use strict";
var layoutCtrl = angular.module('TestScreen', []);

layoutCtrl.controller('TestScreenCtrl', ['$scope', 'ScreenService', 'ChartGenerator', '$routeParams', function ($scope, ScreenService, ChartGenerator, $routeParams) {

    //ChartGenerator.draw('testChart');

    ScreenService.getLayoutForScreen($routeParams.id)
        .success(function (response) {
            console.log(response);
            //$scope.layout = response;
          

            $scope.layout = {
                "$id": "1",
                "layoutScreens":
                [{
                    "$id": "2",
                    "screenId": 1,
                    "screen": null,
                    "layoutId": 1,
                    "layout":
                        {
                            "$ref": "1"
                        },
                    "id": 1
                }],
                "partials":
                    [{
                        "$id": "4",
                        "diagramInfo": 123,
                        "position": 2,
                        "id": 11,
                        "name": "diagram"
                    },
                    {
                        "$id": "3",
                        "type": 0,
                        "value": "Some text",
                        "position": 1,
                        "id": 10,
                        "name": "text"
                    }],
                "name": "TestLayout2",
                "templateUrl": null,
                "id": 1
            };

            var partials = $scope.layout.partials;
            $scope.partials = [];
            $scope.partialnames = [];
            for (var i = 1; i <= partials.length; i++) {
                var value = "partial" + i;
                console.log(i);
                $scope["partial"+i] = partials[i-1];
            }
            console.log($scope);
            //mkae sort

        })
        .then(function () {

            ChartGenerator.draw('testChart');
        });

    //ScreenService.getScreen()
    //    .success(function (response) {
    //        console.log(response);
    //    })
    //    .then(function () {

    //        //ChartGenerator.draw('testChart');
    //    });

    

}]);