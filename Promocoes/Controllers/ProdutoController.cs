using AutoMapper;
using Promocoes.Application.Interface;
using Promocoes.Domain;
using Promocoes.MVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Promocoes.MVC.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly IProdutoAppService _produtoApp;
        private readonly IProdutoPromocaoAppService _produtoPromocaoApp;
        private ProdutoPromocao vPromocaoID = new ProdutoPromocao();

        public ProdutoController(IProdutoAppService produtoApp, IProdutoPromocaoAppService produtoPromocaoApp)
        {
            _produtoApp = produtoApp;
            _produtoPromocaoApp = produtoPromocaoApp;
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

            vPromocaoID = _produtoPromocaoApp.BuscarPorProdAtivo(id);

            if (vPromocaoID != null)
                ViewBag.PromocaoID = new SelectList(_produtoPromocaoApp.BuscarPorProd(id), "PromocaoID", "Descricao", vPromocaoID.PromocaoID);
            else
                ViewBag.PromocaoID = new SelectList(_produtoPromocaoApp.BuscarPorProd(id), "PromocaoID", "Descricao");

            return View(produtoViewModel);
        }

        // GET: Produto/Create
        public ActionResult Create()
        {
            return View();
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

            vPromocaoID = _produtoPromocaoApp.BuscarPorProdAtivo(id);

            if (vPromocaoID != null)
                ViewBag.PromocaoID = new SelectList(_produtoPromocaoApp.BuscarPorProd(id), "PromocaoID", "Descricao", vPromocaoID.PromocaoID);
            else
                ViewBag.PromocaoID = new SelectList(_produtoPromocaoApp.BuscarPorProd(id), "PromocaoID", "Descricao");

            return View(produtoViewModel);
        }

        // POST: Produto/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProdutoViewModel produto)
        {
            int vSelPromocaoID = produto.PromocaoID;

            if (ModelState.IsValid)
            {
                var produtoDomain = Mapper.Map<ProdutoViewModel, Produto>(produto);
                _produtoApp.Update(produtoDomain);

                _produtoPromocaoApp.LimpaAtivosPorProd(produto.ProdutoID);
                _produtoPromocaoApp.SetarAtivoPorPromo(vSelPromocaoID);

                return RedirectToAction("Index");
            }

            return View(produto);
        }

        // GET: Produto/Delete/5
        public ActionResult Delete(int id)
        {
            var produto = _produtoApp.GetById(id);
            var produtoViewModel = Mapper.Map<Produto, ProdutoViewModel>(produto);

            vPromocaoID = _produtoPromocaoApp.BuscarPorProdAtivo(produto.ProdutoID);

            if (vPromocaoID != null)
                ViewBag.PromocaoID = new SelectList(_produtoPromocaoApp.BuscarPorProd(id), "PromocaoID", "Descricao", vPromocaoID.PromocaoID);
            else
                ViewBag.PromocaoID = new SelectList(_produtoPromocaoApp.BuscarPorProd(id), "PromocaoID", "Descricao");

            return View(produtoViewModel);
        }

        // POST: Produto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var produto = _produtoApp.GetById(id);

            _produtoPromocaoApp.LimpaAtivosPorProd(id);
            _produtoApp.Remove(produto);

            return RedirectToAction("Index");
        }

        public ActionResult CadPromo(int idProd)
        {
            var prodPromoView = new ProdutoPromocaoViewModel();

            prodPromoView.ProdutoID = idProd;
            prodPromoView.Codigo = 0;
            prodPromoView.Descricao = "";
            prodPromoView.Quantidade = 0;
            prodPromoView.Preco = 0;

            return PartialView(prodPromoView);
        }

        public JsonResult PromoCreateSave(int prodID, string descPromo, int qtdPromo, decimal precoPromo)
        {
            try
            {
                var vProdPromo = new ProdutoPromocao();

                vProdPromo.ProdutoID = prodID;
                vProdPromo.Descricao = descPromo;
                vProdPromo.Quantidade = qtdPromo;
                vProdPromo.Preco = precoPromo;

                _produtoPromocaoApp.Add(vProdPromo);

                return Json(new { response = "True" }, JsonRequestBehavior.AllowGet);
            }
            catch (ArgumentException e)
            {
                return Json(new { response = "False" }, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult FillListPromoProd(int produtoID)
        {
            var listaPromo = _produtoPromocaoApp.BuscarPorProd(produtoID);

            List<SelectListItem> promoList = new List<SelectListItem>();

            foreach (var item in listaPromo)
            {
                SelectListItem lPromo = new SelectListItem
                {
                    Text = item.Descricao,
                    Value = item.PromocaoID.ToString()
                };
                promoList.Add(lPromo);
            }

            return Json(promoList, JsonRequestBehavior.AllowGet);
        }
    }
}
