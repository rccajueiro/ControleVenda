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
    public class ProdutoController : Controller
    {
        private readonly ProdutoService _service;

        public ProdutoController()
        {
            _service = new ProdutoService(new ProdutoRepository());
        }

        public ActionResult Index()
        {
            return View(Mapper.Map<List<ProdutoModel>>(_service.List()));
        }

        public ActionResult Details(int id)
        {
            return View(Mapper.Map<ProdutoModel>(_service.Get(id)));
        }

        public ActionResult Create()
        {
            return View("Form", new ProdutoModel());
        }

        public ActionResult Edit(int id)
        {
            return View("Form", Mapper.Map<ProdutoModel>(_service.Get(id)));
        }

        [HttpPost]
        public ActionResult Save(int? id, ProdutoModel model)
        {
            try
            {
                if (!_service.ValidateNome(model.Nome, (int)id))
                {
                    ModelState.AddModelError("Nome", Produto.EXCEPTION_MESSAGE_PRODUTO_NOME_EXISTS);
                    return View("Form", model);
                }

                _service.Save(Mapper.Map<Produto>(model));

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View("Form", model);
            }
        }
    }
}
