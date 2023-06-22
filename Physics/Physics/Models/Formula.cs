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
            { return Controllers.Manager.RootUrlServer + "img/" + PhotoFormula; }
        }
    }
}