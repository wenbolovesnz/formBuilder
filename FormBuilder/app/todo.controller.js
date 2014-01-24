/* Defines the "todo view" controller
 * Constructor function relies on Ng injector to provide:
 *     $scope - context variable for the view to which the view binds
 *     breeze - breeze is a "module" known to the injectory thanks to main.js
 *     datacontext - injected data and model access component (todo.datacontext.js)
 *     logger - records notable events during the session (about.logger.js)
 */
todo.controller('TodoCtrl',
    ['$scope', 'datacontext', 'logger',
    function ($scope, datacontext, logger) {

        logger.log("creating TodoCtrl");
        
        $scope.todoLists = [];
        $scope.error = "";
        $scope.getTodos = getTodos;
        $scope.refresh = refresh;
        $scope.endEdit = endEdit;
        $scope.addTodoList = addTodoList;
        $scope.deleteTodoList = deleteTodoList;
        $scope.clearErrorMessage = clearErrorMessage;

        // load TodoLists immediately (from cache if possible)
        $scope.getTodos();

        //#region private functions 
        function getTodos(forceRefresh) {
            $scope.todoLists.push(datacontext.getData());
        }
        function refresh() { getTodos(true); }

        function getSucceeded(data) {
            $scope.todoLists = data;
        }
        function failed(error) {
            $scope.error = error.message;
        }
        function refreshView() {
            $scope.$apply();
        }
        function endEdit(entity) {
            //datacontext.saveEntity(entity).fin(refreshView);
        }
        function addTodoList() {
            
        }
        function deleteTodoList(todoList) {

        }
        function clearErrorMessage(obj) {
            if (obj && obj.errorMessage) {
                obj.errorMessage = null;
            }
        }
        function showAddedTodoList(todoList) {
            $scope.todoLists.unshift(todoList); // Insert todoList at the front
        }
        //#endregion
    }]);