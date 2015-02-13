"use strict";
var layoutCtrl = angular.module('Layout', []);

layoutCtrl.controller('LayoutController', ['$scope', 'AppService', function ($scope, AppService) {
    var response = AppService.getDiagramDataByWeek().success(function (data) {
        var date = new Date(data[0].date)
        console.log(date.getDay());
    });

}]);

layoutCtrl.controller('LayoutDetailsController', ['$scope', 'AppService', function ($scope, AppService) {

}]);

layoutCtrl.controller('testController', ['$scope', 'AppService', 'GoogleChartGenerator', function ($scope, AppService, GoogleChartGenerator) {
    var layoutName = 'h-2';
    GoogleChartGenerator.draw('chartDiv');
    $scope.layoutUrl = "Views/App/Layout/" + layoutName + '.html';

    console.log($scope.layoutUrl);
}]);
