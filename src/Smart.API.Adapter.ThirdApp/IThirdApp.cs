using Smart.API.Adapter.Models;
using System.Collections.Generic;

namespace Smart.API.Adapter.ThirdApp
{
    public interface IThirdApp
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="requestData"></param>
        /// <param name="OprType">1：新增 2：更新 3：删除</param>
        /// <param name="message"></param>
        /// <returns></returns>
        int DeptOpr(DepartmentModel requestData, int OprType, string thirdParentId, out string message);

        int PersonOpr(PersonModel requestData, DepartmentModel dept, int OprType, out string message);

        int CardOpr(CardModel requestData, PersonModel person, DepartmentModel dept, int OprType, out string message);

        int CardChargeOpr(CardChargeModel requestData, int OprType, out string message);
    }
}
