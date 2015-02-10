"use strict";

angular.module('ScreenService', []).factory('ScreenService', ['$http', function ($http) {
    return {
        getScreen: function () {
            return $http.get('/screen/find')
        }
    }
}]);
