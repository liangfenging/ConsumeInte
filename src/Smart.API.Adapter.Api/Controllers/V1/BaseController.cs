using Smart.API.Adapter.Biz;
using Smart.API.Adapter.Models;
using Smart.API.Adapter.Web.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Smart.API.Adapter.Api.Controllers.V1
{
    /// <summary>
    /// 基础信息，部门，人事资料
    /// </summary>
    public class BaseController : ApiControllerBase
    {
        [HttpPost, WriteLog, ActionName("deptopr")]
        public HttpResponseMessage deptopr(DepartmentModel requestdata)
        {
            APIResultBase apiresult = new APIResultBase();
            string message = "";
            int result = new ConsumeBaseBLL().DeptOpr(requestdata, out message);
            if (result != 0)
            {
                apiresult.code = "1";
                if (string.IsNullOrWhiteSpace(message))
                {
                    message = "组织结构同步操作失败";
                }
                apiresult.msg = message;
            }
            return Request.CreateResponse(apiresult);
        }

        [HttpPost, WriteLog, ActionName("personopr")]
        public HttpResponseMessage personopr(PersonModel requestdata)
        {
            APIResultBase apiresult = new APIResultBase();
            string message = "";
            int result = new ConsumeBaseBLL().PersonOpr(requestdata, out message);
            if (result != 0)
            {
                apiresult.code = "1";
                if (string.IsNullOrWhiteSpace(message))
                {
                    message = "人员信息同步操作失败";
                }
                apiresult.msg = message;
            }
            return Request.CreateResponse(apiresult);
        }


        [HttpPost, WriteLog, ActionName("cardopr")]
        public HttpResponseMessage cardopr(requestCardOpr requestdata)
        {
            APIResultBase apiresult = new APIResultBase();
            string message = "";
            int result = new ConsumeBaseBLL().CardOpr(requestdata, out message);
            if (result != 0)
            {
                apiresult.code = "1";
                if (string.IsNullOrWhiteSpace(message))
                {
                    message = "卡操作失败";
                }
                apiresult.msg = message;
            }
            return Request.CreateResponse(apiresult);
        }


        [HttpPost, WriteLog, ActionName("cardchargeopr")]
        public HttpResponseMessage cardchargeopr(requestCardCharge requestdata)
        {
            APIResultBase apiresult = new APIResultBase();
            string message = "";
            int result = new ConsumeBaseBLL().CardChargeOpr(requestdata, out message);
            if (result != 0)
            {
                apiresult.code = "1";
                if (string.IsNullOrWhiteSpace(message))
                {
                    message = "卡充值/退款操作失败";
                }
                apiresult.msg = message;
            }
            return Request.CreateResponse(apiresult);
        }


        [HttpPost, WriteLog, ActionName("consumerecords")]
        public HttpResponseMessage consumerecords(requestConsumeRecords requestData)
        {
            if (requestData.pageIndex <= 0)
            {
                requestData.pageIndex = 1;
            }
            if (requestData.pageSize <= 0)
            {
                requestData.pageSize = 10;
            }
            APIResultBase<responseConsumeRecords> apiresult = new APIResultBase<responseConsumeRecords>();
            string message = "";
            responseConsumeRecords records = new responseConsumeRecords();
            int result = new ConsumeBaseBLL().SearchConsumeRecords(requestData, ref records, out message);
            if (result != 0)
            {
                apiresult.code = "1";
                if (string.IsNullOrWhiteSpace(message))
                {
                    message = "查询消费记录失败";
                }
                apiresult.msg = message;
            }
            apiresult.data = records;
            return Request.CreateResponse(apiresult);
        }

        [HttpPost, WriteLog, ActionName("cardinfo")]
        public HttpResponseMessage cardinfo(requestCardInfo requestdata)
        {
            APIResultBase<CardModel> apiresult = new APIResultBase<CardModel>();
            string message = "";
            CardModel model = null;
            int result = new ConsumeBaseBLL().SearchCardInfo(requestdata, ref model, out message);
            if (result != 0)
            {
                apiresult.code = "1";
                if (string.IsNullOrWhiteSpace(message))
                {
                    message = "卡信息查询失败";
                }
                apiresult.msg = message;
            }
            apiresult.data = model;
            return Request.CreateResponse(apiresult);
        }

    }
}
