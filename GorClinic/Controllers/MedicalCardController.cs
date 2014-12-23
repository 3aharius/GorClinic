using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using GorClinic.db.Models.VewModel;
using System.Net;

namespace GorClinic.Controllers
{
    public class MedicalCardController : Controller
    {
        //
        // GET: /MedicalCard/

        private MedicalCardVM _medicalCardVM;
        public MedicalCardVM MedicalCardVM
        {
            get
            {
                return _medicalCardVM ?? (_medicalCardVM = new MedicalCardVM());
            }
        }

        [HttpPost]
        public ActionResult Upsert(Int32? id, Int32 number, int? clientId)
        {
            MedicalCardVMItem item = new MedicalCardVMItem() { MedicalCardId = id, Number = number, ClientId = clientId };
            try
            {
                MedicalCardVM.upsert(item);
            } catch(Exception ex){
                new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
            }
            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }

        [HttpPost]
        public ActionResult Delete(Int32 id)
        {
            MedicalCardVMItem item = new MedicalCardVMItem() { MedicalCardId = id };
            try
            {
                MedicalCardVM.delete(item);
            }
            catch (Exception ex)
            {
                new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
            }
            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }

    }
}
