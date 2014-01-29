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