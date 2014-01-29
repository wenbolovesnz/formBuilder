/* datacontext: data access and model management layer */

// create and add datacontext to the Ng injector
// constructor function relies on Ng injector
// to provide service dependencies
formBuilder.factory('datacontext',
    [
    function () {

        function getData() {
            return {

            };
        }

        function saveEntity(parameters) {
            
        }

        return {
            getData: getData,
            saveEntity: saveEntity
        };

    }]);