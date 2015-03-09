"use strict";

//Detta är egentligen bara en meny
var adminModule = angular.module('AdminPages', []);
adminModule.controller('AdminPagesController', ['$scope', 'LayoutScreenService', '$routeParams', 'appConfig',
    function ($scope, LayoutScreenService, $routeParams, appConfig) {

        $scope.createdPageSelected = false;
        $scope.page; // om man vill visa en eskild page visas denna här

        LayoutScreenService.getPages().success(function (data) {
            $scope.pages = data;
        });

        LayoutScreenService.getTemplates().success(function (data) {
            $scope.templates = data;
        });

        $scope.selectPage = function (page) {
            $scope.createdPageSelected = false;
            $scope.templatePath = '/Views/App/Templates/' + page.template.fileName;
            $scope.page = ($scope.page != page) ? page : null;
        };

        //on new page click
        $scope.createPage = function () {
            $scope.createdPageSelected = true;
            $scope.page = null; //Hide selected if present
           // $('.light-blue').removeClass('light-blue'); oklart om denna behövs
        };
    }]);

// Visa en enskild page
adminModule.controller('AdminViewPageController', ['$scope', 'LayoutScreenService', '$routeParams', 'appConfig',
        function ($scope, LayoutScreenService, $routeParams, appConfig) {
            $scope.selectPartial = function (position) {
                var partial = getPartialFromPos(position);

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
        }]);


// Skapa en ny page
adminModule.controller('AdminCreatePagesController', ['$scope', 'LayoutScreenService', '$routeParams', 'appConfig',
        function ($scope, LayoutScreenService, $routeParams, appConfig) {
            $scope.currentPartialPos = 0; //Detta är ej nollindex

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

            $scope.setCurrentPartialPos = function (position) {
                $scope.currentPartialPos = position; 
            };


            $scope.savePage = function () {
                //sets the path to the choosed image. maybe should to this on the serverside instead
                $scope.createdPage.partials[$scope.currentPartialPos - 1].url = 'Views/App/Partials/Images/' + $scope.createdPage.partials[$scope.currentPartialPos - 1].url;
                LayoutScreenService.createPage($scope.createdPage).success(function (data) {
                    $scope.createdPage = null;
                    $scope.savedPage = true;
                    $scope.pages.unshift(data);
                });
            };
        }]);


adminModule.controller('AdminRemovePagesController', ['$scope', 'LayoutScreenService',
    function ($scope, LayoutScreenService) {
        $scope.removePage = function (pageId) {
            LayoutScreenService.deletePage(pageId);
           
            for (var i = 0; i < $scope.pages.length; i++) {

                if ($scope.pages[i].id === pageId) {
                    $scope.screens.splice(i, 1);
                }
            }
        }
        
    }]);


//Detta direktiv används för att ta fram vilken position en viss partial bör läggas i en egen fil vid tillfälle
adminModule.directive("myPositionFinder", [
      function () {

          var getPartialPos = function (target) {
              if ($(target).hasClass('partial')) {
                  return parseInt($(target).attr('id').replace('p', ''));
              }
              return 0;
          };

          return {
              restrict: "A",
              link: function (scope, element, attrs) {
                  scope.calculateParitalPos = function (e, callback) {
                      $(e.currentTarget).closest('div').eq(0).find('.light-blue').removeClass('light-blue');
                      $(e.target).addClass('light-blue');
                      callback(getPartialPos(e.target));
                  };
              }
          };


      }
]);