using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Projeto.Web.Models;
using Projeto.Entities;
using Projeto.DAL.Persistence;
using Projeto.Web.Models.ModelCesta;

namespace Projeto.Web.Controllers
{
    public class ProdutoController : Controller
    {

        public ActionResult Cadastro()
        {
            return View();
        }


        public ActionResult Loja()
        {
            var lista = new List<ProdutoViewModelContulta>();

            try
            {
                ProdutoDal d = new ProdutoDal();
                foreach (Produto p in d.FindAll())
                {
                    var model = new ProdutoViewModelContulta();
                    model.IdProduto = p.IdProduto;
                    model.Nome = p.Nome;
                    model.Preco = p.Preco;
                    model.Foto = p.Foto;

                    lista.Add(model);
                }

                
            }
            catch (Exception ex)
            {
                ViewBag.Mensagem = ex.Message;
            }
            return View(lista);
        }

        // GET : /Produto/Cesta
        public ActionResult Cesta()
        {
            return View();
        }

        //POST : /Produto/CadastarProduto
        [HttpPost]
        public ActionResult CadastrarProduto(ProdutoViewModelCadastro model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Produto p = new Produto();
                    p.Nome = model.Nome;
                    p.Preco = model.Preco;
                    p.Foto = Guid.NewGuid().ToString() + ".jpg";
                    p.DataCadastro = DateTime.Now;

                    ProdutoDal d = new ProdutoDal();

                    d.Insert(p);

                    model.Foto.SaveAs(HttpContext.Server.MapPath("/Images/") + p.Foto);
                    ViewBag.Mensagem = "Produto " + p.Nome + ", cadastrado com sucesso.";

                    ModelState.Clear();//Limpando os campos
                }
                catch (Exception ex)
                {
                    ViewBag.Mensagem = ex.Message;
                }
            }

            return View("Cadastro");
        }

        [HttpGet]//Pega pela url
        public ActionResult Comprar(int id)
        {

            try
            {

                ProdutoDal d = new ProdutoDal();
                Produto p = d.FindById(id);

                ItemCesta item = new ItemCesta();
                item.IdProduto = p.IdProduto;
                item.Nome = p.Nome;
                item.Preco = p.Preco;
                item.Quantidade = 1;
                item.Foto = p.Foto;

                CestaCompras c = new CestaCompras();
                c.ItensCesta = new List<ItemCesta>();

                if (Session["cesta"] != null)
                {
                    c = (CestaCompras)Session["cesta"];
                }

                
                ItemCesta itemExistente = c.ItensCesta
                                             .Where(i => i.IdProduto == item.IdProduto)
                                             .FirstOrDefault();
                if (itemExistente == null)
                {
                    c.ItensCesta.Add(item);

                }
                else
                {
                    itemExistente.Quantidade++;
                }
                
                Session.Add("cesta", c);
            }
            catch (Exception ex)
            {
                ViewBag.Mensagem = ex.Message;
            }
            return View("Cesta");
        }
    }
}