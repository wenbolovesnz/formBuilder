/* main: startup script creates the 'myform' module and adds custom Ng directives */

// 'myform' is the one Angular (Ng) module in this app
// 'myform' module is in global namespace
window.myform = angular.module('myform', ['ngRoute', 'ngResource']);

myform.value('Q', window.Q);

// Configure routes
myform.config(['$routeProvider', function ($routeProvider) {
    $routeProvider.
        when('/org/:orgId/formName/:formName', { templateUrl: '/app/templates/publishedForm.view.html', controller: 'PublishedFormCtrl' }).
        otherwise({ redirectTo: '/' });
}]);

//#region Ng directives
/*  We extend Angular with custom data bindings written as Ng directives */
myform.directive('onFocus', function () {
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
    myform.directive('placeholder', function () {
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