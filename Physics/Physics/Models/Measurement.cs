using System;
using System.Collections.Generic;


namespace Physics.Models
{
    public partial class Measurement
    {
        public int IdMeasurement { get; set; }

        public int? TablesMeasureId { get; set; }

        public string TitleMeasure { get; set; }

        public string CountMeasure { get; set; }

        public virtual TablesMeasurement TablesMeasure { get; set; }
    }
}