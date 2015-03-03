/// <reference path="MainCtrl.js" />
angular.module('Main', [])
    .controller('MainController', ['$scope', 'appService', 'LayoutScreenService',
        function ($scope, appService, LayoutScreenService) {

        LayoutScreenService.getScreens()
            .success(function (data) {
                $scope.screens = data; 
            });
    }]);
