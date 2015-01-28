angular.module('MainCtrl', []).controller('MainController', ['$scope', 'AppService', function ($scope, AppService) {

    //$scope.data = {};

    //$scope.getDiagramData = function (query) {
    //    var request = AppService.getDiagramData(query);
    //    request.error(function (data, status, headers, config) {
    //        //Do something on failure
    //        console.log("Failure"); 
    //    });

    //    request.then(function (response) {
    //        $scope.data = response.data;
    //        console.log(response)
    //    });
    //}

    $scope.dataset = [
        {
            'day': '2013-01-02_00:00:00',
            'sales': 13461.295202,
            'income': 12365.053
        }
    ];

    $scope.schema = {
        day: {
            type: 'datetime',
            format: '%Y-%m-%d_%H:%M:%S',
            name: 'Date'
        }
    };

    $scope.options = {
        rows: [{
            key: 'income',
            type: 'bar'
        }, {
            key: 'sales'
        }],
        xAxis: {
            key: 'day',
            displayFormat: '%Y-%m-%d %H:%M:%S'
        }
    };
}]);
