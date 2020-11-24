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
        //V5MCol fix check
        public abstract List<DataItem> DataItems { get; set; }
        #endregion

        // Contructor
        public V5Data(string info, DateTime date)
        {
            Info = info;
            MeasureDate = date;
            DataItems = new List<DataItem>();
        }

        // Methods (2 over + 2 abstr)
        public override string ToString()

        {
            return "V5Data:\nInfo: " + Info.ToString() + "\nDate: " + MeasureDate.ToString();
        }

        public abstract Vector2[] NearEqual(float eps);
        public abstract string ToLongString();

        public virtual string ToString(string format)
        {
            return "V5Data:\nInfo: " + Info.ToString() + "\nDate: " + MeasureDate.ToString(format);
        }
    }
}
