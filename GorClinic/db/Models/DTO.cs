using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProtoBuf;

namespace GorClinic.Models.DTO
{
    #region Area
    [ProtoContract]
    public class Area
    {
        [ProtoMember(1)]
        public virtual Int32? Id { get; set; }
        [ProtoMember(2)]
        public virtual Int32 AreaNumber { get; set; }
        [ProtoMember(3)]
        public virtual String Adresses { get; set; }
    }
    #endregion

    #region Department
    [ProtoContract]
    public class Department
    {
        [ProtoMember(1)]
        public virtual Int32? DepartmentId { get; set; }
        [ProtoMember(2)]
        public virtual String Name { get; set; }
    }
    #endregion

    #region Specialization
    [ProtoContract]
    public class Specialization
    {
        [ProtoMember(1)]
        public virtual Int32? SpecializationId { get; set; }
        [ProtoMember(2)]
        public virtual String Name { get; set; }
    }
    #endregion

    #region Cabinet
    [ProtoContract]
    public class Cabinet
    {
        [ProtoMember(1)]
        public virtual Int32? CabinetId { get; set; }
        [ProtoMember(2)]
        public virtual String Number { get; set; }
    }
    #endregion

    #region DocStatus
    [ProtoContract]
    public class DocStatus
    {
        [ProtoMember(1)]
        public virtual Int32? DocStatusId { get; set; }
        [ProtoMember(2)]
        public virtual String Status { get; set; }
    }
    #endregion

    #region Doctor
    [ProtoContract]
    public class Doctor
    {
        [ProtoMember(1)]
        public virtual Int32? DoctorId { get; set; }
        [ProtoMember(2)]
        public virtual String FIO { get; set; }
        [ProtoMember(3)]
        public virtual String Adress { get; set; }
        [ProtoMember(4)]
        public virtual String HomePhone { get; set; }
        [ProtoMember(5)]
        public virtual String MobilePhone { get; set; }
        [ProtoMember(6)]
        public virtual String Schedule { get; set; }
        [ProtoMember(7)]
        public virtual Specialization Specialization { get; set; }
        [ProtoMember(8)]
        public virtual Cabinet Cabinet { get; set; }
        [ProtoMember(9)]
        public virtual Department Department { get; set; }
        [ProtoMember(10)]
        public virtual Area Area { get; set; }
        [ProtoMember(11)]
        public virtual DocStatus DocStatus { get; set; }
    }
    #endregion

    #region MedicalCard
    [ProtoContract]
    public class MedicalCard
    {
        [ProtoMember(1)]
        public virtual Int32? MedicalCardId { get; set; }
        [ProtoMember(2)]
        public virtual Int32 Number { get; set; }
        [ProtoMember(3)]
        public virtual Client Client { get; set; }
    }
    #endregion

    #region Client
    [ProtoContract]
    public class Client
    {
        [ProtoMember(1)]
        public virtual Int32? ClientId { get; set; }
        [ProtoMember(2)]
        public virtual String FIO { get; set; }
        [ProtoMember(3)]
        public virtual String Adress { get; set; }
    }
    #endregion

    #region Ticket
    [ProtoContract]
    public class Ticket
    {
        [ProtoMember(1)]
        public virtual Int32? TicketId { get; set; }
        [ProtoMember(2)]
        public virtual DateTime ReceptionDate { get; set; }
        [ProtoMember(3)]
        public virtual Doctor Doctor { get; set; }
        [ProtoMember(4)]
        public virtual Client Client { get; set; }
    }
    #endregion

    #region Role
    [ProtoContract]
    public class Role
    {
        [ProtoMember(1)]
        public virtual Int32? RoleId { get; set; }
        [ProtoMember(2)]
        public virtual String Name { get; set; }
    }
    #endregion

    #region Page
    [ProtoContract]
    public class Page
    {
        [ProtoMember(1)]
        public virtual Int32? PageId { get; set; }
        [ProtoMember(2)]
        public virtual String Url { get; set; }
    }
    #endregion

    #region Permission
    [ProtoContract]
    public class Permission
    {
        [ProtoMember(1)]
        public virtual Int32? PermissionId { get; set; }
        [ProtoMember(2)]
        public virtual Role Role { get; set; }
        [ProtoMember(3)]
        public virtual Page Page { get; set; }
        [ProtoMember(4)]
        public virtual bool IsAllaw { get; set; }
    }
    #endregion

    #region User
    [ProtoContract]
    public class User
    {
        [ProtoMember(1)]
        public virtual Int32? UserId { get; set; }
        [ProtoMember(2)]
        public virtual String Username { get; set; }
        [ProtoMember(3)]
        public virtual String Password { get; set; }
        [ProtoMember(4)]
        public virtual Role Role { get; set; }
        [ProtoMember(5)]
        public virtual bool IsActive { get; set; }
    }
    #endregion

    #region Topic
    [ProtoContract]
    public class Topic
    {
        [ProtoMember(1)]
        public virtual Int32? TopicId { get; set; }
        [ProtoMember(2)]
        public virtual String Content { get; set; }
        [ProtoMember(3)]
        public virtual string Title { get; set; }
    }
    #endregion
}