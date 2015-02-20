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
                    templateUrl: 'Views/App/Admin/Screen/screens.html',
                    controller: 'AdminScreensController'
                })
                .when('/app/admin/pages', {
                    templateUrl: 'Views/App/Admin/Page/pages.html',
                    controller: 'AdminPagesController'
                })
                .when('/app/admin/templates', {
                    templateUrl: 'Views/App/Admin/Template/templates.html',
                    controller: 'AdminTemplatesController'
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
