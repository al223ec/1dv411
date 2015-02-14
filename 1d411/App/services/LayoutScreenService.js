"use strict";

//Denna servicen ska servera layout objekt utifrån vilken screen de tillhör
angular.module('LayoutScreenService', []).factory('LayoutScreenService', ['$http', function ($http) {
    return {
        getLayoutForScreen: function (id) {
            return $http.get('/screenlayout/layout/' + id);
        },
        getLayoutsWithScreenId: function (screenId) {
            return $http.get('/screenlayout/screen/' + screenId);
        },
        getAllLayouts: function () {
            return $http.get('/screenlayout/layouts'); 
        }
    }; 
}]);
