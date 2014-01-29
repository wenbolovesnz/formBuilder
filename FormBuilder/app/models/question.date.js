
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
