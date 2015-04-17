/* datacontext: data access and model management layer */

// create and add datacontext to the Ng injector
// constructor function relies on Ng injector
// to provide service dependencies
formBuilder.factory('datacontext',
    ['$resource',
    function ($resource) {
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
        
        function getAnsweredForms() {

            return $resource('api/AnsweredForms', { formDefinitionId: '@formDefinitionId', answeredFormId: '@answeredFormId' }, {
                query: { method: 'GET', isArray: true }
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
        
        function publishFormDefinition() {
            return $resource('api/FormDefinitions/Publish/:id', {id: "@id"},
            {
                publish: { method: 'POST' }
            });
        }

        return {
            cacheFormDefinitionSet:cacheFormDefinitionSet,
            formDefinitionSets: formDefinitionSets,
            saveFormDefinition: saveFormDefinition,
            getFormDefinitionById: getFormDefinitionById,
            getPublishedFormDefinition: getPublishedFormDefinition,
            getAnsweredForms: getAnsweredForms,
            publishFormDefinition: publishFormDefinition
        };

    }]);