using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using GorClinic.db.Models.VewModel;

namespace GorClinic.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        private TopicVM _topicVM;
        public TopicVM TopicVM
        {
            get
            {
                return _topicVM ?? (_topicVM = new TopicVM());
            }
        }

        public ActionResult Index()
        {
            List<TopicVMItem> items = TopicVM.getAllItems();
            return View(items);
        }

        [HttpPost]
        public ActionResult Upsert(Int32? id, string title, string content)
        {
            TopicVMItem item = new TopicVMItem() { TopicId = id, Title = title, Content = content };
            TopicVM.upsert(item);
            return null;
        }

        [HttpPost]
        public ActionResult Delete(Int32? id)
        {
            TopicVMItem item = new TopicVMItem() { TopicId = id };
            TopicVM.delete(item);
            return null;
        }

    }
}
