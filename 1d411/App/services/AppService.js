angular.module('AppService', []).factory('AppService', ['$http', function ($http) {
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
