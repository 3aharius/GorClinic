using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using GorClinic.db.Models.VewModel;

namespace GorClinic.Controllers
{
    public class DepartmentController : Controller
    {
        //
        // GET: /Department/

        private DepartmentVM _departmentVM;
        public DepartmentVM DepartmentVM
        {
            get
            {
                return _departmentVM ?? (_departmentVM = new DepartmentVM());
            }
        }

        public ActionResult Index()
        {
            List<DepartmentVMItem> items = DepartmentVM.getAllItems();
            return View(items);
        }

        [HttpPost]
        public ActionResult Upsert(Int32? id, string name)
        {
            DepartmentVMItem item = new DepartmentVMItem() { DepartmentId = id, Name = name };
            DepartmentVM.upsert(item);
            return null;
        }

        [HttpPost]
        public ActionResult Delete(Int32 id)
        {
            DepartmentVMItem item = new DepartmentVMItem() { DepartmentId = id };
            DepartmentVM.delete(item);
            return null;
        }

    }
}
