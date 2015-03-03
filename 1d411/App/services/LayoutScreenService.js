﻿"use strict";

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

            console.log(screen);
            return $http.post('/screens', {screen: screen, pages: screen.pages});
        },
        createPage: function (newpage, pagePartials) {
            var data = { page: newpage, partials: pagePartials }
            return $http.post('/pages', data );
        }
    }; 
}]);
