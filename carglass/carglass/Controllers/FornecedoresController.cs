using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using carglass.Models;

namespace carglass.Controllers
{
    public class FornecedoresController : Controller
    {
        private BD_Carglass db = new BD_Carglass();

        // GET: Fornecedores
        public ActionResult Index()
        {
            var fornecedor = db.Fornecedor.Include(f => f.Empresa).Include(f => f.FornecedorPF);
            return View(fornecedor.ToList());
        }

        // GET: Fornecedores/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fornecedor fornecedor = db.Fornecedor.Find(id);
            if (fornecedor == null)
            {
                return HttpNotFound();
            }
            return View(fornecedor);
        }

        // GET: Fornecedores/Create
        public ActionResult Create()
        {
            ViewBag.ID_EMPRESA = new SelectList(db.Empresa, "ID_EMPRESA", "NOME_FANTASIA");
            ViewBag.ID_FORNECEDOR = new SelectList(db.FornecedorPF, "ID_FORNECEDOR", "NOME");
            return View();
        }

        // POST: Fornecedores/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_FORNECEDOR,ID_EMPRESA,NOME,CPFCNPJ,DHCADASTRO")] Fornecedor fornecedor, [Bind(Include = "ID_FORNECEDOR,RG,DTNASCIMENTO")] FornecedorPF fornecedorpf)
        {

            if (ModelState.IsValid)
            {
                fornecedor.Empresa = db.Empresa.Find(fornecedor.ID_EMPRESA);


                if (
                        (fornecedor.Empresa.UF == "RJ" || fornecedor.Empresa.UF == "MG" || fornecedor.Empresa.UF == "RS")
                        &&
                        (fornecedor.CPFCNPJ.Length == 11)
                        &&
                        (DateTime.Now.Year - fornecedorpf.DTNASCIMENTO.Year) < 18
                        )
                {
                    ModelState.AddModelError("Validacao", "O fornecedor deve ter idade maior que 18 anos");
                    return RedirectToAction(nameof(Create));
                }

                fornecedor.DHCADASTRO = DateTime.Now;
                db.Fornecedor.Add(fornecedor);
                db.SaveChanges();


                fornecedorpf.ID_FORNECEDOR = fornecedor.ID_FORNECEDOR;
                db.FornecedorPF.Add(fornecedorpf);
                db.SaveChanges();


                return RedirectToAction("Index");
            }

            ViewBag.ID_EMPRESA = new SelectList(db.Empresa, "ID_EMPRESA", "NOME_FANTASIA", fornecedor.ID_EMPRESA);
            ViewBag.ID_FORNECEDOR = new SelectList(db.FornecedorPF, "ID_FORNECEDOR", "NOME", fornecedor.ID_FORNECEDOR);
            return View(fornecedor);
        }

        // GET: Fornecedores/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fornecedor fornecedor = db.Fornecedor.Find(id);
            if (fornecedor == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_EMPRESA = new SelectList(db.Empresa, "ID_EMPRESA", "UF", fornecedor.ID_EMPRESA);
            ViewBag.ID_FORNECEDOR = new SelectList(db.FornecedorPF, "ID_FORNECEDOR", "RG", fornecedor.ID_FORNECEDOR);
            return View(fornecedor);
        }

        // POST: Fornecedores/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_FORNECEDOR,ID_EMPRESA,NOME,CPFCNPJ,DHCADASTRO")] Fornecedor fornecedor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fornecedor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_EMPRESA = new SelectList(db.Empresa, "ID_EMPRESA", "UF", fornecedor.ID_EMPRESA);
            ViewBag.ID_FORNECEDOR = new SelectList(db.FornecedorPF, "ID_FORNECEDOR", "RG", fornecedor.ID_FORNECEDOR);
            return View(fornecedor);
        }

        // GET: Fornecedores/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fornecedor fornecedor = db.Fornecedor.Find(id);
            if (fornecedor == null)
            {
                return HttpNotFound();
            }
            return View(fornecedor);
        }

        // POST: Fornecedores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Fornecedor fornecedor = db.Fornecedor.Find(id);
            db.Fornecedor.Remove(fornecedor);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
