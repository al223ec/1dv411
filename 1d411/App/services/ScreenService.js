"use strict";

//Denna servicen ska servera layout objekt utifrån vilken screen de tillhör
angular.module('ScreenService', []).factory('ScreenService', ['$http', function ($http) {
    return {
        getLayoutForScreen: function (id) {
            return $http.get('/screenlayout/layout/' + id);
        },
        getLayoutsWithScreenId: function (screenId) {
            return $http.get('/screenlayout/screen/' + screenId);
        },
    }; 
}]);
