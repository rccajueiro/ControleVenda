using AutoMapper;
using ControleVenda.Engine.Entities;
using ControleVenda.Engine.Services;
using ControleVenda.Infrastructure.Repositories;
using ControleVenda.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControleVenda.MVC.Controllers
{
    public class VendaController : Controller
    {
        private readonly VendaService _service;
        private readonly ClienteService _clienteService;
        private readonly ProdutoService _produtoService;

        public VendaController()
        {
            _service = new VendaService(new VendaRepository());
            _clienteService = new ClienteService(new ClienteRepository());
            _produtoService = new ProdutoService(new ProdutoRepository());
        }

        public ActionResult Index()
        {
            List<Venda> Lista = _service.List();

            return View(Mapper.Map<List<VendaModel>>(Lista));
        }

        public ActionResult Details(int id)
        {
            return View(Mapper.Map<VendaModel>(_service.Get(id)));
        }

        public ActionResult Create()
        {
            ViewBag.Clientes = new SelectList(_clienteService.List(), "Id", "Nome");

            return View("Form", new VendaModel());
        }

        [HttpPost]
        public ActionResult Save(VendaModel model)
        {
            try
            {
                Venda Venda = Mapper.Map<Venda>(model);
                Venda.SetDataHora(DateTime.Now);

                foreach (Produto produto in _produtoService.List())
                {
                    Venda.VendaItems.Add(VendaItem.InstanceVendaItemWithFields(produto, (decimal)10.10, 1));
                }

                _service.Save(Venda);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Clientes = new SelectList(_clienteService.List(), "Id", "Nome");

                ModelState.AddModelError("", ex.Message);
                return View("Form", model);
            }
        }

        [HttpGet]
        public ActionResult SearchProduto(string q)
        {
            return Json(_produtoService.SearchByNome(q).Select(produto => new {
                produto = produto.Nome,
                id = produto.Id
            }), JsonRequestBehavior.AllowGet);
        }
    }
}
