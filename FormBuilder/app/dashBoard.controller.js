
formBuilder.controller('DashBoardCtrl',
    ['$scope', 'datacontext', 'logger',
    function ($scope, datacontext, logger) {

        $scope.formDefinitionSets = datacontext.formDefinitionSets(true).query(function () {
            datacontext.cacheFormDefinitionSet($scope.formDefinitionSets);
        });

        $scope.refresh = function() {
            $scope.formDefinitionSets = datacontext.formDefinitionSets().query();
        };

        $scope.viewFormDefinitionVersion = function(formDefinitionModel) {
            window.location = '/#newForm/' + '?formDefinitionId=' + formDefinitionModel.id;
        };
        
        
        logger.log("creating DashBoard");
        
    }]);