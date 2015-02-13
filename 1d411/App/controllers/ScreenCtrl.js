"use strict";
var layoutCtrl = angular.module('Screen', []);

layoutCtrl.controller('ScreenController', ['$scope', 'ScreenService', '$routeParams', function ($scope, ScreenService, $routeParams) {
    $scope.getScreen = function () {
        var req = ScreenService.getScreen();
        req.error(function () {

        });
        req.then(function (response) {
            console.log(response.data);
        });
    }; 

    $scope.getLayout = function (id) {
        var req = ScreenService.getLayoutForScreen(id);
        req.error(function () {

        });

        req.then(function (response) {
            console.log(response.data);

            $scope.templateUrl = response.data.templateUrl; //TODO:Fixa detta på serversida, att det är riktig data
            $scope.templateUrl = "/Views/App/Templates/default_template.html";

            var partials = response.data.partials;
            var sortedPartials = []; 

            for (var i = 0; i < partials.length; i++) {
                sortedPartials[partials[i].position] = partials[i]; 
            }
            $scope.partials = sortedPartials;
        });
    }; 

}]);