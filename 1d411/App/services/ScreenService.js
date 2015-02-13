"use strict";

angular.module('ScreenService', []).factory('ScreenService', ['$http', function ($http) {
    return {
        getLayoutForScreen: function (id) {
            return $http.get('/screenlayout/layout/' + id);
        },
    }; 
}]);
