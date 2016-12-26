using System;
using System.Collections.Generic;

namespace ProjectTLCNShopCore.EF
{
    public partial class QuestionType
    {
        public QuestionType()
        {
            SurveyQuestion = new HashSet<SurveyQuestion>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public virtual ICollection<SurveyQuestion> SurveyQuestion { get; set; }
    }
}
