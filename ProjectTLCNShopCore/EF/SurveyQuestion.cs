using System;
using System.Collections.Generic;

namespace ProjectTLCNShopCore.EF
{
    public partial class SurveyQuestion
    {
        public SurveyQuestion()
        {
            SurveyAnswers = new HashSet<SurveyAnswers>();
            SurveyUsers = new HashSet<SurveyUsers>();
        }

        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? SurveyDate { get; set; }
        public int QuestionTypeId { get; set; }
        public string Question { get; set; }
        public string Description { get; set; }
        public string Note { get; set; }

        public virtual ICollection<SurveyAnswers> SurveyAnswers { get; set; }
        public virtual ICollection<SurveyUsers> SurveyUsers { get; set; }
        public virtual QuestionType QuestionType { get; set; }
    }
}
