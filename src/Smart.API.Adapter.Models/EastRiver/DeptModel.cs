
namespace Smart.API.Adapter.Models.EastRiver
{
    public class DeptModel
    {
        /// <summary>
        /// 部门编号
        /// 0：第一级不骂你
        /// 001：第二级部门
        /// 00101：第三级部门
        /// 以此类推，每两位代表一级部门
        /// </summary>
        public string depart_id
        {
            get;
            set;
        }

        /// <summary>
        /// 部门标识（可空），长度30
        /// </summary>
        public string inside_id
        {
            get;
            set;
        }

        /// <summary>
        /// 分组标识，可为空，长度8
        /// </summary>
        public string group_id
        {
            get;
            set;
        }


        /// <summary>
        /// 部门名称，必填，长度50
        /// </summary>
        public string depart_name
        {
            get;
            set;
        }

        /// <summary>
        /// 部门负责人，可为空，长度10
        /// </summary>
        public string principal
        {
            get;
            set;
        }

        /// <summary>
        /// 工号前缀，可为空。长度3
        /// </summary>
        public string emp_prefix
        {
            get;
            set;
        }

    }
}
