using System;
using System.Collections.Generic;
using System.Numerics;

namespace Lab1.Models.Collections
{
    public abstract class V5Data
    {
        #region Properties
        public string Info { get; set; }
        public DateTime MeasureDate { get; set; }
        
        /// <summary>
        /// Коллекция DataItems (определена лишь здесь в базовом классе для устранения дублирования данных)
        /// </summary>
        protected internal List<DataItem> DataItems { get; set; }
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
            return $"V5Data: Info: {Info}, Date: {MeasureDate}";
        }

        public abstract Vector2[] NearEqual(float eps);
        public abstract string ToLongString();

        public virtual string ToString(string format)
        {
            return $"V5Data: Info: {Info}, Date: {MeasureDate.ToString(format)}";
        }
    }
}
