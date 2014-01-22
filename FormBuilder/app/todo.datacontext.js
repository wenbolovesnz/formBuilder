/* datacontext: data access and model management layer */

// create and add datacontext to the Ng injector
// constructor function relies on Ng injector
// to provide service dependencies
todo.factory('datacontext',
    [
    function () {

        function getData() {
            return {
                title: "List A",
                userId: 1,
                todoListId: 1,
                todos: [
                    {
                        title: 'todo1',
                        isDone: false
                    },
                    {
                        title: 'todo2',
                        isDone: false
                    }
                ]
            };
        }

        function saveEntity(parameters) {
            
        }

        return {
            getData: getData,
            saveEntity: saveEntity
        };

    }]);