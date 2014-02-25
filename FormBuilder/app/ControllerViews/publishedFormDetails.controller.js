/* Defines the "about view" controller
 * Constructor function relies on Ng injector to provide:
 *     $scope - context variable for the view to which the view binds
 */
formBuilder.controller('PublishedFormDetailsCtrl',
    ['$scope', 'datacontext', '$routeParams',
    function ($scope, datacontext, $routeParams) {

        if ($routeParams.formDefinitionId) {


            var answeredForms = datacontext.getAnsweredForms().query({ formDefinitionId: $routeParams.formDefinitionId, answeredFormId: 0 }, function () {
                $scope.answeredForms = answeredForms;



            });
        }

        

    }]);