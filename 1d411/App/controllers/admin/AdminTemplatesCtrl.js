"use strict";

var adminModule = angular.module('AdminTemplates', []);
adminModule.controller('AdminTemplatesController', ['$scope', 'LayoutScreenService', '$routeParams', 'appConfig',
    function ($scope, LayoutScreenService, $routeParams, appConfig) {

        var vm = this;
        vm.templates = [];

        LayoutScreenService.getTemplates().success(function (data) {

            vm.templates = data;
        });

        vm.resetCreateTemplateForm = function (template) {

            template.name = '';
            template.fileName = '';
            template.numberOfPartials = '';
        };

        vm.postTemplate = function (template, form) {

            form.$setPristine();

            LayoutScreenService.postTemplate(template).success(function (resp) {

                vm.resetCreateTemplateForm(template);
                console.log(resp);
                vm.templates.push(resp);

            });
        };
}]);
