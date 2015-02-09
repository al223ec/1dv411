angular.module('appRoutes', ['ngRoute'])
    .config(['$routeProvider', '$locationProvider', function($routeProvider, $locationProvider) {

        $routeProvider
                .when('/', {
                    templateUrl: 'Views/App/home.html',
                    controller: 'MainController'
                })
                .when('/1dv411/exempel', {
                    templateUrl: 'Views/App/exempel.html',
                    controller: 'mainController'
                })

                .when('/test/monthDiagram', {
                    templateUrl: 'Views/App/exempel.html',
                    controller: 'mainController'
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
        $locationProvider.hashPrefix('!').html5Mode(true);
}]);
