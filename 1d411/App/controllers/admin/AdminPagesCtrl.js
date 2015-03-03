"use strict";

var adminModule = angular.module('AdminPages', []);

adminModule.controller('AdminPagesController', ['$scope', 'LayoutScreenService', '$routeParams', 'appConfig',
    function ($scope, LayoutScreenService, $routeParams, appConfig) {
        $scope.createdPage = null;
        $scope.currentPartialPos = 0; 

        LayoutScreenService.getPages().success(function (data) {
            $scope.pages = data;
        });

        LayoutScreenService.getTemplates().success(function (data) {
            $scope.templates = data;
        });

        $scope.selectPage = function (page) {
            $scope.savedPage = false; //hide the saved page alert
            $scope.createdPage = null; //Hide new if present
            $scope.templatePath = '/Views/App/Templates/' + page.template.fileName;
            $scope.page = ($scope.page != page) ? page : null;
        };

        $scope.selectTemplate = function (e, t) {
            $(e.currentTarget).closest('ul').eq(0).find('.light-blue').removeClass('light-blue');
            if (!$(e.currentTarget).hasClass('light-blue')) {
                $(e.currentTarget).addClass('light-blue');
            }
            $scope.createdPage.template = t;
            $scope.path = '/Views/App/Templates/' + t.fileName;

            $scope.createdPage.partials = [];
            for (var i = 1; i <= t.numberOfPartials; i++) {
                $scope.createdPage.partials.push({ position: i });
            }
        };

        //on new page click
        $scope.createPage = function () {
            $scope.savedPage = false; //hide the saved page alert
            $scope.createdPage = {};
            $scope.createdPartials = [];
            $scope.createdPartial = {};
            $scope.page = null; //Hide selected if present
            $('.light-blue').removeClass('light-blue');
        };

        $scope.selectPartial = function (e) {
            var partialPos = getPartialPos(e.target);
            var partial = getPartialFromPos(partialPos);

            $scope.partialPath = (partial != null) ? '/Views/App/Admin/Page/_partial_' + partial.partialType.toLowerCase() + '.html' : '';
            $scope.partial = ($scope.partial != partial) ? partial : null;
        };

        $scope.setCurrentPartialPos = function (e) {
            //partials m
            $scope.currentPartialPos = getPartialPos(e.target);

            //set color of selected partial
            $(e.currentTarget).closest('div').eq(0).find('.light-blue').removeClass('light-blue');
            $(e.target).addClass('light-blue');
        }
        //on new page save
        $scope.savePage = function () {
            console.log($scope.createdPage);
            
            LayoutScreenService.createPage($scope.createdPage).success(function (data) {
                console.log(data);
                $scope.createdPage = null;
                $scope.savedPage = true;
                $scope.pages.push(data);
            }); 
        };

        var getPartialPos = function (target) {
            if ($(target).hasClass('partial')) {
                return parseInt($(target).attr('id').replace('p', ''));
            }
            return 0;
        };

        var getPartialFromPos = function (pp) {
            for (var i = 0; i < $scope.page.partials.length; i++) {
                if (pp === parseInt($scope.page.partials[i].position)) {
                    return $scope.page.partials[i];
                }
            }
            return null;
        };
    }]);