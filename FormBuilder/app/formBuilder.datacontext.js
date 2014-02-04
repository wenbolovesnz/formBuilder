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

        function cacheFormDefinitionSet(data) {
            formDefinitionSet = data;
        }

        function saveEntity(parameters) {
            
        }

        return {
            cacheFormDefinitionSet:cacheFormDefinitionSet,
            formDefinitionSets: formDefinitionSets,
            saveEntity: saveEntity
        };

    }]);