"use strict";
var screenModule = angular.module('Screen', []);

screenModule.controller('ScreenController', ['$scope', 'LayoutScreenService', '$routeParams', 'appConfig',
    function ($scope, LayoutScreenService, $routeParams, appConfig) {
        //TODO:: Fixa denna fråga
        var req = LayoutScreenService.getLayout($routeParams.id);
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
                $scope.partials = sortedPartials;
            } else {
                console.log("Verkar inte få något bra svar från servern, är databasen seedad och uppe? Annars kanske inte id:et finns")
            }
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
        var layouts = LayoutScreenService.getLayouts().success(function(data){
            $scope.layouts = data;
        });
        $scope.selectLayout = function (layout) {
            $scope.layout = ($scope.layout != layout) ? layout : null;
        };
        $scope.selectPartial = function (e) {
            var partialPos = getPartialPos(e.target);
            var partial = getPartialFromPos(partialPos);
            $scope.partial = ($scope.partial != partial) ? partial : null;
        };

        var getPartialPos = function(t){
            if ($(t).hasClass('partial')) {
                return parseInt($(t).attr('id').replace('p', ''));
            }
            return 0;
        };

        var getPartialFromPos = function(pp){
            for (var i = 0; i < $scope.layout.partials.length; i++) {
                if (pp === parseInt(position)) {
                    return $scope.layout.partials[i];
                }
            }
            return null;
        };
    }]);
screenModule.controller('AdminDesignsController', ['$scope', 'LayoutScreenService', '$routeParams', 'appConfig',
    function ($scope, LayoutScreenService, $routeParams, appConfig) {

    }]);
screenModule.controller('AdminDiagramsController', ['$scope', 'LayoutScreenService', '$routeParams', 'appConfig',
    function ($scope, LayoutScreenService, $routeParams, appConfig) {

    }]);

