using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using GorClinic.db.Models.VewModel;

namespace GorClinic.Controllers
{
    public class SpecializationController : Controller
    {
        //
        // GET: /Specialization/

        private SpecializationVM _specializationVM;
        public SpecializationVM SpecializationVM
        {
            get
            {
                return _specializationVM ?? (_specializationVM = new SpecializationVM());
            }
        }

        public ActionResult Index()
        {
            List<SpecializationVMItem> items = SpecializationVM.getAllItems();
            return View(items);
        }

        [HttpPost]
        public ActionResult Upsert(Int32? id, string name)
        {
            SpecializationVMItem item = new SpecializationVMItem() { SpecializationId = id, Name = name };
            SpecializationVM.upsert(item);
            return null;
        }

        [HttpPost]
        public ActionResult Delete(Int32 id)
        {
            SpecializationVMItem item = new SpecializationVMItem() { SpecializationId = id };
            SpecializationVM.delete(item);
            return null;
        }

    }
}
