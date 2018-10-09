
using System;
namespace Smart.API.Adapter.Models
{
    public class DepartmentModel
    {
        public int ID
        {
            get;
            set;
        }

        /// <summary>
        /// 部门名称
        /// </summary>
        public string DeptName
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
        /// 父节点 DeptId
        /// </summary>
        public string ParentId
        {
            get;
            set;
        }

        /// <summary>
        /// 部门编号
        /// </summary>
        public string DeptNo
        {
            get;
            set;
        }

        /// <summary>
        /// 状态
        /// 0：正常
        /// 1：删除
        /// </summary>
        public int Status
        {
            get;
            set;
        }

        /// <summary>
        /// 是否根节点
        /// 1：是根结点
        /// 其他不是
        /// </summary>
        public int IsRoot
        {
            get;
            set;
        }

        /// <summary>
        /// 集成第三方的部门标识
        /// </summary>
        public string ThirdDeptId
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
