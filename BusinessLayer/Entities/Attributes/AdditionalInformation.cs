using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ApplicationCore.Entities.Attributes
{
    public class AdditionalInformation : BaseEntity
    {

        #region Товар
        public int? ProductId { get; set; }

        [Display(Name = "Товар")]
        public Product Product { get; set; }
        #endregion

        #region Характеристика
        public int? ProductAttributeId { get; set; }

        [Display(Name = "Властивість")]
        public ProductAttribute ProductAttribute { get; set; }
        #endregion

        #region Значення характеристики
        public int? ProductAttributeValueId { get; set; }

        [Display(Name = "Значення (Довідник)")]
        public ProductAttributeValue ProductAttributeValue { get; set; }

        [Display(Name = "Значення (Числове)")]
        public int? IntValue { get; set; }//IntValue

        [Display(Name = "Значення (Рядок)")]
        public string StringValue { get; set; }//StringValue
        #endregion

    }

}
