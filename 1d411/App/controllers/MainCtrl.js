angular.module('Main', [])
    .controller('MainController', ['$scope', 'appService', 'LayoutScreenService', function ($scope, appService, LayoutScreenService) {

        LayoutScreenService.getScreens()
            .success(function (data) {
                console.log(data);
                $scope.screens = data; 
            });
    }]);
