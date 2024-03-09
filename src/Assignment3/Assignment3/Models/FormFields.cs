using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment3.Models
{
    public class FormFields
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string ControlType { get; set; }
        public int GridColumns { get; set; }
        public string LabelEnglish { get; set; }
        public string ValidationExpressionEn { get; set; }
        public int MaxSizeEn { get; set; }
        public string LabelArabic { get; set; }
        public string ValidationExpressionAr { get; set; }
        public int MaxSizeAr { get; set; }
        public int DisplayOrder { get; set; }
        public bool IsMandatory { get; set; }

    }
}
