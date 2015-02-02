
angular.module("GoogleChart", ['ChartProvider'])

    .directive("googleChart", ['ChartGenerator', function (ChartGenerator) {
        return {
            restrict: "E",
            templateUrl: 'Views/App/google-chart.html',

            controller: function () {
               ChartGenerator.draw();
            },
            controllerAs: 'GoogelCtrl'
        }
    }])