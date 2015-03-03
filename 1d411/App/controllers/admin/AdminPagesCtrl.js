﻿"use strict";

var adminModule = angular.module('AdminPages', []);

adminModule.controller('AdminPagesController', ['$scope', 'LayoutScreenService', '$routeParams', 'appConfig',
    function ($scope, LayoutScreenService, $routeParams, appConfig) {
        $scope.createdPage = null;

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

        $scope.selectPartial = function (e) {

            var partialPos = getPartialPos(e.target);

            var partial = getPartialFromPos(partialPos);
            console.log(partial);
            $scope.partialPath = (partial != null) ? '/Views/App/Admin/Page/_partial_' + partial.partialType.toLowerCase() + '.html' : '';
            $scope.partial = ($scope.partial != partial) ? partial : null;
        };

        //on new page template click
        $scope.selectTemplate = function (e, t) {
            $(e.currentTarget).closest('ul').eq(0).find('.light-blue').removeClass('light-blue');
            if (!$(e.currentTarget).hasClass('light-blue')) {
                $(e.currentTarget).addClass('light-blue');
            }
            $scope.createdPage.Template = {};
            $scope.createdPage.Template.FileName = t.fileName;
            $scope.createdPage.Template.Name = t.name;
            $scope.template = t;
            $scope.path = '/Views/App/Templates/' + t.fileName;

            for (var i = 1; i <= $scope.template.numberOfPartials; i++) {
                $scope.createdPartial[i] = { "Position": i };
                $scope.createdPartials.push($scope.createdPartial[i]);

            }
            console.log($scope.createdPartials);
            //delete form data
            $scope.createdPartial.selectedPartialType = null;
            $scope.createdPartial.text = null;


        };

        //on new page click
        $scope.createPage = function () {
            $scope.savedPage = false; //hide the saved page alert
            $scope.createdPage = {};
            $scope.createdPartials = [];
            $scope.createdPartial = {};
            $scope.page = null; //Hide selected if present
            $('.light-blue').removeClass('light-blue');
            // console.log($scope.createdPage);

        };

        //on partial click
        $scope.createPartial = function (e) {
            //alert("create");
            var partialPos = getPartialPos(e.target);

            //set color of selected partial
            $(e.currentTarget).closest('div').eq(0).find('.light-blue').removeClass('light-blue');
            $(e.target).addClass('light-blue');

            $scope.selectedDiagramType = {};
            $scope.currentChoosedPartialPosition = partialPos;
            console.log($scope.createdPartial);

            // $scope.createdPartial[partialPos].Position = partialPos;

            console.log($scope.createdPartials);

            $scope.showDropdownPartitalType = true;
            $scope.choosedDiagram = false;
            $scope.choosedText = false;
            getCurrentNewPageData(partialPos);
        }

        var getCurrentNewPageData = function (position) {
            //delete scope data
            $scope.createdPartial.selectedPartialType = null;
            $scope.createdPartial.text = null;


            $scope.createdPartial.selectedPartialType = $scope.createdPartial[position].PartialType;
            $scope.createdPartial.selectedDiagramType = $scope.createdPartial[position].DiagramType;

            $scope.checkChoosenType();


            $scope.createdPartial.text = $scope.createdPartial[position].textContents.content;
        }

        //check choosed partialtype in new page
        $scope.checkChoosenType = function () {
            switch ($scope.createdPartial.selectedPartialType) {
                case "Text":
                    $scope.createdPartial[$scope.currentChoosedPartialPosition].PartialType = $scope.createdPartial.selectedPartialType;
                    $scope.choosedDiagram = false;
                    $scope.choosedText = true;
                    console.log($scope.currentChoosedPartialPosition);
                    break;

                case "Diagram":
                    $scope.createdPartial[$scope.currentChoosedPartialPosition].PartialType = $scope.createdPartial.selectedPartialType;
                    $scope.choosedText = false;
                    $scope.choosedDiagram = true;
                    break;


            }
            console.log($scope.createdPartials);
        }

        //on new page created partial with diagram
        $scope.setChoosenDiagramType = function () {
            $scope.createdPartial[$scope.currentChoosedPartialPosition].DiagramType = $scope.createdPartial.selectedDiagramType;
            console.log($scope.createdPage);
        }

        //on new page created partial with text
        $scope.setText = function () {
            $scope.createdPartial[$scope.currentChoosedPartialPosition].textContents = [];
            var text = {};
            text.content = $scope.createdPartial.text;
            text.textType = "Header";
            $scope.createdPartial[$scope.currentChoosedPartialPosition].textContents.push(text);
            //console.log($scope.createdPartial[$scope.currentChoosedPartialPosition]);
        }



        //on new page save
        $scope.savePage = function (p) {
            var newPartials = $scope.createdPartials;
            //console.log(newPartials);
            LayoutScreenService.createPage(p, newPartials).success(function (data) {
                console.log(data);
                $scope.createdPage = null;
                $scope.savedPage = true;
                $scope.pages.push(data);
            })
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