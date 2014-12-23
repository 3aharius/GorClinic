using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using GorClinic.db.Models.VewModel;

namespace GorClinic.Controllers
{
    public class AreaController : Controller
    {
        //
        // GET: /Area/
        private AreaVM _areaVM;
        public AreaVM AreaVM
        {
            get
            {
                return _areaVM ?? (_areaVM = new AreaVM());
            }
        }

        public ActionResult Index()
        {
            List<AreaVMItem> items = AreaVM.getAllItems();
            return View(items);
        }

        [HttpPost]
        public ActionResult Upsert(Int32? id, Int32 number, string adresses)
        {
            AreaVMItem item = new AreaVMItem() { Id = id, AreaNumber = number, Adresses = adresses};
            AreaVM.upsert(item);
            return null;
        }

        [HttpPost]
        public ActionResult Delete(Int32 id)
        {
            AreaVMItem item = new AreaVMItem() { Id = id };
            AreaVM.delete(item);
            return null;
        }
    }
}
