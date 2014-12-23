using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using GorClinic.db.Models.VewModel;

namespace GorClinic.Controllers
{
    public class DocStatusController : Controller
    {
        //
        // GET: /DocStatus/

        private DocStatusVM _docStatusVM;
        public DocStatusVM DocStatusVM
        {
            get
            {
                return _docStatusVM ?? (_docStatusVM = new DocStatusVM());
            }
        }

        public ActionResult Index()
        {
            List<DocStatusVMItem> items = DocStatusVM.getAllItems();
            return View(items);
        }

        [HttpPost]
        public ActionResult Upsert(Int32? id, string status)
        {
            DocStatusVMItem item = new DocStatusVMItem() { DocStatusId = id, Status = status };
            DocStatusVM.upsert(item);
            return null;
        }

        [HttpPost]
        public ActionResult Delete(Int32 id)
        {
            DocStatusVMItem item = new DocStatusVMItem() { DocStatusId = id };
            DocStatusVM.delete(item);
            return null;
        }

    }
}
