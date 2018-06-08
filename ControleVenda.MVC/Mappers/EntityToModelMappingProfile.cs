using AutoMapper;
using ControleVenda.Engine.Entities;
using ControleVenda.MVC.Models;

namespace ControleVenda.MVC.Mappers
{
    public class EntityToModelMappingProfile : Profile
    {
        public EntityToModelMappingProfile()
        {
            CreateMap<Cliente, ClienteModel>();
            CreateMap<Produto, ProdutoModel>();

            CreateMap<VendaItem, VendaItemModel>();
            CreateMap<Venda, VendaModel>();
        }

}
}