function QuestionBoolean(model) {
    Question.call(this, model);
    model.value = false; // boolean's inital value is false.
}

QuestionBoolean.prototype = Object.create(Question.prototype);
QuestionBoolean.prototype.constructor = QuestionBoolean;