using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ApplicationCore.Entities.Attributes
{
    public class ProductAttributeValue : BaseEntity
    {
        public int? ProductAttributeId { get; set; }

        [Display(Name = "Властивість")]
        public ProductAttribute ProductAttribute { get; set; }

        public string ValueString { get; set; }
    }
}
