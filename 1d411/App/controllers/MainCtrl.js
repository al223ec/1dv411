angular.module('Main', [])
    .controller('MainController', ['$scope', 'AppService', 'LayoutScreenService', function ($scope, AppService, LayoutScreenService) {

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
