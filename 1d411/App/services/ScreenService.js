"use strict";

angular.module('ScreenService', []).factory('ScreenService', ['$http', function ($http) {
    return {
        getScreen: function () {
            return $http.get('/screenlayout/find');
        },
        getLayout: function (id) {
            return $http.get('/screenlayout/layout/');
        },
    }; 
}]);
