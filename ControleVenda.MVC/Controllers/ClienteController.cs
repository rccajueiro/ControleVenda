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
    public class ClienteController : Controller
    {
        private readonly ClienteService _service;

        public ClienteController()
        {
            _service = new ClienteService(new ClienteRepository());
        }
        
        public ActionResult Index()
        {
            return View(Mapper.Map<List<ClienteModel>>(_service.List()));
        }

        public ActionResult Details(int id)
        {
            return View(Mapper.Map<ClienteModel>(_service.Get(id)));
        }

        public ActionResult Create()
        {
            return View("Form", new ClienteModel());
        }

        public ActionResult Edit(int id)
        {
            return View("Form", Mapper.Map<ClienteModel>(_service.Get(id)));
        }

        [HttpPost]
        public ActionResult Save(int? id, ClienteModel model)
        {
            try
            {
                if(!_service.ValidateCpf(model.Cpf, (int)id))
                {
                    ModelState.AddModelError("Cpf", Cliente.EXCEPTION_MESSAGE_CLIENTE_CPF_EXISTS);
                    return View("Form", model);
                }

                _service.Save(Mapper.Map<Cliente>(model));

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
