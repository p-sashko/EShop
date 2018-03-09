using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ApplicationCore.Entities.Attributes
{
    public class ProductAttribute : BaseEntity
    {
        public string Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public AttributeValueType ValueType { get; set; }
    }

    public enum AttributeValueType
    {
        [Display(Name = "Строка")]
        StringValue,

        [Display(Name = "Число")]
        IntValue,

        [Display(Name = "Довідник")]
        ObjectValue
    }
}
