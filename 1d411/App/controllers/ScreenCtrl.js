"use strict";
var layoutCtrl = angular.module('Screen', []);

layoutCtrl.controller('ScreenController', ['$scope', 'ScreenService', '$routeParams', function ($scope, ScreenService, $routeParams) {
    $scope.getScreen = function () {
        var req = ScreenService.getScreen();
        req.error(function () {

        });
        req.then(function (response) {
            console.log(response.data);
            $scope.screen = response.data;
        });
    }; 

    $scope.getLayout = function (id) {
        var req = ScreenService.getLayout(1);
        req.error(function () {

        });

        req.then(function (response) {
            console.log(response.data)
            $scope.layout = response.data;
        });

    }

    $scope.renderDiagram = function () {

    }

}]);