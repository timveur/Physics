using System.Collections.Generic;

namespace Physics.Models
{

    public partial class TablesMeasurement
    {
        public int IdTablesMeasure { get; set; }

        public string Title { get; set; }

        public string UnitOfMeasure { get; set; }

        public virtual ICollection<Measurement> Measurements { get; set; } = new List<Measurement>();
        public string DisplayTitle
        {
            get
            {
                if (!string.IsNullOrEmpty(UnitOfMeasure))
                {
                    return Title + ", " + UnitOfMeasure;
                }
                else
                {
                    return Title;
                }
            }
        }
    }
}