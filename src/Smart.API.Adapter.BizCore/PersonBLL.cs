using Smart.API.Adapter.DataAccess.Core;
using Smart.API.Adapter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart.API.Adapter.BizCore
{
    public class PersonBLL
    {
        public PersonModel GetPersonByPersonId(string personId)
        {
            return PersonDAL.ProxyInstance.GetPersonByPersonId(personId);
        }

        public void Insert(PersonModel model)
        {
            model.CreateTime = DateTime.Now;
            model.ModifyTime = DateTime.Now;
            PersonDAL.ProxyInstance.Insert<PersonModel>(model);
        }

        public bool Update(PersonModel model)
        {
            model.ModifyTime = DateTime.Now;
            return PersonDAL.ProxyInstance.Update<PersonModel>(model, model.ID.ToString());
        }

        public bool Delete(PersonModel model)
        {
            model.ModifyTime = DateTime.Now;
            model.Status = 1;
            return PersonDAL.ProxyInstance.Update<PersonModel>(model, model.ID.ToString());
        }
    }
}
