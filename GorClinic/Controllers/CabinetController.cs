using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using GorClinic.db.Models.VewModel;

namespace GorClinic.Controllers
{
    public class CabinetController : Controller
    {
        //
        // GET: /Cabinet/

        private CabinetVM _cabinetVM;
        public CabinetVM CabinetVM
        {
            get
            {
                return _cabinetVM ?? (_cabinetVM = new CabinetVM());
            }
        }

        public ActionResult Index()
        {
            List<CabinetVMItem> items = CabinetVM.getAllItems();
            return View(items);
        }

        [HttpPost]
        public ActionResult Upsert(Int32? id, string number)
        {
            CabinetVMItem item = new CabinetVMItem() { CabinetId = id, Number = number };
            CabinetVM.upsert(item);
            return null;
        }

        [HttpPost]
        public ActionResult Delete(Int32 id)
        {
            CabinetVMItem item = new CabinetVMItem() { CabinetId = id };
            CabinetVM.delete(item);
            return null;
        }

    }
}
