
angular.module("GoogleChart", [])

    .directive("googleChart", ['ChartGenerator', function (ChartGenerator) {
        return {
            restrict: "E",
            templateUrl: 'Views/App/google-chart.html',

            controller: function () {
                console.log(ChartGenerator);
               ChartGenerator.draw();
            },
            controllerAs: 'GoogelCtrl'
        }
    }])