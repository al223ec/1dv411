"use strict";
var layoutCtrl = angular.module('Screen', []);

layoutCtrl.controller('ScreenController', ['$scope', 'ScreenService', function ($scope, ScreenService) {
    $scope.getScreen = function () {
        var req = ScreenService.getScreen();
        req.error(function () {

        });
        req.then(function (response) {
            console.log(response.data);
        });
    }; 

    $scope.getLayout = function (id) {
        var req = ScreenService.getLayout(id);
        req.error(function () {

        });

        req.then(function (response) {
            $scope.layout = response.data;
        });
    }; 

}]);