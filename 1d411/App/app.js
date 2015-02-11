var app = angular.module('AppName', [
	'ngRoute', 
	'ngAnimate',
	'appRoutes',
    'Main',
    'Layout',
    'Screen',
    'TestScreen',
    'chartDirectives',
    'AppService',
    'ScreenService',
    'GoogleChart',
    'ChartProvider',
    'angularChart'
]);

app.run(['$location', '$rootScope', '$log', '$route', '$http', 
    function ($location, $rootScope, $log, $route, $http) {
		/**
		$rootScope.$on('$routeChangeError', function (ev, current, previous, rejection) {
	    	if (rejection && rejection.needsAuthentication === true) {
	        	var returnUrl = $location.url();
	            $log.log('returnUrl=' + returnUrl);
	            $location.path('/login').search({ returnUrl: returnUrl });
	        }
	    });*/
}]); 

app.factory('errorInterceptor', ['$q', '$rootScope', 
    function ($q, $rootScope) {
       return {
		    'response': function(response) {
		      // do something on success
		      return response;
		    },
		    'responseError': function (rejection) {
                //do something on fail!
		   	    //408: Request Timeout 418: I'm a teapot
		       //rejection.status === 0
		      return $q.reject(rejection);
		    }
		  };
}]);

app.config(['$httpProvider', function($httpProvider) {  
    $httpProvider.interceptors.push('errorInterceptor');

    /*//Calling order 
	*	app.config()
	*	app.run()
	*	directive's compile functions (if they are found in the dom)
	*	app.controller()
	*	directive's link functions (again if found)
	*/
}]); 