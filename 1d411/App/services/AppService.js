"use strict";

var appServiceModule = angular.module('AppService', []); 

appServiceModule.factory('appService', ['$http', function ($http) {
    return {
        getDiagramData : function(query) {
            return $http.get('/diagramData/find/' + query);
        },
        getDiagramDataByWeek: function () {
            return $http.get('/diagramData/week/');
        },
        getDiagramDataByMonth: function () {
            return $http.get('/diagramData/month/');
        },
    }       
}]);
