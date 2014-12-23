using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using GorClinic.db.Models.VewModel;
using System.Web.Script.Serialization;

namespace GorClinic.Controllers
{
    public class DoctorController : Controller
    {
        //
        // GET: /Doctor/

        private DoctorVM _doctorVM;
        public DoctorVM DoctorVM
        {
            get
            {
                return _doctorVM ?? (_doctorVM = new DoctorVM());
            }
        }
        private AreaVM _areaVM;
        public AreaVM AreaVM
        {
            get
            {
                return _areaVM ?? (_areaVM = new AreaVM());
            }
        }
        private SpecializationVM _specializationVM;
        public SpecializationVM SpecializationVM
        {
            get
            {
                return _specializationVM ?? (_specializationVM = new SpecializationVM());
            }
        }
        private CabinetVM _cabinetVM;
        public CabinetVM CabinetVM
        {
            get
            {
                return _cabinetVM ?? (_cabinetVM = new CabinetVM());
            }
        }
        private DepartmentVM _departmentVM;
        public DepartmentVM DepartmentVM
        {
            get
            {
                return _departmentVM ?? (_departmentVM = new DepartmentVM());
            }
        }
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
            //DoctorVMItem vmItem = new DoctorVMItem();
            ViewBag.DoctorVItems = DoctorVM.getAllItems();
            ViewBag.Areas = AreaVM.getAllItems();
            ViewBag.Specializations = SpecializationVM.getAllItems();
            ViewBag.Cabinets = CabinetVM.getAllItems();
            ViewBag.Departments = DepartmentVM.getAllItems();
            ViewBag.DocStatuses = DocStatusVM.getAllItems();
            return View(ViewBag.DoctorVItems);
        }

        [HttpPost]
        public ActionResult Upsert(string jsonDoctor)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            Dictionary<string, string> doctor = (Dictionary<string, string>) serializer.Deserialize(jsonDoctor, typeof(Dictionary<string, string>));
            DoctorVItem item = new DoctorVItem()
                    {
                        FIO = doctor["fio"],
                        Adress = doctor["adress"],
                        MobilePhone = doctor["mPhone"],
                        HomePhone = doctor["hPhone"],
                        Schedule = doctor["schedule"],
                        Specialization = new SpecializationVMItem()
                        {
                            SpecializationId = int.Parse(doctor["specialization"]),
                        },
                        Cabinet = new CabinetVMItem()
                        {
                            CabinetId = int.Parse(doctor["cabinet"]),
                        },
                        Department = new DepartmentVMItem()
                        {
                            DepartmentId = int.Parse(doctor["department"]),
                        },
                        Area = new AreaVMItem()
                        {
                            Id = int.Parse(doctor["area"]),
                        },
                        DocStatus = new DocStatusVMItem()
                        {
                            DocStatusId = int.Parse(doctor["docStatus"]),
                        }
                    };
            if (doctor["id"] != "")
            {
                item.DoctorId = int.Parse(doctor["id"]);
            }
            DoctorVM.upsert(item);
            return null;
        }

        [HttpPost]
        public ActionResult Delete(Int32 id)
        {
            DoctorVItem item = new DoctorVItem() { DoctorId = id };
            DoctorVM.delete(item);
            return null;
        }

    }
}
