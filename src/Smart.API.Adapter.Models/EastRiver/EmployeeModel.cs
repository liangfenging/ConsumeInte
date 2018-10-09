
using System;
namespace Smart.API.Adapter.Models.EastRiver
{
    public class EmployeeModel
    {
        /// <summary>
        /// 工号,长度32位
        /// 必填
        /// </summary>
        public string emp_id
        {
            get;
            set;
        }

        private string oldCardId = "-1";
        /// <summary>
        /// 默认值-1,兼容原依时利考勤
        /// </summary>
        public string card_id
        {
            get { return oldCardId; }
            set { oldCardId = value; }
        }

        /// <summary>
        /// 姓名
        /// 必填
        /// </summary>
        public string emp_fname
        {
            get;
            set;
        }

        /// <summary>
        /// 0:身份证
        /// 1：学生证
        /// 2：教师证
        /// </summary>
        public int IDType
        {
            get;
            set;
        }

        /// <summary>
        /// 身份证号
        /// </summary>
        public string id_card
        {
            get;
            set;
        }

        /// <summary>
        /// 默认值0
        /// 是否免打卡
        /// </summary>
        public int no_sign
        {
            get;
            set;
        }

        /// <summary>
        /// 部门编号
        /// 必填
        /// </summary>
        public string depart_id
        {
            get;
            set;
        }

        public string status_id
        {
            get;
            set;
        }

        public DateTime? leave_date
        {
            get;
            set;
        }

        public string dimission_type_id
        {
            get;
            set;
        }
    }
}
