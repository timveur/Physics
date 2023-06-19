using System;
using System.Collections.Generic;

namespace Physics.Models
{

    public partial class Formula
    {
        public int IdFormula { get; set; }

        public string PhotoFormula { get; set; }

        public int? ChapterId { get; set; }

        public virtual Chapter Chapter { get; set; }
    }
}