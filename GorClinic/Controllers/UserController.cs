using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using GorClinic.db.Models.VewModel;

namespace GorClinic.Controllers
{
    public class UserController : Controller
    {
        //
        // GET: /User/

        private UserVM _userVM;
        public UserVM UserVM
        {
            get
            {
                return _userVM ?? (_userVM = new UserVM());
            }
        }

        public ActionResult Index()
        {
            ViewBag.Roles = new RoleVM().getAllItems();
            List<UserVMItem> items = UserVM.getAllItems();
            return View(items);
        }

        [HttpPost]
        public ActionResult Upsert(Int32? id, string username, string password, Int32? roleId, bool isActive)
        {
            UserVMItem item = new UserVMItem() { UserId = id, Username = username, IsActive = isActive, Password = password,
                Role = new RoleVMItem() { RoleId = roleId } };
            UserVM.upsert(item);
            return null;
        }

        [HttpPost]
        public ActionResult Delete(Int32? id)
        {
            UserVMItem item = new UserVMItem() { UserId = id };
            UserVM.delete(item);
            return null;
        }

    }
}
