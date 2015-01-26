angular.module('AppService', []).factory('AppService', ['$http', function ($http) {
    return {
        getDiagramData : function(query) {
            return $http.get('/diagramData/find/' + query);
        },
    }       
}]);
