using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using GorClinic.db.Models.VewModel;

namespace GorClinic.Controllers
{
    public class ClientController : Controller
    {
        //
        // GET: /Client/

        private ClientVM _clientVM;
        public ClientVM ClientVM
        {
            get
            {
                return _clientVM ?? (_clientVM = new ClientVM());
            }
        }

        public ActionResult Index()
        {
            List<ClientVMItem> items = ClientVM.getAllItems();
            return View(items);
        }

        [HttpPost]
        public ActionResult Upsert(Int32? id, string fio, string adress)
        {
            ClientVMItem item = new ClientVMItem() { ClientId = id, FIO = fio, Adress = adress };
            ClientVM.upsert(item);
            return null;
        }

        [HttpPost]
        public ActionResult Delete(Int32 id)
        {
            ClientVMItem item = new ClientVMItem() { ClientId = id };
            ClientVM.delete(item);
            return null;
        }

    }
}
