angular.module('appRoutes', ['ngRoute'])
    .config(['$routeProvider', '$locationProvider', function($routeProvider, $locationProvider) {

        $routeProvider
                .when('/', {
                    templateUrl: 'Views/App/Main/home.html',
                    controller: 'MainController'
                })
                .when('/app/screen/:id', {
                    templateUrl: 'Views/App/Screen/index.html',
                    controller: 'ScreenController'
                })
                .when('/app/admin/screens', {
                    templateUrl: 'Views/App/Admin/screens.html',
                    controller: 'AdminScreensController'
                })
                .when('/app/admin/layouts', {
                    templateUrl: 'Views/App/Admin/Layout/layouts.html',
                    controller: 'AdminLayoutController'
                })
                .when('/app/admin/designs', {
                    templateUrl: 'Views/App/Admin/designs.html',
                    controller: 'AdminDesignsController'
                })
                .when('/app/admin/diagrams', {
                    templateUrl: 'Views/App/Admin/diagrams.html',
                    controller: 'AdminDiagramsController'
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
