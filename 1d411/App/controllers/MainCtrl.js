angular.module('Main', [])
    .controller('MainController', ['$scope', 'AppService', function ($scope, AppService) {

        this.dataset = {};
        this.schema = {};
        this.options = {};
        $scope.diagramData = {};
        //$scope.data = {};

        $scope.getDiagramData = function () {
            var request = AppService.getDiagramDataByWeek();
            request.error(function (data, status, headers, config) {
                //Do something on failure
                console.log("Failure"); 
            });

            request.then(function (response) {
                $scope.data = response.data;
                console.log(response)
            });
        }


        this.dataset = [
            {
                'day': '2013-01-02_00:00:00',
                'sales': 13461.295202,
                'income': 12365.053
            }
        ];

        this.schema = {
            day: {
                type: 'datetime',
                format: '%Y-%m-%d_%H:%M:%S',
                name: 'Date'
            }
        };

        this.options = {
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
