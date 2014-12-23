using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using GorClinic.db.Models.VewModel;

namespace GorClinic.Controllers
{
    public class RoleController : Controller
    {
        //
        // GET: /Role/

        private RoleVM _roleVM;
        public RoleVM RoleVM
        {
            get
            {
                return _roleVM ?? (_roleVM = new RoleVM());
            }
        }

        public ActionResult Index()
        {
            List<RoleVMItem> items = RoleVM.getAllItems();
            return View(items);
        }

        [HttpPost]
        public ActionResult Upsert(Int32? id, string name)
        {
            RoleVMItem item = new RoleVMItem() { RoleId = id, Name = name };
            RoleVM.upsert(item);
            return null;
        }

        [HttpPost]
        public ActionResult Delete(Int32? id)
        {
            RoleVMItem item = new RoleVMItem() { RoleId = id };
            RoleVM.delete(item);
            return null;
        }

    }
}
