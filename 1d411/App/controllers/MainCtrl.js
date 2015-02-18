angular.module('Main', [])
    .controller('MainController', ['$scope', 'appService', 'LayoutScreenService', function ($scope, appService, LayoutScreenService) {

        LayoutScreenService.getLayouts()
            .success(function (data) {
                console.log(data);
                $scope.layouts = data; 
            });

        $scope.showLayout = function (layout) {
            $scope.selectedLayout = layout;
            console.log($scope.selectedLayout);
        }
    }]);
