function Question(model) {
    this.label = model.label;
    this.type = model.type;
    this.isRequired = model.isRequired;    
    if (model.answerOptions) {
        this.answerOptions = model.answerOptions;
    }
    
    this.error = false;
    this.errorMessage = null;
    this.isString = this.type == 5;
    this.isBoolean = this.type == 4;
    this.isInt = this.type == 1;
    this.isSelect = this.type == 6;
    this.isMultiSelect = this.type == 7;
    this.isDate = this.type == 3;
    this.isMoney = this.type == 2;
}

Question.prototype.validate = function () {
    if (this.value == undefined) {
        this.error = true;
        this.errorMessage = "Required!";
    } else {
        this.error = false;
        this.errorMessage = null;
    }

};

function QuestionString(model) {
    Question.call(this, model);
}

QuestionString.prototype = Object.create(Question.prototype);
QuestionString.prototype.constructor = QuestionString;


function QuestionBoolean(model) {
    Question.call(this, model);
}

QuestionBoolean.prototype = Object.create(Question.prototype);
QuestionBoolean.prototype.constructor = QuestionBoolean;


function QuestionInt(model) {
    Question.call(this, model);
}

QuestionInt.prototype = Object.create(Question.prototype);
QuestionInt.prototype.constructor = QuestionInt;


QuestionInt.prototype.validate = function () {
    if (this.value == undefined) {
        this.error = true;
        this.errorMessage = "Required!";
    } else if (!/^[0-9]+$/.test(this.value)) {
        this.error = true;
        this.errorMessage = "Please enter number only!";
    } else {
        this.error = false;
        this.errorMessage = null;
    }
};

function QuestionMoney(model) {
    Question.call(this, model);
}

QuestionMoney.prototype = Object.create(Question.prototype);
QuestionMoney.prototype.constructor = QuestionMoney;


QuestionMoney.prototype.validate = function () {
    
    if (this.value == undefined) {
        this.error = true;
        this.errorMessage = "Required!";
    } else {        
        //remove leading 0s
        var newValue = this.value.replace(/^(-)?0+(?=\d)/, '$1');
        this.value = newValue;
        
        if (/^\d+(?:\.\d+)?$/.test(this.value)) {
            this.error = false;
            this.errorMessage = null;
        } else {
            this.error = true;
            this.errorMessage = "Please enter valid decimal number !";
        }        
    }
};

function QuestionMultiSelect(model) {
    Question.call(this, model);

    this.subQuestions = [];
    var self = this;
    $.each(this.answerOptions, function(index, subQuestion) {
        self.subQuestions.push(new SubQuestion(subQuestion));
    });
    
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

    if (!hasValue) {
        this.error = true;
        this.errorMessage = "Please select at least one option!";
    } else {        
        this.error = false;
        this.errorMessage = null;      
    }
};



function QuestionDate(model) {
    Question.call(this, model);
}

QuestionDate.prototype = Object.create(Question.prototype);
QuestionDate.prototype.constructor = QuestionDate;


QuestionDate.prototype.validate = function () {
    if (this.value == undefined) {
        this.error = true;
        this.errorMessage = "Required!";
    } else {
        var date = new moment(this.value, 'DD-MM-YYYY');
        if (date.isValid() && this.value.split('/').length == 3 && this.value.split('/')[2].length == 4) {
            this.error = false;
            this.errorMessage = null;
        } else {
            this.error = true;
            this.errorMessage = "Please ensure the date is in correct format, 'Date/Month/Year'.";
        }

        
    }
};




















