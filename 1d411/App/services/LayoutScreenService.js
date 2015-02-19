"use strict";

//Denna servicen ska servera layout objekt utifrån vilken screen de tillhör
angular.module('LayoutScreenService', []).factory('LayoutScreenService', ['$http', function ($http) {
    return {        
        getScreens: function(){
            return $http.get('/screens/');
        },
        getScreen: function(id){
            return $http.get('/screens/' + id);
        },
        getLayoutsWithScreenId: function (screenId) {
            return $http.get('/screens/' + screenId + '/layouts');
        },
        getLayouts: function () {
            return $http.get('/layouts/'); 
        },
        getLayout: function (id) {
            return $http.get('/layouts/' + id); 
        },
        getAllLayoutNames: function () {
            return $http.get('/layouts/names'); 
        }
    }; 
}]);
