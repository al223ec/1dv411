"use strict";

var screenModule = angular.module('Admin', [])

screenModule.controller('AdminScreensController', ['$scope', 'LayoutScreenService', '$routeParams', 'appConfig',
    function ($scope, LayoutScreenService, $routeParams, appConfig) {
        var screens = LayoutScreenService.getScreens().success(function (data) {
            $scope.screens = data;
            console.log($scope.screens);
        });


        $scope.selectScreen = function (screen) {
            $scope.s = ($scope.s != screen) ? screen : null;
            if ($scope.s === null) {
                $scope.layouts = null;
                $scope.screenLayouts = null;
            } else {
                getLayouts();
                getScreenLayouts();
            }

        }

        var getLayouts = function () {

            LayoutScreenService.getLayouts().success(function (data) {
                $scope.layouts = data;
            });
        }

        var getScreenLayouts = function () {
            LayoutScreenService.getLayoutsWithScreenId($scope.s.id).success(function (data) {
                console.log(data);
                $scope.screenLayouts = data;
            })

        }

        $scope.addLayout = function (layout) {
            $scope.screenLayouts.push(layout);
            //should call the api to add the layout
        }
    }]);
screenModule.controller('AdminLayoutsController', ['$scope', 'LayoutScreenService', '$routeParams', 'appConfig',
    function ($scope, LayoutScreenService, $routeParams, appConfig) {

        var layouts = LayoutScreenService.getLayouts().success(function (data) {
            $scope.layouts = data;
        });
        $scope.selectLayout = function (layout) {
            $scope.templatePath = '/Views/App/Templates/' + layout.templateUrl + '.html';
            $scope.layout = ($scope.layout != layout) ? layout : null;
        };
        $scope.selectPartial = function (e) {
            var partialPos = getPartialPos(e.target);
            var partial = getPartialFromPos(partialPos);
            $scope.partial = ($scope.partial != partial) ? partial : null;
        };

        var getPartialPos = function (t) {
            if ($(t).hasClass('partial')) {
                return parseInt($(t).attr('id').replace('p', ''));
            }
            return 0;
        };

        var getPartialFromPos = function (pp) {
            for (var i = 0; i < $scope.layout.partials.length; i++) {
                if (pp === parseInt($scope.layout.partials[i].position)) {
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

