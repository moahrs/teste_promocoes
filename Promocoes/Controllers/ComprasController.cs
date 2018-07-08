using AutoMapper;
using Promocoes.Application.Interface;
using Promocoes.Domain;
using Promocoes.MVC.ViewModels;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Promocoes.MVC.Controllers
{
    public class ComprasController : Controller
    {
        private readonly IProdutoAppService _produtoApp;
        private readonly ICarrinhoAppService _carrinhoApp;

        public class meuCarrinho
        {
            public int prodID { get; set; }
            public string codProd { get; set; }
            public string descProd { get; set; }
            public decimal precoProd { get; set; }
            public int qtdProd { get; set; }
        }

        public static Dictionary<int, meuCarrinho> dictCarrinho = new Dictionary<int, meuCarrinho>();
        
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

                totalCompras += partialList.precoProd;

                carrinhoList.Add(partialList);
            }

            ComprasCarrinhoViewModel partialLista = new ComprasCarrinhoViewModel();
            partialLista.prodID = 0;
            partialLista.codProd = "";
            partialLista.descProd = "";
            partialLista.qtdProd = "Total";
            partialLista.precoProd = totalCompras;

            carrinhoList.Add(partialLista);

            return carrinhoList;
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
    }
}