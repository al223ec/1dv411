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
                console.log(resp);
                $scope.screens.push(resp);
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
    $scope.createdPage = null;

    LayoutScreenService.getPages().success(function (data) {
        console.log(data);
        $scope.pages = data;
    });

    LayoutScreenService.getTemplates().success(function (data) {
        console.log(data);
        data = [
                { name: "Default layout", fileName: "default_template.html"},
                { name: "Hero", fileName: "hero.html", numberOfPartials: 3 },
                { name: "Horizontal layout", fileName: "horizontal.html" }
        ];
        $scope.templates = data;
    });


    $scope.selectPage = function (page) {
        $scope.createdPage = null; //Hide new if present
        $scope.templatePath = '/Views/App/Templates/' + page.template.fileName;
        $scope.page = ($scope.page != page) ? page : null;
    };

    $scope.selectPartial = function (e) {

        var partialPos = getPartialPos(e.target);

        var partial = getPartialFromPos(partialPos);
        console.log(partial);
        $scope.partialPath = (partial != null) ? '/Views/App/Admin/Page/_partial_' + partial.partialType.toLowerCase() : '';
        $scope.partial = ($scope.partial != partial) ? partial : null;
    };

    $scope.createPartial = function (e) {

        $(e.currentTarget).closest('div').eq(0).find('.light-blue').removeClass('light-blue');

        var partialPos = getPartialPos(e.target);
        $scope.selectedDiagramType = {};
        $(e.target).addClass('light-blue');
        $scope.currentChoosedPartialPosition = partialPos;
        $scope.createdPartial[partialPos].Position = partialPos;

        console.log($scope.createdPage);

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


        $scope.createdPartial.text = $scope.createdPartial[position].Content;
    }

    $scope.checkChoosenType = function () {
        switch ($scope.createdPartial.selectedPartialType) {
            case "Text":
                $scope.createdPartial[$scope.currentChoosedPartialPosition].PartialType = $scope.createdPartial.selectedPartialType;
                $scope.choosedDiagram = false;
                $scope.choosedText = true;

                break;

            case "Diagram":
                $scope.createdPartial[$scope.currentChoosedPartialPosition].PartialType = $scope.createdPartial.selectedPartialType;
                $scope.choosedText = false;
                $scope.choosedDiagram = true;
                break;


        }
        console.log($scope.createdPage);
    }

    $scope.setChoosenDiagramType = function () {
        $scope.createdPartial[$scope.currentChoosedPartialPosition].DiagramType = $scope.createdPartial.selectedDiagramType;
        console.log($scope.createdPage);
    }

    $scope.setText = function () {
        $scope.createdPartial[$scope.currentChoosedPartialPosition].Content = $scope.createdPartial.text;
    }

    $scope.createPage = function () {
        $scope.createdPage = {};

        $scope.createdPage.Partials = [];
        $scope.createdPartial = {};
        $scope.page = null; //Hide selected if present
        $('.light-blue').removeClass('light-blue');
        console.log($scope.createdPage);
       
    };

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
            $scope.createdPartial[i] = {};
            $scope.createdPage.Partials.push($scope.createdPartial[i]);

        }

        $scope.createdPartial.selectedPartialType = null;
        $scope.createdPartial.text = null;


    };

    $scope.savePage = function (p) {
        LayoutScreenService.createPage(p);
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

adminModule.controller('AdminTemplatesController', ['LayoutScreenService', '$routeParams', 'appConfig', function (LayoutScreenService, $routeParams, appConfig) {

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
