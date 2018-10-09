using System;

namespace Smart.API.Adapter.Models
{
    public class PersonModel
    {
        public int ID
        {
            get;
            set;
        }

        /// <summary>
        /// 人员标识
        /// </summary>
        public string PersonId
        {
            get;
            set;
        }

        /// <summary>
        /// 人员姓名
        /// </summary>
        public string PersonName
        {
            get;
            set;
        }

        /// <summary>
        /// 人员编号
        /// </summary>
        public string PersonNo
        {
            get;
            set;
        }

        /// <summary>
        /// 手机号
        /// </summary>
        public string CellPhone
        {
            get;
            set;
        }

        /// <summary>
        /// 电话
        /// </summary>
        public string Tel
        {
            get;
            set;
        }

        /// <summary>
        /// 邮箱
        /// </summary>
        public string Mail
        {
            get;
            set;
        }

        /// <summary>
        /// 部门标识
        /// </summary>
        public string DeptId
        {
            get;
            set;
        }

        /// <summary>
        /// 0：正常
        /// 1：删除
        /// </summary>
        public int Status
        {
            get;
            set;
        }

        public string ThirdPersonId
        {
            get;
            set;
        }

        public DateTime CreateTime
        {
            get;
            set;
        }

        public DateTime ModifyTime
        {
            get;
            set;
        }
    }
}
