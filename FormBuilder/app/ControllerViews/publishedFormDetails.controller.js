/* Defines the "about view" controller
 * Constructor function relies on Ng injector to provide:
 *     $scope - context variable for the view to which the view binds
 */
formBuilder.controller('PublishedFormDetailsCtrl',
    ['$scope', 'datacontext', '$routeParams', '$resource', function ($scope, datacontext, $routeParams, $resource) {

        if ($routeParams.formDefinitionId) {
            var answeredForms = datacontext.getAnsweredForms().query({ formDefinitionId: $routeParams.formDefinitionId, answeredFormId: 0 }, function () {
                $scope.answeredForms = answeredForms;
            });
        }

        var FormDefinitionSets = $resource('api/FormDefinitionSets', {}, {
            query: { method: 'GET', isArray: true }
        });

        $scope.formDefinitionSets = FormDefinitionSets.query({}, function(results){
            $scope.orgId = $scope.formDefinitionSets[0].organizationModel.id;
            angular.forEach($scope.formDefinitionSets, function (formDefinitionSet, index) {
                angular.forEach(formDefinitionSet.formDefinitionModels, function (formDefinition, index) {
                    if (formDefinition.id == $routeParams.formDefinitionId) {
                        $scope.formDefinition = formDefinition;
                        $scope.accessUrl = window.location.origin + "/myform/" + $scope.orgId + "/" + $scope.formDefinition.name;
                    }
                });
            });
        });

        
        $scope.getAnsweredForm = function (id) {
            return '#/answeredForm/'+ id;
        };

        

    }]);