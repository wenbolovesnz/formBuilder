function QuestionBoolean(model) {
    Question.call(this, model);
}

QuestionBoolean.prototype = Object.create(Question.prototype);
QuestionBoolean.prototype.constructor = QuestionBoolean;