"use strict";
var layoutCtrl = angular.module('TestScreen', []);

layoutCtrl.controller('TestScreenCtrl', ['$scope', 'ScreenService', 'GoogleChartGenerator', '$routeParams', function ($scope, ScreenService, GoogleChartGenerator, $routeParams) {

    ScreenService.getLayoutForScreen($routeParams.id)
        .success(function (response) {

            // Actual response
            //$scope.layout = response;
          
            // Fake response
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
                        'title': 'Some title',
                        "text": "Some text",
                        "position": 1,
                        "id": 10,
                        "name": "text"
                    }],
                "name": "TestLayout2",
                "templateUrl": null,
                "id": 1
            };

            var partials = $scope.layout.partials;
            
            // TODO: Sort the response layout object order by position.
            for (var i = 1; i <= partials.length; i++) {
                var value = "partial" + i;
                console.log(i);
                $scope["partial" + i] = partials[i - 1];

                // Check if partial type is text and set the text properties on scope for the text partial view.
                switch (partials[i - 1].name) {
                    case 'text':
                        $scope.title = partials[i - 1].title;
                        $scope.text = partials[i - 1].text;
                        break;

                    default:
                        break;
                }
            }
            console.log($scope);

        })
        .then(function () {

            GoogleChartGenerator.draw('testChart');
        });
}]);