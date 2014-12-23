using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using GorClinic.db.Models.VewModel;

namespace GorClinic.Controllers
{
    public class PageController : Controller
    {
        //
        // GET: /Page/

        private PageVM _pageVM;
        public PageVM PageVM
        {
            get
            {
                return _pageVM ?? (_pageVM = new PageVM());
            }
        }

        public ActionResult Index()
        {
            List<PageVMItem> items = PageVM.getAllItems();
            return View(items);
        }

        [HttpPost]
        public ActionResult Upsert(Int32? id, string url)
        {
            PageVMItem item = new PageVMItem() { PageId = id, Url = url };
            PageVM.upsert(item);
            return null;
        }

        [HttpPost]
        public ActionResult Delete(Int32? id)
        {
            PageVMItem item = new PageVMItem() { PageId = id};
            PageVM.delete(item);
            return null;
        }

    }
}
