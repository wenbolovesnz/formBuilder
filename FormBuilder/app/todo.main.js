/* main: startup script creates the 'formBuilder' module and adds custom Ng directives */

// 'formBuilder' is the one Angular (Ng) module in this app
// 'formBuilder' module is in global namespace
window.todo = angular.module('todo', []);


// Configure routes
todo.config(['$routeProvider', function ($routeProvider) {
      $routeProvider.
          when('/', { templateUrl: 'app/todo.view.html', controller: 'TodoCtrl' }).
          when('/about', { templateUrl: 'app/about.view.html', controller: 'AboutCtrl' }).
          otherwise({ redirectTo: '/' });
  }]);

//#region Ng directives
/*  We extend Angular with custom data bindings written as Ng directives */
todo.directive('onFocus', function () {
        return {
            restrict: 'A',
            link: function (scope, elm, attrs) {
                elm.bind('focus', function () {
                    scope.$apply(attrs.onFocus);
                });
            }
        };
    })
    .directive('onBlur', function () {
        return {
            restrict: 'A',
            link: function (scope, elm, attrs) {
                elm.bind('blur', function () {
                    scope.$apply(attrs.onBlur);
                });
            }
        };
    })
    .directive('onEnter', function () {
        return function (scope, element, attrs) {
            element.bind("keydown keypress", function (event) {
                if (event.which === 13) {
                    scope.$apply(function () {
                        scope.$eval(attrs.onEnter);
                    });

                    event.preventDefault();
                }
            });
        };
    })
    .directive('selectedWhen', function () {
        return function (scope, elm, attrs) {
            scope.$watch(attrs.selectedWhen, function (shouldBeSelected) {
                if (shouldBeSelected) {
                    elm.select();
                }
            });
        };
    })
    .directive('normalString', function () {
        return {
            restrict: "C",
            //replace: true,
            scope: {
                text: "@"
            },
            template: "<div class= 'col-md-6'>{{text}}</div>" + 
                      "<input class='col-md-6'/>"
        }
    });
if (!Modernizr.input.placeholder) {
    // this browser does not support HTML5 placeholders
    // see http://stackoverflow.com/questions/14777841/angularjs-inputplaceholder-directive-breaking-with-ng-model
    todo.directive('placeholder', function () {
        return {
            restrict: 'A',
            require: 'ngModel',
            link: function (scope, element, attr, ctrl) {

                var value;

                var placeholder = function () {
                    element.val(attr.placeholder);
                };
                var unplaceholder = function () {
                    element.val('');
                };

                scope.$watch(attr.ngModel, function (val) {
                    value = val || '';
                });

                element.bind('focus', function () {
                    if (value == '') unplaceholder();
                });

                element.bind('blur', function () {
                    if (element.val() == '') placeholder();
                });

                ctrl.$formatters.unshift(function (val) {
                    if (!val) {
                        placeholder();
                        value = '';
                        return attr.placeholder;
                    }
                    return val;
                });
            }
        };
    });
}
//#endregion 