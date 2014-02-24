/* datacontext: data access and model management layer */

// create and add datacontext to the Ng injector
// constructor function relies on Ng injector
// to provide service dependencies
formBuilder.factory('datacontext',
    ['Q', '$resource',
    function (Q, $resource) {
        var formDefinitionSet;
        
        function formDefinitionSets(force) {
            if (force) {
                return $resource('api/FormDefinitionSets', {}, {
                    query: { method: 'GET', isArray: true }
                });
            } else {
                return formDefinitionSet;
            }           
        }
        
        function getFormDefinitionById() {
            
                return $resource('api/FormDefinitions', {id: '@formDefinitionId'}, {
                    query: { method: 'GET' }
                });
            
        }
        
        function getPublishedFormDefinition() {

            return $resource('api/FormDefinitions', { orgId: '@orgId', formName: '@formName' }, {
                query: { method: 'GET' }
            });

        }

        function cacheFormDefinitionSet(data) {
            formDefinitionSet = data;
        }

        function saveFormDefinition() {
            return $resource('api/FormDefinitions', {},
            {
                create: { method: 'POST'}
            });
        }

        return {
            cacheFormDefinitionSet:cacheFormDefinitionSet,
            formDefinitionSets: formDefinitionSets,
            saveFormDefinition: saveFormDefinition,
            getFormDefinitionById: getFormDefinitionById,
            getPublishedFormDefinition: getPublishedFormDefinition
        };

    }]);