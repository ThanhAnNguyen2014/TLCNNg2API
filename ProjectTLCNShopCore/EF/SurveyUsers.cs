using System;
using System.Collections.Generic;

namespace ProjectTLCNShopCore.EF
{
    public partial class SurveyUsers
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int SurveyQuestionId { get; set; }
        public int UserAnswer { get; set; }
        public DateTime DateSurvey { get; set; }

        public virtual SurveyQuestion SurveyQuestion { get; set; }
        public virtual Users User { get; set; }
    }
}
