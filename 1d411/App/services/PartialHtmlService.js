angular.module('PartialHtmlService', []).factory('PartialHtmlService', ['$http', function ($http) {
    return {
        getPartialHtml: function (partialName) {
            return $http.get('Views/App/Partials/_' + partialName + '.html');
        }
    }
}]);
