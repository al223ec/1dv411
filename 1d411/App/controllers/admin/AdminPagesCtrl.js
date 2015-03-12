"use strict";

//Detta är egentligen bara en meny
var adminModule = angular.module('AdminPages', []);
adminModule.controller('AdminPagesController', ['$scope', 'LayoutScreenService', '$routeParams', 'appConfig',
    function ($scope, LayoutScreenService, $routeParams, appConfig) {

        $scope.newPage = null;//ej nödvändigt?
        $scope.page = null;//ej nödvändigt?

        $('#page-list-loading').show();
        LayoutScreenService.getPages().success(function (data) {
            $scope.pages = data;
            $('#page-list-loading').hide();
        });

        $('#template-list-loading').show();
        LayoutScreenService.getTemplates().success(function (data) {
            $scope.templates = data;
            $('#template-list-loading').hide();
        });

        $scope.showPage = function (page) {
            $('.admin-message').hide().html('').removeClass('warning');//hide messages
            $scope.newPage = null;
            $scope.page = ($scope.page != page) ? page : null;
            $scope.pageTemplatePath = '/Views/App/Templates/' + page.template.fileName;
        };

        $scope.showCreate = function () {
            $('.admin-message').hide().html('').removeClass('warning');//hide messages
            $scope.page = null; //Hide selected if present
            $scope.newPage = ($scope.newPage != null) ? null : {};
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

            $scope.selectTemplate = function (e, t) {
                $scope.newPage.template = t;

                $(e.currentTarget).closest('ul').eq(0).find('.light-blue').removeClass('light-blue');
                if (!$(e.currentTarget).hasClass('light-blue')) {
                    $(e.currentTarget).addClass('light-blue');
                }
                $scope.newPageTemplatePath = '/Views/App/Templates/' + t.fileName;
                $scope.newPage.partials = [];
                for (var i = 1; i <= t.numberOfPartials; i++) {
                    $scope.newPage.partials.push({ position: i });
                }
            };

            $scope.setCurrentPartialPos = function (position) {
                $scope.currentPartialPos = position; 
            };

            $scope.createPage = function () {
                $('#create-page-loading').show();
                $('.admin-message').hide().html('').removeClass('warning');//hide messages
                //FIXA...
                //sets the path to the choosed image. maybe should to this on the serverside instead
                //$scope.newPage.partials[$scope.currentPartialPos - 1].url = $scope.newPage.partials[$scope.currentPartialPos - 1].url;
                LayoutScreenService.createPage($scope.newPage).success(function (data) {
                    console.log($scope);
                    $scope.newPage = null;
                    $scope.pages.unshift(data);
                    $scope.currentPartialPos = 0;
                    $('.admin-message').html('Page created!').show();
                    $('#create-page-loading').hide();
                }).error(function () {
                    $('.admin-message').html('Could not create Page.').addClass('warning').show();
                });
            };
        }]);


adminModule.controller('AdminRemovePagesController', ['$scope', 'LayoutScreenService',
    function ($scope, LayoutScreenService) {
        $scope.deletePage = function () {
            $('.admin-message').hide().html('').removeClass('warning');//hide messages

            LayoutScreenService.deletePage($scope.page.id).success(function () {
                for (var i = 0; i < $scope.pages.length; i++) {
                    if ($scope.pages[i].id === $scope.page.id){
                        $scope.pages.splice(i, 1);
                    }
                }
                $scope.page = null;
                $('.admin-message').html('Page deleted!').show();
            }).error(function () {
                $('.admin-message').html('Could not delete Page.').addClass('warning').show();
            });
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