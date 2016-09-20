// SitefinityWebapp\Mvc\Scripts\BreakingNews\DesignerView-Fancy.js

angular.module('designer')
    .controller('SimpleCtrl', ['$scope', 'propertyService', function ($scope, propertyService) {
        $scope.feedback.showLoadingIndicator = true;

        // Get widget properies and load them in the controller's scope
        propertyService.get()
            .then(function (data) {
                if (data) {
                    $scope.properties = propertyService.toAssociativeArray(data.Items);

                    if ($scope.properties.StartTime.PropertyValue && !($scope.properties.StartTime.PropertyValue instanceof Date)) {
                        var startDate = $scope.properties.StartTime.PropertyValue;
                        // This parsing is specific for UK dates. It may be different depending on your website culture.
                        // Dealing with dates is always a complex matter in the programming :)
                        $scope.properties.StartTime.PropertyValue = new Date(startDate.split('/')[2], startDate.split('/')[1] - 1, startDate.split('/')[0]);
                    }

                    if ($scope.properties.EndTime.PropertyValue && !($scope.properties.EndTime.PropertyValue instanceof Date)) {
                        var endDate = $scope.properties.EndTime.PropertyValue;
                        $scope.properties.EndTime.PropertyValue = new Date(endDate.split('/')[2], endDate.split('/')[1] - 1, endDate.split('/')[0]);
                    }
                }
            }, function (data) {
                $scope.feedback.showError = true;

                if (data) {
                    $scope.feedback.errorMessage = data.Detail;
                }
            })
            .finally(function () {
                $scope.feedback.showLoadingIndicator = false;
            });

        // Build breaking news message form Date and Message widget properties
        $scope.buildBreakingNewsMessage = function () {
            $scope.properties.Message.PropertyValue = $scope.properties.Date.PropertyValue + ' : ' + $scope.properties.Title.PropertyValue;
        };
    }]);