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

        seedOrdersFrom: function (year, month) {
            return $http.get('/diagrams/seed-orders-from/' + year + '/' + month);
        },
        //seedAllLiveOrders: function(){
        //    return $http.get('/diagrams/seed-all-live-orders/');
        //},

        seedShipmentsFrom: function (year, month) {
            return $http.get('/diagrams/seed-shipments-for/' + year + '/' + month);
        },
        //seedAllLiveShipments: function () {
        //    return $http.get('/diagrams/seed-all-live-shipments/');
        //}
    }       
}]);
