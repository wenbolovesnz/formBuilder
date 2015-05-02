myform.factory('datacontext',
    ['$resource',function ($resource) {

        function getPublishedFormDefinition() {

            return $resource('/api/FormDefinitions', { orgId: '@orgId', formName: '@formName', accessKey: '@accessKey' }, {
                query: { method: 'GET' }
            });

        }

        function saveForm() {

            return $resource('/api/AnsweredForms', {}, {
                create: { method: 'POST' }
            });

        }

        return {
            saveForm: saveForm,
            getPublishedFormDefinition: getPublishedFormDefinition
        };

    }]);