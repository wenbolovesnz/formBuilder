
formBuilder.controller('DashBoardCtrl',
    ['$scope', 'datacontext',
    function ($scope, datacontext) {

        $scope.publishedForms = [];
        
        $scope.formDefinitionSets = datacontext.formDefinitionSets(true).query(function () {
            datacontext.cacheFormDefinitionSet($scope.formDefinitionSets);

            angular.forEach($scope.formDefinitionSets, function (formDefinitionSet, index) {
                angular.forEach(formDefinitionSet.formDefinitionModels, function (formDefinition, index) {
                    if (formDefinition.isPublished == true) {
                        $scope.publishedForms.push(formDefinition);
                        formDefinitionSet.formDefinitionModels.splice(index, 0);
                    }
                });
            });

        });

        $scope.refresh = function() {
            $scope.formDefinitionSets = datacontext.formDefinitionSets().query();
        };

        $scope.publish = function(id) {
            datacontext.publishFormDefinition().publish({ id: id });

        };
        $scope.viewFormDefinitionVersion = function(formDefinitionModel) {
            window.location = '/#newForm/' + '?formDefinitionId=' + formDefinitionModel.id;
        };

        $scope.viewPublishedFormDetails = function(formDefinitionId) {
            window.location = '/#publishedFormDetails/' + '?formDefinitionId=' + formDefinitionId;
        };        
        
        
    }]);