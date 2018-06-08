using AutoMapper;
using ControleVenda.Engine.Entities;
using ControleVenda.MVC.Models;

namespace ControleVenda.MVC.Mappers
{
    public class ModelToEntityMappingProfile : Profile
    {
        public ModelToEntityMappingProfile()
        {
            CreateMap<ClienteModel, Cliente>();
            CreateMap<ProdutoModel, Produto>();

            CreateMap<VendaItemModel, VendaItem>();
            CreateMap<VendaModel, Venda>();
        }
    }
}