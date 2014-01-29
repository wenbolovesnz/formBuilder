function QuestionString(model) {
    Question.call(this, model);
}

QuestionString.prototype = Object.create(Question.prototype);
QuestionString.prototype.constructor = QuestionString;