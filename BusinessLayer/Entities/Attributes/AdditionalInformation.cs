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

        [Display(Name = "Значення")]
        public ProductAttributeValue ProductAttributeValue { get; set; }

        /// <summary>
        /// Simple type
        /// </summary>
        public int? IntValue { get; set; }//IntValue

        public string StringValue { get; set; }//StringValue
        #endregion

    }

}
