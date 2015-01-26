angular.module('MainCtrl', []).controller('MainController', ['$scope', 'AppService', function ($scope, AppService) {

    $scope.data = {};

    $scope.getDiagramData = function (query) {
        var request = AppService.getDiagramData(query);
        request.error(function (data, status, headers, config) {
            //Do something on failure
            console.log("Failure"); 
        });

        request.then(function (response) {
            $scope.data = response.data;
            console.log(response)
        });
    }
}]);
