using ApplicationCore.Entities.Attributes;
using ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEB.Interfaces;

namespace WEB.Areas.Admin.Services
{
    public class AdditionalInformationsService : IAdditionalInformationsService
    {
        private readonly IRepository<AdditionalInformation> _additionalInformationsRepository;

        public AdditionalInformationsService(IRepository<AdditionalInformation> productRepository)
        {
            _additionalInformationsRepository = productRepository;
        }

        public IEnumerable<AdditionalInformation> List()
        {
            //return _additionalInformationsRepository.List();
            return _additionalInformationsRepository.List(a => a.ProductAttribute, a => a.Product, a => a.ProductAttributeValue);
        }

        //public IEnumerable<AdditionalInformation> test()
        //{
        //    throw new NotImplementedException();
        //}



        //IEnumerable<AdditionalInformation> List()
        //{
        //    return _additionalInformationsRepository.List();

        //}

        //IEnumerable<AdditionalInformation> IAdditionalInformationsService.List()
        //{
        //    throw new NotImplementedException();
        //}
    }
}
