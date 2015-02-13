"use strict";
var screenModlue = angular.module('Screen', []);

screenModlue.controller('ScreenController', ['$scope', 'ScreenService', '$routeParams', function ($scope, ScreenService, $routeParams) {
    var req = ScreenService.getLayoutForScreen($routeParams.id);
    req.error(function () {
    });

    req.then(function (response) {
        console.log(response.data);

        $scope.templateUrl = response.data.templateUrl; //TODO:Fixa detta på serversida, att det är riktig data
        $scope.templateUrl = "/Views/App/Templates/default_template.html";

        var partials = response.data.partials;
        var sortedPartials = []; 

        for (var i = 0; i < partials.length; i++) {
            sortedPartials[partials[i].position] = partials[i]; 
        }
        $scope.partials = sortedPartials;
    });
}]);

screenModlue.directive('partial', function ($compile) {
    // https://docs.angularjs.org/api/ng/service/$compile
    // https://github.com/simpulton/angular-dynamic-templates

    //TODO: Detta ska hämtas från partials 
    var diagramTemplate = '<div>{{partial.diagramInfo}}</div>';
    var textTemplate = '<div>{{partial.value}}</div>';
    var imageTemplate = '<div>Image template</div>';

    var getTemplate = function(contentType) {
        var template = ''
        switch(contentType) {
            case 'Diagram':
                template = diagramTemplate;
                break;
            case 'Text':
                template = textTemplate;
                break;
            case 'Image':
                template = imageTemplate;
                break;
        }

        return template;
    }

    var linker = function(scope, element, attrs) {
        element.html(getTemplate(scope.partial.partialType));
        $compile(element.contents())(scope);
    }
    return {
        restrict: "E",
        link: linker,
        scope: {
            partial:'='
        },
    };
});