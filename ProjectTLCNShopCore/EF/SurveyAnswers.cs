using System;
using System.Collections.Generic;

namespace ProjectTLCNShopCore.EF
{
    public partial class SurveyAnswers
    {
        public int Id { get; set; }
        public Nullable<int> SurveyQuestionId { get; set; }
        public string AnswerContent { get; set; }

        public virtual SurveyQuestion SurveyQuestion { get; set; }
    }
}
