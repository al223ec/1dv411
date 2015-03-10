"use strict";

var adminModule = angular.module('AdminScreens', []);

adminModule.controller('AdminScreensController', ['$scope', 'LayoutScreenService', '$routeParams', 'appConfig',
    function ($scope, LayoutScreenService, $routeParams, appConfig) {

        var screens = LayoutScreenService.getScreens().success(function (data) {
            $scope.screens = data;
        });

        var resetCreateScreenForm = function () {
            $scope.newScreen = {
                name: '',
                timer: ''
            };
        };

        var screen = {};
        $scope.postScreen = function (screenObj) {

            screen.name = screenObj.name;
            // Convert minutes and seconds to milliseconds.
            screen.timer = 1000 * ((screenObj.minutes * 60) + (screenObj.seconds));
            LayoutScreenService.postScreen(screen).success(function (resp) {
                resetCreateScreenForm();
                console.log(resp);
                $scope.screens.push(resp);
            });
        }

        $scope.selectScreen = function (screen) {
            $scope.removeScreen = false; // Hide delete screen message
            $scope.newScreen = null; //Hide new if present
            $scope.screen = ($scope.screen != screen) ? screen : null;
            if ($scope.screen === null) {
                $scope.pages = null;
                $scope.screenPages = null;
            } else {
                getPages();
                getScreenPages();
            }

        }

        var getPages = function () {
            LayoutScreenService.getPages().success(function (pages) {

                $scope.pages = pages;
                activePageForScreen($scope.pages);
            });
        }



        var getScreenPages = function () {
            console.log($scope.screen.id);
            LayoutScreenService.getPagesWithScreenId($scope.screen.id).success(function (data) {

                $scope.screenPages = data === null ? [] : data;
            });
        }


        $scope.addPage = function (page) {

            LayoutScreenService.getPagesWithScreenId($scope.screen.id).success(function (screenPages) {
                for (var i = 0; i < screenPages.length; i++) {
                    if (page.id == screenPages[i].id) {
                        return false;
                    }
                }

                $scope.screen.pages = [page];
                LayoutScreenService.postScreen($scope.screen).success(function (resp) { });

                LayoutScreenService.getPages().success(function (pages) {

                    $scope.pages = pages;
                    activePageForScreen($scope.pages);
                });

                $scope.screenPages.push(page);
            });
        }

        var activePageForScreen = function (pages) {
            LayoutScreenService.getPagesWithScreenId($scope.screen.id).success(function (screenPages) {

                for (var i = 0; i < pages.length; i++) {

                    for (var m = 0; m < screenPages.length; m++) {

                        if (pages[i].id == screenPages[m].id) {

                            var href = document.getElementsByClassName(i + 1);
                            href[0].removeAttribute('href');
                            var active = document.getElementsByClassName("template-thumb small-thumb");

                            active[i].setAttribute("class", "template-thumb small-thumb light-blue");
                        }
                    }
                }
            });
        };

        $scope.createScreen = function () {
            $scope.removeScreen = false; // Hide delete screen message
            $scope.screen = null; //Hide selected if present
            $scope.newScreen = ($scope.newScreen != null) ? null : {};
        };

        $scope.deleteScreen = function () {
            LayoutScreenService.deleteScreen($scope.screen.id).success(function (resp) {

                var index = $scope.screen.id;

                for (var i = 0; i < $scope.screens.length; i++) {

                    if ($scope.screens[i].id === index) {
                        $scope.screens.splice(i, 1);
                    }
                }
                $scope.screen = null;
                $scope.removeScreen = true; // show delete screen message
            });
        };
    }]);