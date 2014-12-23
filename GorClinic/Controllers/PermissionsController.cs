using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using GorClinic.db.Models.VewModel;

namespace GorClinic.Controllers
{
    public class PermissionsController : Controller
    {
        //
        // GET: /Permissions/

        private PermissionVM _permissionVM;
        public PermissionVM PermissionVM
        {
            get
            {
                return _permissionVM ?? (_permissionVM = new PermissionVM());
            }
        }

        public ActionResult Index(Int32? role_id)
        {
            List<PermissionVMItem> items = PermissionVM.getItemsForRole(role_id);
            return View(items);
        }

        [HttpPost]
        public ActionResult Upsert(IList<PermissionVMItem> permissions)
        {
            PermissionVM.upsert(permissions);
            return null;
        }

    }
}
