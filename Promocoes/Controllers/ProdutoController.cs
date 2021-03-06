﻿using AutoMapper;
using Promocoes.Application.Interface;
using Promocoes.Domain;
using Promocoes.MVC.ViewModels;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Promocoes.MVC.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly IProdutoAppService _produtoApp;
        private DefinicaoTipos tpDef = new DefinicaoTipos();

        public ProdutoController(IProdutoAppService produtoApp)
        {
            _produtoApp = produtoApp;
        }

        // GET: Produto
        public ActionResult Index()
        {
            var produtoViewModel = Mapper.Map<IEnumerable<Produto>, IEnumerable<ProdutoViewModel>>(_produtoApp.GetAll());

            return View(produtoViewModel);
        }

        // GET: Produto/Details/5
        public ActionResult Details(int id)
        {
            var produto = _produtoApp.GetById(id);
            var produtoViewModel = Mapper.Map<Produto, ProdutoViewModel>(produto);
            produtoViewModel.TipoListaPromocoes = tpDef.ListaPromocoes;

            return View(produtoViewModel);
        }

        // GET: Produto/Create
        public ActionResult Create()
        {
            var produtoViewModel = new ProdutoViewModel();
            produtoViewModel.TipoListaPromocoes = tpDef.ListaPromocoes;
            return View(produtoViewModel);
        }

        // POST: Produto/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProdutoViewModel produto)
        {
            if (ModelState.IsValid)
            {
                var produtoDomain = Mapper.Map<ProdutoViewModel, Produto>(produto);
                _produtoApp.Add(produtoDomain);

                return RedirectToAction("Index");
            }

            return View(produto);
        }

        // GET: Produto/Edit/5
        public ActionResult Edit(int id)
        {
            var produto = _produtoApp.GetById(id);
            var produtoViewModel = Mapper.Map<Produto, ProdutoViewModel>(produto);
            produtoViewModel.TipoListaPromocoes = tpDef.ListaPromocoes;

            return View(produtoViewModel);
        }

        // POST: Produto/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProdutoViewModel produto)
        {
            if (ModelState.IsValid)
            {
                var produtoDomain = Mapper.Map<ProdutoViewModel, Produto>(produto);
                _produtoApp.Update(produtoDomain);

                return RedirectToAction("Index");
            }

            return View(produto);
        }

        // GET: Produto/Delete/5
        public ActionResult Delete(int id)
        {
            var produto = _produtoApp.GetById(id);
            var produtoViewModel = Mapper.Map<Produto, ProdutoViewModel>(produto);
            produtoViewModel.TipoListaPromocoes = tpDef.ListaPromocoes;

            return View(produtoViewModel);
        }

        // POST: Produto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var produto = _produtoApp.GetById(id);

            _produtoApp.Remove(produto);

            return RedirectToAction("Index");
        }
    }
}
