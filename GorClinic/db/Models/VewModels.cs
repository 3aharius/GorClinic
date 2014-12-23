using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernate;
using System.ComponentModel.DataAnnotations;

using GorClinic.Helper;
using GorClinic.Models.DTO;

namespace GorClinic.db.Models.VewModel
{
    #region Area

    #region AreaVMItem
    public class AreaVMItem
    {
        public virtual Int32? Id { get; set; }
        [Required(ErrorMessage = "Это обязательное поле.")]
        [RegularExpression(@"^\d+$", ErrorMessage = "Допустимы только целочисленные значения.")]
        public virtual Int32 AreaNumber { get; set; }
        [Required(ErrorMessage = "Это обязательное поле.")]
        public virtual String Adresses { get; set; }
    }
    #endregion

    #region AreaVM
    public class AreaVM
    {

        public List<AreaVMItem> getAllItems()
        {
            List<AreaVMItem> items = new List<AreaVMItem>();
            using (ISession session = NHibernateHelper.OpenSession())
            {
                foreach (var item in session.QueryOver<Area>().OrderBy(item => item.AreaNumber).Asc.List<Area>().ToList<Area>())
                {
                    items.Add(new AreaVMItem() { Adresses = item.Adresses, AreaNumber = item.AreaNumber, Id = item.Id });
                }
            }
            return items;
        }

        public void upsert(AreaVMItem item)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                session.SaveOrUpdate(new Area() { Id = item.Id, AreaNumber = item.AreaNumber, Adresses = item.Adresses });
                session.Flush();
            }
        }

        public void delete(AreaVMItem item)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                session.Delete(new Area() { Id = item.Id, AreaNumber = item.AreaNumber, Adresses = item.Adresses });
                session.Flush();
            }
        }

    }
    #endregion

    #endregion

    #region Department

    #region DepartmentVMItem
    public class DepartmentVMItem
    {
        public virtual Int32? DepartmentId { get; set; }
        public virtual String Name { get; set; }
    }
    #endregion

    #region DepartmentVM
    public class DepartmentVM
    {
        public List<DepartmentVMItem> getAllItems()
        {
            List<DepartmentVMItem> items = new List<DepartmentVMItem>();
            using (ISession session = NHibernateHelper.OpenSession())
            {
                foreach (var item in session.QueryOver<Department>().OrderBy(item => item.Name).Asc.List<Department>().ToList<Department>())
                {
                    items.Add(new DepartmentVMItem() { DepartmentId = item.DepartmentId, Name = item.Name });
                }
            }
            return items;
        }

        public void upsert(DepartmentVMItem item)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                session.SaveOrUpdate(new Department() { DepartmentId = item.DepartmentId, Name = item.Name });
                session.Flush();
            }
        }

        public void delete(DepartmentVMItem item)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                session.Delete(new Department() { DepartmentId = item.DepartmentId });
                session.Flush();
            }
        }
    }
    #endregion

    #endregion


    #region Specialization

    #region SpecializationVMItem
    public class SpecializationVMItem
    {
        public virtual Int32? SpecializationId { get; set; }
        public virtual String Name { get; set; }
    }
    #endregion

    #region SpecializationVM
    public class SpecializationVM
    {
        public List<SpecializationVMItem> getAllItems()
        {
            List<SpecializationVMItem> items = new List<SpecializationVMItem>();
            using (ISession session = NHibernateHelper.OpenSession())
            {
                foreach (var item in session.QueryOver<Specialization>().OrderBy(item => item.Name).Asc.List<Specialization>().ToList<Specialization>())
                {
                    items.Add(new SpecializationVMItem() { SpecializationId = item.SpecializationId, Name = item.Name });
                }
            }
            return items;
        }

        public void upsert(SpecializationVMItem item)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                session.SaveOrUpdate(new Specialization() { SpecializationId = item.SpecializationId, Name = item.Name });
                session.Flush();
            }
        }

        public void delete(SpecializationVMItem item)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                session.Delete(new Specialization() { SpecializationId = item.SpecializationId });
                session.Flush();
            }
        }
    }
    #endregion

    #endregion

    #region Cabinet

    #region CabinetVMItem
    public class CabinetVMItem
    {
        public virtual Int32? CabinetId { get; set; }
        public virtual String Number { get; set; }
    }
    #endregion

    #region CabinetVM
    public class CabinetVM
    {
        public List<CabinetVMItem> getAllItems()
        {
            List<CabinetVMItem> items = new List<CabinetVMItem>();
            using (ISession session = NHibernateHelper.OpenSession())
            {
                foreach (var item in session.QueryOver<Cabinet>().OrderBy(item => item.Number).Asc.List<Cabinet>().ToList<Cabinet>())
                {
                    items.Add(new CabinetVMItem() { CabinetId = item.CabinetId, Number = item.Number});
                }
            }
            return items;
        }

        public void upsert(CabinetVMItem item)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                session.SaveOrUpdate(new Cabinet() { CabinetId = item.CabinetId, Number = item.Number });
                session.Flush();
            }
        }

        public void delete(CabinetVMItem item)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                session.Delete(new Cabinet() { CabinetId = item.CabinetId });
                session.Flush();
            }
        }
    }
    #endregion

    #endregion

    #region DocStatus

    #region DocStatusVMItem
    public class DocStatusVMItem
    {
        public virtual Int32? DocStatusId { get; set; }
        public virtual String Status { get; set; }
    }
    #endregion

    #region DocStatusVM
    public class DocStatusVM
    {
        public List<DocStatusVMItem> getAllItems()
        {
            List<DocStatusVMItem> items = new List<DocStatusVMItem>();
            using (ISession session = NHibernateHelper.OpenSession())
            {
                foreach (var item in session.QueryOver<DocStatus>().OrderBy(item => item.Status).Asc.List<DocStatus>().ToList<DocStatus>())
                {
                    items.Add(new DocStatusVMItem() { DocStatusId = item.DocStatusId, Status = item.Status });
                }
            }
            return items;
        }

        public void upsert(DocStatusVMItem item)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                session.SaveOrUpdate(new DocStatus() { DocStatusId = item.DocStatusId, Status = item.Status });
                session.Flush();
            }
        }

        public void delete(DocStatusVMItem item)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                session.Delete(new DocStatus() { DocStatusId = item.DocStatusId });
                session.Flush();
            }
        }
    }
    #endregion

    #endregion

    #region Doctor

    #region DoctorVItem
    public class DoctorVItem
    {
        public virtual Int32? DoctorId { get; set; }
        public virtual String FIO { get; set; }
        public virtual String Adress { get; set; }
        public virtual String HomePhone { get; set; }
        public virtual String MobilePhone { get; set; }
        public virtual String Schedule { get; set; }
        public virtual SpecializationVMItem Specialization { get; set; }
        public virtual CabinetVMItem Cabinet { get; set; }
        public virtual DepartmentVMItem Department { get; set; }
        public virtual AreaVMItem Area { get; set; }
        public virtual DocStatusVMItem DocStatus { get; set; }
    }
    #endregion

    #region DoctorVM
    public class DoctorVM
    {
        public List<DoctorVItem> getAllItems()
        {
            List<DoctorVItem> items = new List<DoctorVItem>();
            using (ISession session = NHibernateHelper.OpenSession())
            {
                var dox = session.QueryOver<Doctor>().OrderBy(item => item.FIO).Asc.List<Doctor>();
                foreach (var item in dox)
                {
                    items.Add(new DoctorVItem()
                    {
                        DoctorId = item.DoctorId,
                        FIO = item.FIO,
                        Adress = item.Adress,
                        MobilePhone = item.MobilePhone,
                        HomePhone = item.HomePhone,
                        Schedule = item.Schedule,
                        Specialization = new SpecializationVMItem()
                        {
                            SpecializationId = item.Specialization.SpecializationId,
                            Name = item.Specialization.Name
                        },
                        Cabinet = new CabinetVMItem()
                        {
                            CabinetId = item.Cabinet.CabinetId,
                            Number = item.Cabinet.Number
                        },
                        Department = new DepartmentVMItem()
                        {
                            DepartmentId = item.Department.DepartmentId,
                            Name = item.Department.Name
                        },
                        Area = new AreaVMItem()
                        {
                            Id = item.Area.Id,
                            AreaNumber = item.Area.AreaNumber,
                            Adresses = item.Area.Adresses
                        },
                        DocStatus = new DocStatusVMItem()
                        {
                            DocStatusId = item.DocStatus.DocStatusId,
                            Status = item.DocStatus.Status
                        }
                    });
                }
            }
            return items;
        }

        public void upsert(DoctorVItem item)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                session.SaveOrUpdate(new Doctor()
                {
                    DoctorId = item.DoctorId,
                    FIO = item.FIO,
                    Adress = item.Adress,
                    MobilePhone = item.MobilePhone,
                    HomePhone = item.HomePhone,
                    Schedule = item.Schedule,
                    Specialization = new Specialization()
                    {
                        SpecializationId = item.Specialization.SpecializationId,
                        Name = item.Specialization.Name
                    },
                    Cabinet = new Cabinet()
                    {
                        CabinetId = item.Cabinet.CabinetId,
                        Number = item.Cabinet.Number
                    },
                    Department = new Department()
                    {
                        DepartmentId = item.Department.DepartmentId,
                        Name = item.Department.Name
                    },
                    Area = new Area()
                    {
                        Id = item.Area.Id,
                        AreaNumber = item.Area.AreaNumber,
                        Adresses = item.Area.Adresses
                    },
                    DocStatus = new DocStatus()
                    {
                        DocStatusId = item.DocStatus.DocStatusId,
                        Status = item.DocStatus.Status
                    }
                });
                session.Flush();
            }
        }

        public void delete(DoctorVItem item)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                session.Delete(new Doctor() { DoctorId = item.DoctorId});
                session.Flush();
            }
        }
    }
    #endregion

    #endregion

    #region Client

    #region ClientVMItem
    public class ClientVMItem
    {
        public virtual Int32? ClientId { get; set; }
        public virtual String FIO { get; set; }
        public virtual String Adress { get; set; }
        public virtual List<MedicalCardVMItem> MedicalCards { get; set; }
    }
    #endregion

    #region ClientVM
    public class ClientVM
    {
        public List<ClientVMItem> getAllItems()
        {
            List<ClientVMItem> items = new List<ClientVMItem>();
            using (ISession session = NHibernateHelper.OpenSession())
            {
                foreach (var item in session.QueryOver<Client>().OrderBy(item => item.FIO).Asc.List<Client>())
                {
                    List<MedicalCardVMItem> cards = new MedicalCardVM().getAllItemsForClient(item.ClientId);
                    items.Add(new ClientVMItem() { ClientId = item.ClientId, FIO = item.FIO, Adress = item.Adress, MedicalCards = cards });
                }
            }
            return items;
        }

        public void upsert(ClientVMItem item)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                session.SaveOrUpdate(new Client() { ClientId = item.ClientId, FIO = item.FIO, Adress = item.Adress });
                session.Flush();
            }
        }

        public void delete(ClientVMItem item)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                session.Delete(new Client() { ClientId = item.ClientId});
                session.Flush();
            }
        }
    }
    #endregion

    #endregion

    #region MedicalCard

    #region MedicalCardVMItem
    public class MedicalCardVMItem
    {
        public virtual Int32? MedicalCardId { get; set; }
        public virtual Int32 Number { get; set; }
        public virtual Int32? ClientId { get; set; }
    }
    #endregion

    #region MedicalCardVM
    public class MedicalCardVM
    {
        public List<MedicalCardVMItem> getAllItems()
        {
            List<MedicalCardVMItem> items = new List<MedicalCardVMItem>();
            using (ISession session = NHibernateHelper.OpenSession())
            {
                foreach (var item in session.QueryOver<MedicalCard>().OrderBy(item => item.Number).Asc.List<MedicalCard>())
                {
                    items.Add(new MedicalCardVMItem() { MedicalCardId = item.MedicalCardId, Number = item.Number, ClientId = item.Client.ClientId });
                }
            }
            return items;
        }

        public List<MedicalCardVMItem> getAllItemsForClient(int? clientId)
        {
            List<MedicalCardVMItem> items = new List<MedicalCardVMItem>();
            using (ISession session = NHibernateHelper.OpenSession())
            {
                foreach (var item in session.QueryOver<MedicalCard>().Where(card => card.Client.ClientId == clientId).OrderBy(item => item.Number).Asc.List<MedicalCard>())
                {
                    items.Add(new MedicalCardVMItem() { MedicalCardId = item.MedicalCardId, Number = item.Number, ClientId = item.Client.ClientId });
                }
            }
            return items;
        }

        public void upsert(MedicalCardVMItem item)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                session.SaveOrUpdate(new MedicalCard() { MedicalCardId = item.MedicalCardId, Number = item.Number, Client = new Client() { ClientId = item.ClientId } });
                session.Flush();
            }
        }

        public void delete(MedicalCardVMItem item)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                session.Delete(new MedicalCard() { MedicalCardId = item.MedicalCardId });
                session.Flush();
            }
        }
    }
    #endregion

    #endregion

    #region Role

    #region RoleVMItem
    public class RoleVMItem
    {
        public virtual Int32? RoleId { get; set; }
        public virtual String Name { get; set; }
    }
    #endregion

    #region RoleVM
    public class RoleVM
    {
        public List<RoleVMItem> getAllItems()
        {
            List<RoleVMItem> items = new List<RoleVMItem>();
            using (ISession session = NHibernateHelper.OpenSession())
            {
                foreach (var item in session.QueryOver<Role>().OrderBy(item => item.Name).Asc.List<Role>())
                {
                    items.Add(new RoleVMItem() { RoleId = item.RoleId, Name = item.Name });
                }
            }
            return items;
        }

        public void upsert(RoleVMItem item)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                session.SaveOrUpdate(new Role() { RoleId = item.RoleId, Name = item.Name });
                session.Flush();
            }
        }

        public void delete(RoleVMItem item)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                session.Delete(new Role() { RoleId = item.RoleId });
                session.Flush();
            }
        }
    }
    #endregion

    #endregion

    #region Page

    #region PageVMItem
    public class PageVMItem
    {
        public virtual Int32? PageId { get; set; }
        public virtual String Url { get; set; }
    }
    #endregion

    #region PageVM
    public class PageVM
    {
        public List<PageVMItem> getAllItems()
        {
            List<PageVMItem> items = new List<PageVMItem>();
            using (ISession session = NHibernateHelper.OpenSession())
            {
                foreach (var item in session.QueryOver<Page>().OrderBy(item => item.Url).Asc.List<Page>())
                {
                    items.Add(new PageVMItem() { PageId = item.PageId, Url = item.Url });
                }
            }
            return items;
        }

        public void upsert(PageVMItem item)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                session.SaveOrUpdate(new Page() { PageId = item.PageId, Url = item.Url });
                session.Flush();
            }
        }

        public void delete(PageVMItem item)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                session.Delete(new Page() { PageId = item.PageId });
                session.Flush();
            }
        }
    }
    #endregion

    #endregion

    #region Permission

    #region PermissionVMItem
    public class PermissionVMItem
    {
        public virtual Int32? PermissionId { get; set; }
        public virtual Int32? RoleId { get; set; }
        public virtual String RoleName { get; set; }
        public virtual Int32? PageId { get; set; }
        public virtual String PageUrl { get; set; }
        public virtual bool IsAllaw { get; set; }
    }
    #endregion

    #region PermissionVM
    public class PermissionVM
    {
        public List<PermissionVMItem> getAllItems()
        {
            List<PermissionVMItem> items = new List<PermissionVMItem>();
            using (ISession session = NHibernateHelper.OpenSession())
            {
                foreach (var item in session.QueryOver<Permission>().OrderBy(item => item.PermissionId).Asc.List<Permission>())
                {
                    items.Add(new PermissionVMItem() { PermissionId = item.PermissionId, IsAllaw = item.IsAllaw,
                        PageId = item.Page.PageId, PageUrl = item.Page.Url, 
                        RoleId = item.Role.RoleId, RoleName = item.Role.Name});
                }
            }
            return items;
        }

        public List<PermissionVMItem> getItemsForRole(Int32? roleId)
        {
            List<PermissionVMItem> items = new List<PermissionVMItem>();
            using (ISession session = NHibernateHelper.OpenSession())
            {
                foreach (var item in session.QueryOver<Permission>().Where(item => item.Role.RoleId == roleId)
                    .OrderBy(item => item.PermissionId).Asc.List<Permission>())
                {
                    items.Add(new PermissionVMItem()
                    {
                        PermissionId = item.PermissionId,
                        IsAllaw = item.IsAllaw,
                        PageId = item.Page.PageId,
                        PageUrl = item.Page.Url,
                        RoleId = item.Role.RoleId,
                        RoleName = item.Role.Name
                    });
                }
            }
            return items;
        }

        public void upsert(PermissionVMItem item)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                session.SaveOrUpdate(new Permission()
                {
                    PermissionId = item.PermissionId,
                    IsAllaw = item.IsAllaw,
                    Page = new Page { PageId = item.PageId },
                    Role = new Role { RoleId = item.RoleId }
                });
                session.Flush();
            }
        }

        public void upsert(IList<PermissionVMItem> items)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                foreach(PermissionVMItem item in items) {
                    session.SaveOrUpdate(new Permission()
                    {
                        PermissionId = item.PermissionId,
                        IsAllaw = item.IsAllaw
                    });
                }
                session.Flush();
            }
        }

    }
    #endregion

    #endregion

    #region User

    #region UserVMItem
    public class UserVMItem
    {
        public virtual Int32? UserId { get; set; }
        public virtual String Username { get; set; }
        public virtual String Password { get; set; }
        public virtual RoleVMItem Role { get; set; }
        public virtual bool IsActive { get; set; }
    }
    #endregion

    #region UserVM
    public class UserVM
    {
        public List<UserVMItem> getAllItems()
        {
            List<UserVMItem> items = new List<UserVMItem>();
            using (ISession session = NHibernateHelper.OpenSession())
            {
                foreach (var item in session.QueryOver<User>().OrderBy(item => item.Username).Asc.List<User>())
                {
                    items.Add(new UserVMItem() { UserId = item.UserId, Username = item.Username, Password = item.Password, IsActive = item.IsActive,
                        Role = new RoleVMItem() { RoleId = item.Role.RoleId, Name = item.Role.Name} });
                }
            }
            return items;
        }

        public void upsert(UserVMItem item)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                session.SaveOrUpdate(new User()
                {
                    UserId = item.UserId,
                    Username = item.Username,
                    Password = item.Password,
                    IsActive = item.IsActive,
                    Role = new Role() { RoleId = item.Role.RoleId, Name = item.Role.Name }
                });
                session.Flush();
            }
        }

        public void delete(UserVMItem item)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                session.Delete(new User() { UserId = item.UserId });
                session.Flush();
            }
        }
    }
    #endregion

    #endregion

    #region Topic

    #region TopicVMItem
    public class TopicVMItem
    {
        public virtual Int32? TopicId { get; set; }
        public virtual String Content { get; set; }
        public virtual string Title { get; set; }
    }
    #endregion

    #region TopicVM
    public class TopicVM
    {
        public List<TopicVMItem> getAllItems()
        {
            List<TopicVMItem> items = new List<TopicVMItem>();
            using (ISession session = NHibernateHelper.OpenSession())
            {
                foreach (var item in session.QueryOver<Topic>().OrderBy(item => item.TopicId).Asc.List<Topic>())
                {
                    items.Add(new TopicVMItem() { TopicId = item.TopicId, Content = item.Content, Title = item.Title });
                }
            }
            return items;
        }

        public void upsert(TopicVMItem item)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                session.SaveOrUpdate(new Topic() { TopicId = item.TopicId, Content = item.Content, Title = item.Title });
                session.Flush();
            }
        }

        public void delete(TopicVMItem item)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                session.Delete(new Topic() { TopicId = item.TopicId });
                session.Flush();
            }
        }
    }
    #endregion

    #endregion

    #region Ticket

    #region TicketVMItem
    public class TicketVMItem
    {
        public virtual Int32? TicketId { get; set; }
        public virtual DateTime ReceptionDate { get; set; }
        public virtual DoctorVItem DoctorVItem { get; set; }
        public virtual ClientVMItem ClientVMItem { get; set; }
    }
    #endregion

    #region TicketVM
    public class TicketVM
    {
        public List<TicketVMItem> getAllItems()
        {
            List<TicketVMItem> items = new List<TicketVMItem>();
            using (ISession session = NHibernateHelper.OpenSession())
            {
                foreach (var item in session.QueryOver<Ticket>().OrderBy(item => item.ReceptionDate).Asc.List<Ticket>())
                {
                    items.Add(new TicketVMItem()
                    {
                        TicketId = item.TicketId,
                        ReceptionDate = item.ReceptionDate,
                        DoctorVItem = new DoctorVItem() { 
                            DoctorId = item.Doctor.DoctorId,
                            Area = new AreaVMItem() {
                                Id = item.Doctor.Area.Id,
                                AreaNumber = item.Doctor.Area.AreaNumber,
                                Adresses = item.Doctor.Area.Adresses
                            },
                            
                        }
                    });
                }
            }
            return items;
        }

        public void upsert(TopicVMItem item)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                session.SaveOrUpdate(new Topic() { TopicId = item.TopicId, Content = item.Content, Title = item.Title });
                session.Flush();
            }
        }

        public void delete(TopicVMItem item)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                session.Delete(new Topic() { TopicId = item.TopicId });
                session.Flush();
            }
        }
    }
    #endregion

    #endregion

}