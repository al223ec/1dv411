angular.module('Main', [])
    .controller('MainController', ['$scope', 'AppService', 'LayoutScreenService', function ($scope, AppService, LayoutScreenService) {

        LayoutScreenService.getAllLayouts()
            .error(function () {

            })
            .success(function (data) {
                $scope.layouts = data; 
            });

        /**/
        var cb = function (data) {
            $scope.layouts = data;
        }
        LayoutScreenService.getAllLayouts(cb);

        $scope.showLayout = function (layout) {
            $scope.selectedLayout = layout;
            console.log($scope.selectedLayout);
        }
    }]);
