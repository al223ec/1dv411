"use strict";

angular.module('ScreenService', []).factory('ScreenService', ['$http', function ($http) {
    return {
        getScreen: function () {
            return $http.get('/screenlayout/find');
        },
        getLayoutForScreen: function (id) {
            return $http.get('/screenlayout/layout/');
        },
    }; 
}]);
