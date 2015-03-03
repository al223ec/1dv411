/// <reference path="MainCtrl.js" />
angular.module('Main', [])
    .controller('MainController', ['$scope', 'appService', 'LayoutScreenService',
        function ($scope, appService, LayoutScreenService) {

        LayoutScreenService.getScreens().success(function (data) {
            $scope.screens = data;
        });
        appService.getApplicationStats().success(function (data) {
            console.log(data);
            $scope.stats = data;
        });
        $scope.seedOrdersSinceLastYear = function (e) {
            var start = new Date().getTime();
            $(e.target).closest('.button').eq(0).hide();
            appService.seedOrdersSinceLastYear().success(function (data) {
                var end = new Date().getTime();
                console.log((end-start) + 'ms, ' + ((end-start)/1000) + 's')
                console.log(data);
            })
        };
        $scope.seedAllLiveOrders = function (e) {
            $(e.target).closest('.button').eq(0).hide();
            appService.seedAllLiveOrders().success(function (data) {
                console.log(data);
            });
        }
    }]);
