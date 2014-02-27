function QuestionMultiSelect(model) {
    Question.call(this, model);
    var self = this;
    
    if (model.value) {
        this.subQuestions = JSON.parse(model.value);
    } else {
        this.subQuestions = [];
        $.each(this.answerOptions, function (index, subQuestion) {
            self.subQuestions.push(new SubQuestion(subQuestion));
        });
    }
        
    function SubQuestion(subQuestion) {
        this.label = subQuestion;
        this.value = false;        
    }

}

QuestionMultiSelect.prototype = Object.create(Question.prototype);
QuestionMultiSelect.prototype.constructor = QuestionMultiSelect;


QuestionMultiSelect.prototype.validate = function () {
    var self = this;
    
    var hasValue = false;
    self.isRequired = false;
    
    $.each(self.subQuestions, function (index, subQuestion) {
        if (subQuestion.value) {
            hasValue = true;
        }
    });
    
    self.value = JSON.stringify(self.subQuestions);

    if (!hasValue) {
        this.error = true;
        this.errorMessage = "Please select at least one option!";
    } else {        
        this.error = false;
        this.errorMessage = null;      
    }
};