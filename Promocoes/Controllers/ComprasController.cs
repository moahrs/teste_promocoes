﻿using AutoMapper;
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

        public class meuCarrinho
        {
            public int prodID { get; set; }
            public string codProd { get; set; }
            public string descProd { get; set; }
            public decimal precoProd { get; set; }
            public int qtdProd { get; set; }
        }

        public static Dictionary<int, meuCarrinho> dictCarrinho = new Dictionary<int, meuCarrinho>();

        public ComprasController(IProdutoAppService produtoApp)
        {
            _produtoApp = produtoApp;
        }

        // GET: Compras
        public ActionResult Index()
        {
            var comprasViewModel = Mapper.Map<IEnumerable<Produto>, IEnumerable<ComprasViewModel>>(_produtoApp.GetAll());
            return View(comprasViewModel);
        }

        public ActionResult CarrinhoAdd(int idProd, int qtdProd)
        {
            int qtdAnterior;
            meuCarrinho meuCarAtu = new meuCarrinho();
            var dadosProduto = _produtoApp.GetById(idProd);
            List<ComprasCarrinhoViewModel> carrinhoList = new List<ComprasCarrinhoViewModel>();
            ComprasCarrinhoViewModel partialList = new ComprasCarrinhoViewModel();

            if (!dictCarrinho.ContainsKey(idProd))
            {
                meuCarAtu.prodID = idProd;
                meuCarAtu.codProd = dadosProduto.Codigo;
                meuCarAtu.descProd = dadosProduto.Descricao;
                meuCarAtu.precoProd = dadosProduto.Preco;
                meuCarAtu.qtdProd = qtdProd;

                dictCarrinho.Add(idProd, meuCarAtu);
            }
            else
            {
                qtdAnterior = dictCarrinho[idProd].qtdProd + qtdProd;
                dictCarrinho[idProd].qtdProd = qtdAnterior;
            }

            foreach (var item in dictCarrinho)
            {
                partialList.prodID = item.Value.prodID;
                partialList.codProd = item.Value.codProd;
                partialList.descProd = item.Value.descProd;
                partialList.precoProd = item.Value.precoProd;
                partialList.qtdProd = item.Value.qtdProd;

                carrinhoList.Add(partialList);
            }

            return PartialView("ComprasCarrinho", carrinhoList);
        }

        public ActionResult CarrinhoDel(int idProd)
        {
            if (dictCarrinho.ContainsKey(idProd))
            {
                dictCarrinho.Remove(idProd);
            }

            return PartialView("ComprasCarrinho", dictCarrinho);
        }
    }
}