/* Defines the "about view" controller
 * Constructor function relies on Ng injector to provide:
 *     $scope - context variable for the view to which the view binds
 */
formBuilder.controller('NewFormCtrl',
    ['$scope', 'datacontext','$routeParams',
    function ($scope, datacontext, $routeParams) {
        
        if ($routeParams.formDefinitionId) {
            $scope.questions = [];
            
            var formDefinition = datacontext.getFormDefinitionById().query({ id: $routeParams.formDefinitionId, orgId: 0, formName: 0 }, function () {
                $scope.formName = formDefinition.name;
                $scope.formDefinitionSetId = formDefinition.formDefinitionSetId;
                angular.forEach(formDefinition.questions, function (question, index) {
                    var newQuestion = {};
                    var label = question.questionText;
                    var type = question.questionType;
                    var isRequired = question.isRequired;                    
                    switch (type) {
                        case 1:
                            newQuestion = new QuestionInt({ label: label, type: type, isRequired: isRequired });
                            break;
                        case 2:
                            newQuestion = new QuestionMoney({ label: label, type: type, isRequired: isRequired });
                            break;
                        case 3:
                            newQuestion = new QuestionDate({ label: label, type: type, isRequired: isRequired });
                            break;
                        case 5:
                            newQuestion = new QuestionString({ label: label, type: type, isRequired: isRequired });
                            break;
                        case 6:
                            if (question.answerOptions) {
                                var answerOptions = mapAnswerOptions(question.answerOptions);
                                newQuestion = new QuestionString({ label: label, type: type, isRequired: isRequired, answerOptions: answerOptions });
                            }
                            break;
                        case 7:
                            if (question.answerOptions) {
                                var answerOptions = mapAnswerOptions(question.answerOptions);
                                newQuestion = new QuestionMultiSelect({ label: label, type: type, isRequired: isRequired, answerOptions: answerOptions });
                            }
                            break;
                        default:
                            newQuestion = new QuestionString({ label: label, type: type, isRequired: isRequired });
                    }
                    $scope.questions.push(newQuestion);                   
                });

            });
        } else {
            //create new form, so have some default questions
            $scope.questions = [new QuestionInt({ label: 'Integer', type: 1, isRequired: true }),
                     new QuestionString({ label: 'String', type: 5, isRequired: true }),
                     new QuestionMoney({ label: 'Money', type: 2, isRequired: true }),
                     new QuestionBoolean({ label: 'Boolean', type: 4, isRequired: true }),
                     new QuestionString({ label: 'Select', type: 6, isRequired: true, answerOptions: [1, 2, 3, 4, 5] }),
                     new QuestionMultiSelect({ label: 'MultiSelect', type: 7, isRequired: true, answerOptions: ['Option A', 'Option B', 'Option C', 'Option D', 'Option E'] }),
                     new QuestionDate({ label: 'Date', type: 3, isRequired: true })
            ];
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

        //Form Config defaults
        $scope.questionType = $scope.questionTypes[0];

        $scope.addQuestion = addQuestion;
        $scope.validateQuestion = validateQuestion;

        $scope.saveFormDefinition = saveFormDefinition;

        function addQuestion() {
            var label = $scope.questionLabel;
            var type = $scope.questionType.value;
            var isRequired = $scope.isRequired;

            var newQuestion = {};

            switch (type) {
                case 1:
                    newQuestion = new QuestionInt({ label: label, type: type, isRequired: isRequired });
                    break;
                case 2:
                    newQuestion = new QuestionMoney({ label: label, type: type, isRequired: isRequired });
                    break;
                case 3:
                    newQuestion = new QuestionDate({ label: label, type: type, isRequired: isRequired });
                    break;
                case 5:
                    newQuestion = new QuestionString({ label: label, type: type, isRequired: isRequired });
                    break;
                case 6:
                    if ($scope.answerOptions) {
                        var answerOptions = mapAnswerOptions($scope.answerOptions);
                        newQuestion = new QuestionString({ label: label, type: type, isRequired: isRequired, answerOptions: answerOptions });
                    }
                    break;
                case 7:
                    if ($scope.answerOptions) {
                        var answerOptions = mapAnswerOptions($scope.answerOptions);
                        newQuestion = new QuestionMultiSelect({ label: label, type: type, isRequired: isRequired, answerOptions: answerOptions });
                    }
                    break;
                default:
                    newQuestion = new QuestionString({ label: label, type: type, isRequired: isRequired });
            }

            $scope.questions.push(newQuestion);            
        }

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
            $.each(answerOptionsBeforeTrim, function(index, option) {
                answerOptions.push($.trim(option));
            });
            return answerOptions;
        }
        
        function saveFormDefinition() {

            var questionsForSave = [];
            angular.forEach($scope.questions, function(question, index) {
                var newQuestion = {
                    QuestionText: question.label,
                    QuestionType: question.type,
                    IsRequired: question.isRequired,
                    Tooltip: question.toolTip,
                    Value: question.value,
                    Index: index,
                    AnswerOptions: question.answerOptions? question.answerOptions.join(',') : null 
                };
                questionsForSave.push(newQuestion);
            });
            var formDefinitionModel = {
                Questions: questionsForSave,
                FormDefinitionSetId: $scope.formDefinitionSetId,
                Name: $scope.formName
            };
            
            datacontext.saveFormDefinition().create(formDefinitionModel, function () {
                window.location = '/#';
            });
        }

    }]);