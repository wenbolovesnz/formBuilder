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