"use strict";
var screenModule = angular.module('Screen', []);

screenModule.controller('ScreenController', ['$scope', 'LayoutScreenService', '$routeParams', 'appConfig',
    function ($scope, LayoutScreenService, $routeParams, appConfig) {

        var req = LayoutScreenService.getLayoutForScreen($routeParams.id);
        req.error(function (data, status, headers, config) {

        });
        req.success(function (data, status, headers, config) {
            if (data) { //I dagsläget returnerar servern en 200 även om id inte finns i databasen men data är däremot null
                var templateName = data.templateUrl == null ? "default_template" : data.templateUrl;
                $scope.templateUrl = appConfig.templateUrlRoot + templateName + ".html";

                var partials = data.partials;
                var sortedPartials = [];

                for (var i = 0; i < partials.length; i++) {
                    sortedPartials[partials[i].position] = partials[i]; 
                }

                console.log(partials); 
                $scope.partials = sortedPartials;
            } else {
                console.log("Verkar inte få något bra svar från servern, är databasen seedad och uppe? Annars kanske inte id:et finns")
            }
        
        });

        LayoutScreenService.getLayoutsWithScreenId($routeParams.id)
        .success(function (data, status, headers, config) {
            //console.log(data); 
        }); 
        
    }]);

screenModule.controller('AdminScreensController', ['$scope', 'LayoutScreenService', '$routeParams', 'appConfig',
    function ($scope, LayoutScreenService, $routeParams, appConfig) {
        var screens = LayoutScreenService.getScreens().success(function (data) {
            $scope.screens = data;
        });
        $scope.selectScreen = function (screen) {
            $scope.s = ($scope.s != screen) ? screen : null;    
        }
    }]);
screenModule.controller('AdminLayoutsController', ['$scope', 'LayoutScreenService', '$routeParams', 'appConfig',
    function ($scope, LayoutScreenService, $routeParams, appConfig) {

    }]);
screenModule.controller('AdminDesignsController', ['$scope', 'LayoutScreenService', '$routeParams', 'appConfig',
    function ($scope, LayoutScreenService, $routeParams, appConfig) {

    }]);
screenModule.controller('AdminDiagramsController', ['$scope', 'LayoutScreenService', '$routeParams', 'appConfig',
    function ($scope, LayoutScreenService, $routeParams, appConfig) {

    }]);

