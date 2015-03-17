angular.module('Main', [])
    .controller('MainController', ['$scope', 'appService', 'LayoutScreenService',
        function ($scope, appService, LayoutScreenService) {

        LayoutScreenService.getScreens().success(function (data) {
            $scope.screens = data;
        });
        appService.getApplicationStats().success(function (data) {
            $scope.stats = data;
        });
    }]);
