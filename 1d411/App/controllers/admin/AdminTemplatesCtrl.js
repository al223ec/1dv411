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
            $('.admin-message').hide().html('').removeClass('warning');
            if (!form.$valid) {
                $('.admin-message').html('Form contains errors.')
                .addClass('warning')
                .show();
            }
            else {
                form.$setPristine();
                $('#submit-template-loading').show();
                LayoutScreenService.postTemplate(template).success(function (resp) {
                    vm.resetCreateTemplateForm(template);
                    vm.templates.push(resp);
                    $('#submit-template-loading').hide();
                    $('.admin-message').html('Template saved!').show();
                });
            }
        };
}]);
