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
        getApplicationStats: function () {
            return $http.get('/diagrams/appliaction-stats/')
        },
        seedOrdersSinceLastYear: function () {
            return $http.post('/diagrams/seed-orders-since-last-year/');
        },
        seedAllLiveOrders: function(){
            return $http.post('/diagrams/seed-all-live-orders/');
        }
    }       
}]);
