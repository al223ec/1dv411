"use strict";

var adminModule = angular.module('AdminTemplates', []);
adminModule.controller('AdminTemplatesController', ['$scope', 'LayoutScreenService', '$routeParams', 'appConfig',
    function ($scope, LayoutScreenService, $routeParams, appConfig) {

        var vm = this;

        LayoutScreenService.getTemplates().success(function (data) {

            vm.templates = data;
        });

        vm.validateTemplateName = function (name) {

            vm.templates.filter(function (template) {

                console.log(!name === template.name);
            });
        };

        vm.postTemplate = function (template, form) {

            console.log(template);
            form.$setPristine();
        };
}]);
