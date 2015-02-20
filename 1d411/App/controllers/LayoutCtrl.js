"use strict";
var LayoutModule = angular.module('Layout', []);

LayoutModule.controller('AdminLayoutController', ['$scope', 'LayoutScreenService', '$routeParams', 'appConfig', function ($scope, LayoutScreenService, $routeParams, appConfig) {
    $scope.newLayout = null;

    LayoutScreenService.getLayouts().success(function (data) {
        $scope.layouts = data;
    });
    LayoutScreenService.getAllLayoutNames().success(function (data) {
        //Ingen riktig data
        data = [
            { name: "Default layout", fileName: "default_template.html" },
            { name: "Hero", fileName: "hero.html" },
            { name: "Horizontal layout", fileName: "horizontal.html" }
        ];
        $scope.templates = data;
    });

    $scope.selectLayout = function (layout) {
        $scope.newLayout = null; //Hide new if present
        $scope.templatePath = '/Views/App/Templates/' + layout.templateUrl + '.html';
        $scope.layout = ($scope.layout != layout) ? layout : null;
    };

    $scope.selectPartial = function (e) {
        var partialPos = getPartialPos(e.target);
        var partial = getPartialFromPos(partialPos);
        $scope.partialPath = (partial != null) ? '/Views/App/Admin/Layout/_partial_' + partial.partialType.toLowerCase() + '.html' : '';
        $scope.partial = ($scope.partial != partial) ? partial : null;
    };

    $scope.createLayout = function() {
        $scope.layout = null; //Hide selected if present
        $scope.newLayout = ($scope.newLayout != null) ? null : {};
    };

    $scope.selectTemplate = function (e, t) {
        $(e.currentTarget).closest('ul').eq(0).find('.light-blue').removeClass('light-blue');
        if (!$(e.currentTarget).hasClass('light-blue')) {
            $(e.currentTarget).addClass('light-blue');
        }
        $scope.newLayout.template = t.name;
    };

    $scope.saveLayout = function (l) {
        console.log(l);
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