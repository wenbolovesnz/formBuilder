/* Defines the "about view" controller
 * Constructor function relies on Ng injector to provide:
 *     $scope - context variable for the view to which the view binds
 *     logger - logs and caches session log messages (about.logger.js)
 */
formBuilder.controller('NewFormCtrl',
    ['$scope', 'logger',
    function ($scope, logger) {

        $scope.questions = [new QuestionInt({ label: 'Integer', type: 1, isRequired: true }),
                            new QuestionString({ label: 'String', type: 5, isRequired: true }),
                            new QuestionMoney({ label: 'Money', type: 2, isRequired: true }),
                            new QuestionBoolean({ label: 'Boolean', type: 4, isRequired: true }),
                            new QuestionString({ label: 'Select', type: 6, isRequired: true, answerOptions: [1, 2, 3, 4, 5] }),
                            new QuestionMultiSelect({ label: 'MultiSelect', type: 7, isRequired: true, answerOptions: ['Option A', 'Option B', 'Option C', 'Option D', 'Option E'] }),
                            new QuestionDate({label:'Date', type: 3, isRequired: true})
        ];
        
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

    }]);