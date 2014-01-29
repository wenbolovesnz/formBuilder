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