"use strict";
var layoutCtrl = angular.module('TestScreen', []);

layoutCtrl.controller('TestScreenCtrl', ['$scope', 'ScreenService', '$routeParams', function ($scope, ScreenService, $routeParams) {

    console.log(google);
    ScreenService.getLayout($routeParams.id)
        .success(function (response) {
            console.log(response);
            $scope.layout = response;
        });

    ScreenService.getScreen()
        .success(function (response) {
            console.log(response);
        });

}]);