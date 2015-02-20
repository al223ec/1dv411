"use strict";
var screenModule = angular.module('Screen', []);

screenModule.controller('ScreenController', ['$scope', 'LayoutScreenService', '$routeParams', 'appConfig', '$timeout',
    function ($scope, LayoutScreenService, $routeParams, appConfig, $timeout) {
 
        LayoutScreenService.getScreen($routeParams.id)
            .error(function (data, status, headers, config) {

            })
            .success(function (screenData, status, headers, config) {
                if (screenData) { //I dagsläget returnerar servern en 200 även om id inte finns i databasen men data är däremot null
                    $scope.screen = screenData;

                    LayoutScreenService.getPagesWithScreenId($scope.screen.id)
                        .success(function (pagesData) {
                        
                        $scope.pages = pagesData;

                        
                        var nextSlide = function (page) {
                            $scope.page = page;
                            var templateName = page.template.fileName == null ? "default_template" : page.template.fileName;
                            var templateUrl = appConfig.templateUrlRoot + templateName + ".html";
                            $scope.pageTemplate = templateUrl;

                            var sortedPartials = []; 
                            for (var i = 0; i < page.partials.length; i++) {
                                sortedPartials[page.partials[i].position] = page.partials[i];
                            }

                            $scope.partials = sortedPartials;
                        }

                        var current = 0;
                        nextSlide($scope.pages[current]);
                        var timer;
                        var sliderFunc = function () {
                            timer = $timeout(function () {
                                nextSlide($scope.pages[current]);
                                current = (current + 1 >= $scope.pages.length) ? 0 : current + 1;

                                timer = $timeout(sliderFunc, 3000);
                            }, 3000);
                        };
                        sliderFunc();

                        $scope.$on('$destroy', function () {
                            $timeout.cancel(timer);
                        });
                    });
                } else {
                    console.log("Verkar inte få något bra svar från servern, är databasen seedad och uppe? Annars kanske inte id:et finns")
                }
            });
       }]);

