/* datacontext: data access and model management layer */

// create and add datacontext to the Ng injector
// constructor function relies on Ng injector
// to provide service dependencies
myform.factory('datacontext',
    ['Q', '$resource',
    function (Q, $resource) {

        function getPublishedFormDefinition() {

            return $resource('/api/FormDefinitions', { orgId: '@orgId', formName: '@formName' }, {
                query: { method: 'GET' }
            });

        }

        function saveFormDefinition() {
            return $resource('/api/FormDefinitions', {},
            {
                create: { method: 'POST' }
            });
        }

        return {
            saveFormDefinition: saveFormDefinition,
            getPublishedFormDefinition: getPublishedFormDefinition
        };

    }]);