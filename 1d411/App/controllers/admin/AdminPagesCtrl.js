"use strict";

var adminModule = angular.module('AdminPages', []);
adminModule.controller('AdminPagesController', ['$scope', 'LayoutScreenService', '$routeParams', 'appConfig',
    function ($scope, LayoutScreenService, $routeParams, appConfig) {

        $scope.createdPageSelected = false;
        $scope.page;

        LayoutScreenService.getPages().success(function (data) {
            $scope.pages = data;
        });

        LayoutScreenService.getTemplates().success(function (data) {
            $scope.templates = data;
        });

        $scope.selectPage = function (page) {
            $scope.createdPage = null; //Hide new if present
            $scope.templatePath = '/Views/App/Templates/' + page.template.fileName;
            $scope.page = ($scope.page != page) ? page : null;
        };

        //on new page click
        $scope.createPage = function () {
            $scope.createdPageSelected = true;
            $scope.page = null; //Hide selected if present
            $('.light-blue').removeClass('light-blue');
        };

        $scope.selectPartial = function (e) {
            var partialPos = $scope.getPartialPos(e.target);
            var partial = getPartialFromPos(partialPos);

            $scope.partialPath = (partial != null) ? '/Views/App/Admin/Page/_partial_' + partial.partialType.toLowerCase() + '.html' : '';
            $scope.partial = ($scope.partial != partial) ? partial : null;
        };

        var getPartialFromPos = function (pp) {
            for (var i = 0; i < $scope.page.partials.length; i++) {
                if (pp === parseInt($scope.page.partials[i].position)) {
                    return $scope.page.partials[i];
                }
            }
            return null;
        };

        $scope.getPartialPos = function (target) {
            if ($(target).hasClass('partial')) {
                return parseInt($(target).attr('id').replace('p', ''));
            }
            return 0;
        };
    }]);




//app.controller('ChildCtrl', function ($scope, $controller) {
//    $controller('ParentCtrl', { $scope: $scope }); //This works
//});

adminModule.controller('AdminViewPageController', ['$scope', 'LayoutScreenService', '$routeParams', 'appConfig',
        function ($scope, LayoutScreenService, $routeParams, appConfig) {


    }]);
adminModule.controller('AdminCreatePagesController', ['$scope', 'LayoutScreenService', '$routeParams', 'appConfig',
        function ($scope, LayoutScreenService, $routeParams, appConfig) {
            $scope.currentPartialPos = 0;
            // $scope.currentPartialIndex = 

            $scope.savedPage = false;
            $scope.createdPage = {};

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

            $scope.setCurrentPartialPos = function (e) {
                //getPartialPos defineras i AdminPagesController
                $scope.currentPartialPos = $scope.getPartialPos(e.target);
                $(e.currentTarget).closest('div').eq(0).find('.light-blue').removeClass('light-blue');
                $(e.target).addClass('light-blue');
            };

            $scope.savePage = function () {
                LayoutScreenService.createPage($scope.createdPage).success(function (data) {
                    $scope.createdPage = null;
                    $scope.savedPage = true;
                    $scope.pages.push(data);
                });
            };
    }]);