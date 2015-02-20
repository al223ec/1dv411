"use strict";
var screenModule = angular.module('Screen', []);

screenModule.controller('ScreenController', ['$scope', 'LayoutScreenService', '$routeParams', 'appConfig',
    function ($scope, LayoutScreenService, $routeParams, appConfig) {
        //TODO:: Fixa denna fråga
        LayoutScreenService.getPagesWithScreenId($routeParams.id).success(function(data){
            $scope.pages = data;
            //
        });
        LayoutScreenService.getScreen($routeParams.id)
            .error(function (data, status, headers, config) {

            })
            .success(function (data, status, headers, config) {
                if (data) { //I dagsläget returnerar servern en 200 även om id inte finns i databasen men data är däremot null
                    $scope.screen = data;
                    /*
                    var templateName = data.templateUrl == null ? "default_template" : data.templateUrl;
                    $scope.templateUrl = appConfig.templateUrlRoot + templateName + ".html";

                    var partials = data.partials;
                    var sortedPartials = [];

                    for (var i = 0; i < partials.length; i++) {
                        sortedPartials[partials[i].position] = partials[i]; 
                    }
                    $scope.partials = sortedPartials;
                    */
                } else {
                    console.log("Verkar inte få något bra svar från servern, är databasen seedad och uppe? Annars kanske inte id:et finns")
                }
            });
       }]);

