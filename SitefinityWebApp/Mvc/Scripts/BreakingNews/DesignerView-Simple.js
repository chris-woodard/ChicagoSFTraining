angular.module('designer').requires.push('sfSelectors');

angular.module('designer')
    .controller('SimpleCtrl', ['$scope', 'propertyService', function ($scope, propertyService) {
        $scope.feedback.showLoadingIndicator = true;

        // Get widget properies and load them in the controller's scope
        propertyService.get()
            .then(function (data) {
                if (data) {
                    $scope.properties = propertyService.toAssociativeArray(data.Items);
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

        $scope.$watch('properties.SelectedItem.PropertyValue', function (newValue, oldValue) {
            debugger;
            if (newValue) {
                $scope.selectedItem = JSON.parse(newValue);
            }
        });

        $scope.$watch('selectedItem', function (newValue, oldValue) {
            debugger;
            if (newValue) {
                $scope.properties.SelectedItem.PropertyValue = JSON.stringify(newValue);
            }
        });


        // Build breaking news message form Date and Message widget properties
        $scope.buildBreakingNewsMessage = function () {
            $scope.properties.Message.PropertyValue = $scope.properties.Date.PropertyValue + ' : ' + $scope.properties.Title.PropertyValue;
        };
    }]);