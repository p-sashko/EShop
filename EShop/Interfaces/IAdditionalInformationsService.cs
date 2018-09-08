using ApplicationCore.Entities.Attributes;
using ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WEB.Interfaces
{
    public interface IAdditionalInformationsService 
    {
        IEnumerable<AdditionalInformation> List();

        //IEnumerable<AdditionalInformation> test();
    }
}
