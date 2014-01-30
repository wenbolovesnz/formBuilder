using FormBuilder.Business.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormBuilder.Data
{
    class SampleDataBuilder
    {
        internal static List<FormDefinitionSet> SeedDbWithSampleFormDefinations()
        {
            var formDefinitionSets = new List<FormDefinitionSet>
            {
                new FormDefinitionSet {
                    Id = 1,
                    FormDefinations = new List<FormDefinition> {
                        new FormDefinition {
                            Id = 1,
                            Questions = new List<Question> { 
                                new Question { 
                                    Id = 1, 
                                    Index = 1, 
                                    IsRequired = true, 
                                    QuestionText = "Question1", QuestionType= QuestionType.String,
                                    AnswerOptions = "Options for Question1"  
                                },
                                new Question { 
                                    Id = 2, 
                                    Index = 1, 
                                    IsRequired = true, 
                                    QuestionText = "Question2", 
                                    QuestionType= QuestionType.String
                                }
                            }, 
                            FormName = "Form1", 
                            CreatedBy = 1, 
                            CreatedDate = DateTime.Now
                        },
                        new FormDefinition {
                            Id = 2,
                            Questions = new List<Question> { 
                                new Question { 
                                    Id = 3, 
                                    Index = 1, 
                                    IsRequired = true, 
                                    QuestionText = "Question3", QuestionType= QuestionType.String,
                                    AnswerOptions = "Options for Question3"  
                                },
                                new Question { 
                                    Id = 4, 
                                    Index = 1, 
                                    IsRequired = false, 
                                    QuestionText = "Question4", 
                                    QuestionType= QuestionType.String
                                }
                            }, 
                            FormName = "Form1", 
                            CreatedBy = 1, 
                            CreatedDate = DateTime.Now
                        }
                    }
                }
            };

            return formDefinitionSets;
        }
    }
}
