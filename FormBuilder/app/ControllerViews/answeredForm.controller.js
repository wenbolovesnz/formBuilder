﻿/* Defines the "about view" controller
 * Constructor function relies on Ng injector to provide:
 *     $scope - context variable for the view to which the view binds
 */
formBuilder.controller('AnsweredFormCtrl',
    ['$scope', 'datacontext', '$routeParams',
    function ($scope, datacontext, $routeParams) {

        if ($routeParams.id) {
            $scope.questions = [];
            
            var formDefinition = datacontext.getAnsweredForms().query({ formDefinitionId: 0, answeredFormId: $routeParams.id }, function () {
            $scope.answeredForm = formDefinition[0];
                    
            $scope.formName = $scope.answeredForm.formName;

            angular.forEach($scope.answeredForm.questions, function (question, index) {
                var newQuestion = {};
                var label = question.questionText;
                var type = question.questionType;
                var isRequired = question.isRequired;
                switch (type) {
                    case 1:
                        newQuestion = new QuestionInt({ label: label, type: type, isRequired: isRequired, value: question.value });
                        break;
                    case 2:
                        newQuestion = new QuestionMoney({ label: label, type: type, isRequired: isRequired, value: question.value });
                        break;
                    case 3:
                        newQuestion = new QuestionDate({ label: label, type: type, isRequired: isRequired, value: question.value });
                        break;
                    case 5:
                        newQuestion = new QuestionString({ label: label, type: type, isRequired: isRequired, value: question.value });
                        break;
                    case 6:
                        if (question.answerOptions) {
                            var answerOptions = mapAnswerOptions(question.answerOptions);
                            newQuestion = new QuestionString({ label: label, type: type, isRequired: isRequired, answerOptions: answerOptions, value: question.value });
                        }
                        break;
                    case 7:
                        if (question.answerOptions) {
                            var answerOptions = mapAnswerOptions(question.answerOptions);
                            newQuestion = new QuestionMultiSelect({ label: label, type: type, isRequired: isRequired, answerOptions: answerOptions, value: question.value });
                        }
                        break;
                    default:
                        newQuestion = new QuestionString({ label: label, type: type, isRequired: isRequired, value: question.value });
                }
                $scope.questions.push(newQuestion);
            });

            });
        }

        $scope.questionTypes = [
                                { value: 1, name: 'Integer' },
                                { value: 2, name: 'Money' },
                                { value: 3, name: 'Date' },
                                { value: 4, name: 'Boolean' },
                                { value: 5, name: 'String' },
                                { value: 6, name: 'Select' },
                                { value: 7, name: 'MultiSelect' }

        ];

        $scope.noError = true;

        $scope.validateQuestion = validateQuestion;

        $scope.saveFormDefinition = saveFormDefinition;



        //this function could be move to a service later, so it can be reused in different controller
        function validateQuestion(question) {
            question.validate();

            if (question.error) {
                $scope.noError = false;
            } else {
                var hasError = false;
                $.each($scope.questions, function (index, q) {
                    if (q.error) {
                        hasError = true;
                    }
                });

                $scope.noError = !hasError;
            }
        }

        function mapAnswerOptions(valueString) {
            var answerOptions = [];
            var answerOptionsBeforeTrim = valueString.split(',');
            $.each(answerOptionsBeforeTrim, function (index, option) {
                answerOptions.push($.trim(option));
            });
            return answerOptions;
        }
        
        function saveFormDefinition() {

            var questionsForSave = [];
            angular.forEach($scope.questions, function (question, index) {
                var newQuestion = {
                    QuestionText: question.label,
                    QuestionType: question.type,
                    IsRequired: question.isRequired,
                    Tooltip: question.toolTip,
                    Value: question.value,
                    Index: index,
                    AnswerOptions: question.answerOptions ? question.answerOptions.join(',') : null
                };
                questionsForSave.push(newQuestion);
            });

            var formDefinitionModel = {
                Questions: questionsForSave,
                FormDefinitionId: $scope.formDefinitionId,
                formName: $scope.formName
            };

            datacontext.saveForm().create(formDefinitionModel, function () {
                alert('done');
            });
        }

    }]);