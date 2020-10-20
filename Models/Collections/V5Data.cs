using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace Lab1.Models.Collections
{
    public abstract class V5Data
    {
        #region Properties
        public string Info { get; set; }
        public DateTime MeasureDate { get; set; }
        #endregion

        // Contructor
        public V5Data(string info, DateTime date)
        {
            Info = info;
            MeasureDate = date;
        }

        // Methods (over + 2 abstr)
        public override string ToString()

        {
            return "V5Data:\nInfo: " + Info.ToString() + "\nDate: " + MeasureDate.ToString();
        }

        public abstract Vector2[] NearEqual(float eps);
        public abstract string ToLongString();
    }
}
