"use strict";
var layoutCtrl = angular.module('TestScreen', []);

layoutCtrl.controller('TestScreenCtrl', ['$scope', 'ScreenService', 'ChartGenerator', '$routeParams', function ($scope, ScreenService, ChartGenerator, $routeParams) {

    //ChartGenerator.draw('testChart');

    ScreenService.getLayoutForScreen($routeParams.id)
        .success(function (response) {
            console.log(response);
            $scope.layout = response;
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