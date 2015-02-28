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
        getPagesWithScreenId: function (screenId) {
            return $http.get('/screens/' + screenId + '/pages');
        },
        getPages: function () {
            return $http.get('/pages/');
        },
        getPage: function (id) {
            return $http.get('/pages/' + id);
        },
        getTemplates: function () {
            return $http.get('/templates/');
        },
        postScreen: function (screen) {
            return $http.post('/screens', screen);
        },
        createPage: function (page) {
            return $http.post('/pages', page);
        }
    }; 
}]);
