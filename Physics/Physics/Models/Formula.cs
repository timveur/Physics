using System;
using System.Collections.Generic;

namespace Physics.Models
{

    public partial class Formula
    {
        public int IdFormula { get; set; }

        public string PhotoFormula { get; set; }

        public string TitleFormula { get; set; }

        public string PhotoFormulaPath
        {
            get
            { return "http://188.234.244.32/0_mobile/Img/" + PhotoFormula; }
        }

    }
}