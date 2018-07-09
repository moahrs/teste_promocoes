using AutoMapper;
using Promocoes.Application.Interface;
using Promocoes.Domain;
using Promocoes.MVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Promocoes.MVC.Controllers
{
    public class ComprasController : Controller
    {
        private readonly IProdutoAppService _produtoApp;
        private readonly ICarrinhoAppService _carrinhoApp;
        private DefinicaoTipos tpDef = new DefinicaoTipos();

        public ComprasController(IProdutoAppService produtoApp, ICarrinhoAppService carrinhoApp)
        {
            _produtoApp = produtoApp;
            _carrinhoApp = carrinhoApp;
        }

        // GET: Compras
        public ActionResult Index()
        {
            var comprasViewModel = Mapper.Map<IEnumerable<Produto>, IEnumerable<ComprasViewModel>>(_produtoApp.GetAll());
            _carrinhoApp.CriaCarrinho();
            return View(comprasViewModel);
        }

        public ActionResult CarrinhoAdd(int idProd, int qtdProd)
        {
            var carrinhoDict = _carrinhoApp.AdicionaProduto(_produtoApp.GetById(idProd), qtdProd);
            var carrinhoList = MontaCarrinhoViewModel();

            return PartialView("ComprasCarrinho", carrinhoList);
        }

        public ActionResult CarrinhoDel(int idProd)
        {
            var carrinhoDict = _carrinhoApp.RetiraProduto(idProd);
            var carrinhoList = MontaCarrinhoViewModel();

            return PartialView("ComprasCarrinho", carrinhoList);
        }

        public ActionResult Checkout()
        {
            var checkoutView = new CheckoutViewModel();
            return PartialView(checkoutView);
        }

        public List<ComprasCarrinhoViewModel> MontaCarrinhoViewModel()
        {
            var carrinhoDict = _carrinhoApp.DevolveConteudo();
            decimal totalCompras = 0;
            List<ComprasCarrinhoViewModel> carrinhoList = new List<ComprasCarrinhoViewModel>();

            foreach (var item in carrinhoDict)
            {
                ComprasCarrinhoViewModel partialList = new ComprasCarrinhoViewModel();
                partialList.prodID = item.Value.prodID;
                partialList.codProd = item.Value.codProd;
                partialList.descProd = item.Value.descProd;
                partialList.qtdProd = item.Value.qtdProd.ToString();
                partialList.precoProd = item.Value.precoProd;
                partialList.PromocaoID = item.Value.PromocaoID;
                partialList.descPromo = tpDef.RetornarDescPromocao(item.Value.PromocaoID);

                totalCompras += partialList.precoProd;

                carrinhoList.Add(partialList);
            }

            ComprasCarrinhoViewModel partialLista = new ComprasCarrinhoViewModel();
            partialLista.prodID = 0;
            partialLista.codProd = "";
            partialLista.descProd = "";
            partialLista.qtdProd = "Total";
            partialLista.precoProd = totalCompras;
            partialLista.descPromo = "";

            carrinhoList.Add(partialLista);

            return carrinhoList;
        }
    }
}