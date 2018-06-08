using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControleVenda.MVC.Mappers
{
    public class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            Mapper.Initialize(x =>
            {
                x.AddProfile<EntityToModelMappingProfile>();
                x.AddProfile<ModelToEntityMappingProfile>();
            });

            Mapper.AssertConfigurationIsValid();
        }
    }
}