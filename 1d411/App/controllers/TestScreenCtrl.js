"use strict";
var layoutCtrl = angular.module('TestScreen', []);

layoutCtrl.controller('TestScreenCtrl', ['$scope', 'ScreenService', 'ChartGenerator', '$routeParams', function ($scope, ScreenService, ChartGenerator, $routeParams) {

    ScreenService.getLayout($routeParams.id)
        .success(function (response) {
            console.log(response);
            $scope.layout = response;
        });

    ScreenService.getScreen()
        .success(function (response) {
            console.log(response);
        })
        .then(function () {

            ChartGenerator.draw('testChart');
        });

    

}]);