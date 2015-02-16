angular.module('Main', [])
    .controller('MainController', ['$scope', 'AppService', 'LayoutScreenService', function ($scope, AppService, LayoutScreenService) {

        LayoutScreenService.getAllLayouts()
            .error(function () {

            })
            .success(function (data) {
                $scope.layouts = data; 
            });


        $scope.showLayout = function (layout) {
            $scope.selectedLayout = layout;
            console.log($scope.selectedLayout);
        }
        LayoutScreenService.getScreens().success(function (data) {
            $scope.screens = data;
        }); 
    }]);
