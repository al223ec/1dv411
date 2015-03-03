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

        var screen = {};
        $scope.postScreen = function (screenObj) {

            screen.name = screenObj.name;
            // Convert minutes and seconds to milliseconds.
            screen.timer = 1000 * ((screenObj.minutes * 60) + (screenObj.seconds));
            LayoutScreenService.postScreen(screen).success(function (resp) {
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
            console.log($scope.pages);
        }

        var getScreenPages = function () {
            console.log($scope.screen.id);
            LayoutScreenService.getPagesWithScreenId($scope.screen.id).success(function (data) {

                $scope.screenPages = data === null ? [] : data;
            });
        }


        $scope.addPage = function (page) {
            $scope.screen.pages = [page];

            LayoutScreenService.postScreen($scope.screen).success(function (resp) {

                console.log(resp);
            });

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
        //This is hardcode, should get templates from the db
        data = [
                { name: "Default layout", fileName: "default_template.html", numberOfPartials: 2},
                { name: "Hero", fileName: "hero.html", numberOfPartials: 3 },
                { name: "Horizontal layout", fileName: "horizontal.html", numberOfPartials: 3 }
        ];
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

        //loop number of partials and set each partial as an object
        for (var i = 1; i <= $scope.template.numberOfPartials; i++) {
            $scope.createdPage.createdPartial[i] = {"Position": i};
            $scope.createdPage.createdPartials.push($scope.createdPage.createdPartial[i]);

        }
        console.log($scope.createdPartials);
        //delete form data
        $scope.createdPage.createdPartial.selectedPartialType = null;
        $scope.createdPage.createdPartial.text = null;


    };

    //on new page click
    $scope.createPage = function () {
        $scope.createdPage = {};
        $scope.createdPage.savedPage = false; //hide the saved page alert
        $scope.createdPage.createdPartials = [];
        $scope.createdPage.createdPartial = {};
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

        $scope.createdPage.selectedDiagramType = {};
        $scope.createdPage.createdPartial[partialPos].textContents = [];
        $scope.createdPage.currentChoosedPartialPosition = partialPos;
        console.log($scope.createdPage.createdPartial);
       
       // $scope.createdPartial[partialPos].Position = partialPos;

        console.log($scope.createdPage.createdPartials);

        $scope.createdPage.showDropdownPartitalType = true;
        $scope.createdPage.choosedDiagram = false;
        $scope.createdPage.choosedText = false;
        getCurrentNewPageData(partialPos);
    }

    var getCurrentNewPageData = function (position) {
        //delete scope data
        $scope.createdPage.createdPartial.selectedPartialType = null;
        $scope.createdPage.createdPartial.text = null;


        $scope.createdPage.createdPartial.selectedPartialType = $scope.createdPage.createdPartial[position].PartialType;
        $scope.createdPage.createdPartial.selectedDiagramType = $scope.createdPage.createdPartial[position].DiagramType;

        $scope.checkChoosenType();


        $scope.createdPage.createdPartial.text = $scope.createdPage.createdPartial[position].textContents.content;
    }

    //check choosed partialtype in new page
    $scope.checkChoosenType = function () {
        switch ($scope.createdPage.createdPartial.selectedPartialType) {
            case "Text":
                $scope.createdPage.createdPartial[$scope.createdPage.currentChoosedPartialPosition].PartialType = $scope.createdPage.createdPartial.selectedPartialType;
                $scope.createdPage.choosedDiagram = false;
                $scope.createdPage.choosedText = true;
                console.log($scope.createdPage.currentChoosedPartialPosition);
                break;

            case "Diagram":
                $scope.createdPage.createdPartial[$scope.createdPage.currentChoosedPartialPosition].PartialType = $scope.createdPage.createdPartial.selectedPartialType;
                $scope.createdPage.choosedText = false;
                $scope.createdPage.choosedDiagram = true;
                break;


        }
        console.log($scope.createdPage.createdPartials);
    }

    //on new page created partial with diagram
    $scope.setChoosenDiagramType = function () {
        $scope.createdPage.createdPartial[$scope.createdPage.currentChoosedPartialPosition].DiagramType = $scope.createdPage.createdPartial.selectedDiagramType;
        console.log($scope.createdPage);
    }

    //on new page created partial with text
    $scope.setText = function () {
        $scope.createdPage.createdPartial[$scope.createdPage.currentChoosedPartialPosition].textContents = [];
        var text = {};
        text.content = $scope.createdPage.createdPartial.text;
        text.textType = "Header";
        $scope.createdPage.createdPartial[$scope.createdPage.currentChoosedPartialPosition].textContents.push(text);
        //console.log($scope.createdPartial[$scope.currentChoosedPartialPosition]);
    }


   
    //on new page save
    $scope.savePage = function (p) {
        var newPartials = $scope.createdPage.createdPartials;
        //console.log(newPartials);
        LayoutScreenService.createPage(p, newPartials).success(function (data) {
            console.log(data);
            $scope.createdPage.savedPage = true;
            $scope.createdPage = null;
           
            $scope.pages.unshift(data);
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

adminModule.controller('AdminTemplatesController', ['$scope', 'LayoutScreenService', '$routeParams', 'appConfig', function ($scope, LayoutScreenService, $routeParams, appConfig) {

}]);
