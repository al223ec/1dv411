"use strict";

var adminModule = angular.module('Admin', [])

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

        $scope.postScreen = function (screen) {
            console.log(screen);
            console.log(LayoutScreenService);
            var screen = LayoutScreenService.postScreen(screen).success(function (resp) {
                resetCreateScreenForm();
            });
        }

        $scope.selectScreen = function (screen) {
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
            LayoutScreenService.getPages().success(function (data) {
                $scope.pages = data;
            });
        }

        var getScreenPages = function () {
            LayoutScreenService.getPagesWithScreenId($scope.screen.id).success(function (data) {
                $scope.screenPages = data;
            })
        }

        $scope.addPage = function (page) {
            $scope.screenPages.push(page);
        }

        $scope.createScreen = function () {
            $scope.screen = null; //Hide selected if present
            $scope.newScreen = ($scope.newScreen != null) ? null : {};
        };
    }]);

adminModule.controller('AdminPagesController', ['$scope', 'LayoutScreenService', '$routeParams', 'appConfig', function ($scope, LayoutScreenService, $routeParams, appConfig) {
    $scope.newPage = null;

    LayoutScreenService.getPages().success(function (data) {
        console.log(data);
        $scope.pages = data;
    });
    
    LayoutScreenService.getTemplates().success(function (data) {
        data = [
                { name: "Default layout", fileName: "default_template.html" },
                { name: "Hero", fileName: "hero.html" },
                { name: "Horizontal layout", fileName: "horizontal.html" }
        ];
        $scope.templates = data;
    });
    

    $scope.selectPage = function (page) {
        $scope.newPage = null; //Hide new if present
        $scope.templatePath = '/Views/App/Templates/' + page.template.fileName + '.html';
        $scope.page = ($scope.page != page) ? page : null;
    };

    $scope.selectPartial = function (e) {
        var partialPos = getPartialPos(e.target);
        var partial = getPartialFromPos(partialPos);
        $scope.partialPath = (partial != null) ? '/Views/App/Admin/Page/_partial_' + partial.partialType.toLowerCase() + '.html' : '';
        $scope.partial = ($scope.partial != partial) ? partial : null;
    };

    $scope.createPage = function () {
        $scope.page = null; //Hide selected if present
        $('.light-blue').removeClass('light-blue');
        $scope.newPage = ($scope.newPage != null) ? null : {};
    };

    $scope.selectTemplate = function (e, t) {
        $(e.currentTarget).closest('ul').eq(0).find('.light-blue').removeClass('light-blue');
        if (!$(e.currentTarget).hasClass('light-blue')) {
            $(e.currentTarget).addClass('light-blue');
        }
        $scope.newPage.template = t.name;
    };

    $scope.savePage = function (p) {
        console.log(p);
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

adminModule.controller('AdminTemplatesController', ['$scope', 'LayoutScreenService', '$routeParams', 'appConfig',function ($scope, LayoutScreenService, $routeParams, appConfig) {

}]);
