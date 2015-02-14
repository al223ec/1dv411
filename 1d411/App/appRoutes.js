angular.module('appRoutes', ['ngRoute'])
    .config(['$routeProvider', '$locationProvider', function($routeProvider, $locationProvider) {

        $routeProvider
                .when('/', {
                    templateUrl: 'Views/App/Main/home.html',
                    controller: 'MainController'
                })
                .when('/layout', {
                    templateUrl: 'Views/App/Layout/Layout.html',
                    controller: 'LayoutController'
                })
                .when('/app/screen/:id', {
                    templateUrl: 'Views/App/Screen/index.html',
                    controller: 'ScreenController'
                })
                .when('/app/testscreen/:id', {
                    templateUrl: 'Views/App/testview.html',
                    controller: 'TestScreenCtrl'
                })
                .when('/app/testLayout', {
                    templateUrl: 'Views/App/Layout/h-2.html',
                    controller: 'LayoutController'

                })
                .when('/exempel', {
                    templateUrl: 'Views/App/exempel.html',
                    controller: 'MainController'
                })
                .when('/app/monthDiagram', {
                    templateUrl: 'Views/App/Layout/diagram.html',
                    controller: 'LayoutController'
                })
                //TODO: implementera felhantering
            
                .when('/404', { 
                    templateUrl: 'views/404.html', 
                    controller: 'NotFoundErrorCtrl'
                })
                .when('/apierror', {
                    templateUrl: 'views/apierror.html',
                    controller: 'ApiErrorCtrl'
                })
                .otherwise({redirectTo: '/'});
        // to configure how the application deep linking paths are stored.
        $locationProvider.html5Mode(true);         
}]);
