"use strict";

var adminModule = angular.module('AdminScreens', []);

adminModule.controller('AdminScreensController', ['$scope', 'LayoutScreenService', '$routeParams', 'appConfig',
    function ($scope, LayoutScreenService, $routeParams, appConfig) {

        $('#screen-list-loading').show();
        var screens = LayoutScreenService.getScreens().success(function (data) {
            $scope.screens = data;
            $('#screen-list-loading').hide();
        });

        var resetCreateScreenForm = function () {
            $scope.newScreen = {
                name: '',
                timer: ''
            };
        };

        var screen = {};

        $scope.postScreen = function (screenObj, form) {
            $('.admin-message').hide().html('').removeClass('warning');//hide messages
            if (!form.$valid) {
                $('.admin-message').html('Form contains errors').addClass('warning').show();
            }
            else {
                screen.name = screenObj.name;
                // Convert minutes and seconds to milliseconds.
                screen.timer = 1000 * ((screenObj.minutes * 60) + (screenObj.seconds));
                LayoutScreenService.postScreen(screen).success(function (resp) {
                    resetCreateScreenForm();
                    $scope.screens.push(resp);
                    $('.admin-message').html('Screen saved!').show();
                });
            }
        };

        $scope.selectScreen = function (screen) {
            $('.admin-message').hide().html('').removeClass('warning');//hide messages
            $scope.newScreen = null; //Hide new if present
            $scope.screen = ($scope.screen != screen) ? screen : null;
            if ($scope.screen === null) {
                $scope.screenPages == null;
            }
            else{
                getScreenPages();
            }
            if($scope.pages == null){
                getPages();
            }
        };

        var getPages = function () {
            $scope.pages = null;
            $('#screen-all-pages-list-loading').show();
            LayoutScreenService.getPages().success(function (pages) {
                $scope.pages = pages;
                $('#screen-all-pages-list-loading').hide();
            });
        };

        var getScreenPages = function () {
            $('.screen-all-pages-list .light-blue').removeClass('light-blue');//remove active from all pages.
            $scope.screenPagesEmpty = false;//remove no-pages message
            $scope.screenPages = null;
            $('#screen-pages-loading').show();
            LayoutScreenService.getPagesWithScreenId($scope.screen.id).success(function (data) {
                $scope.screenPages = data === null ? [] : data;
                $scope.screenPagesEmpty = ($scope.screenPages.length == 0);//show no-pages message if empty
                $('#screen-pages-loading').hide();
                activatePagesForScreen();
            });
        };

        $scope.addPage = function (page) {
            $('#screen-all-pages-list-loading').show();//uses the same loading box as the list of all pages
            LayoutScreenService.getPagesWithScreenId($scope.screen.id).success(function (screenPages) {
                $scope.screenPagesEmpty = false;//remove no-pages message
                if (screenPages != null) {
                    for (var i = 0; i < screenPages.length; i++) {
                        if (page.id == screenPages[i].id) {
                            $('#screen-all-pages-list-loading').hide();
                            return false;
                        }
                    }
                }

                $scope.screen.pages = [page];
                LayoutScreenService.postScreen($scope.screen).success(function (resp) {
                    $scope.screenPages.push(page);
                    $('#screen-all-pages-list-loading').hide();
                    $('.screen-all-pages-list .' + page.id).addClass('light-blue');
                });
            });
        };

        var activatePagesForScreen = function () {
            if ($scope.screenPages != null) {
                for (var i = 0; i < $scope.screenPages.length; i++) {
                    for (var j = 0; j < $scope.pages.length; j++){
                        if ($scope.pages[j].id == $scope.screenPages[i].id) {
                            $('.screen-all-pages-list .' + $scope.pages[j].id).addClass('light-blue');
                        }
                    }
                }
            }
        };

        $scope.createScreen = function () {
            $scope.screen = null; //Hide selected if present
            $scope.newScreen = ($scope.newScreen != null) ? null : {};
        };

        $scope.deleteScreen = function () {
            $('.admin-message').hide().html('').removeClass('warning');//hide messages
            LayoutScreenService.deleteScreen($scope.screen.id).success(function (resp) {
                var index = $scope.screen.id;
                for (var i = 0; i < $scope.screens.length; i++) {
                    if ($scope.screens[i].id === index) {
                        $scope.screens.splice(i, 1);
                    }
                }
                $scope.screen = null;
                $('.admin-message').html('Screen deleted!').show();
            }).error(function () {
                $('.admin-message').html('Could not delete Screen.').addClass('warning').show();
            });
        };
    }]);