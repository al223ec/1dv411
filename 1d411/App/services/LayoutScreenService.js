"use strict";

//Denna servicen ska servera layout objekt utifrån vilken screen de tillhör
angular.module('LayoutScreenService', []).factory('LayoutScreenService', ['$http', function ($http) {
    return {
        getLayoutForScreen: function (id) {
            return $http.get('/layouts/' + id);
        },
        getLayoutsWithScreenId: function (screenId) {
            return $http.get('/screens/layouts/' + screenId);
        },
        getScreens: function(){
            return $http.get('/screens/');
        },
        getScreen: function(id){
            return $http.get('/screens/' + id);
        },
        getAllLayouts: function () {
            return $http.get('/layouts/'); 
        },
        getAllLayoutNames: function () {
            return $http.get('/layouts/names'); 
        }
    }; 
}]);
