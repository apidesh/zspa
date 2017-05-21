using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ZSPA.ClientModels;
using ZSPA.Db;
using ZSPA.Db.Models;

namespace ZSPA.Controllers
{
    [Route("api/[controller]")]
    public class EnterpriseController : Controller
    {
        private readonly IRepository<Enterprise, Guid> repository;

        public EnterpriseController(ZSPADbContext context)
        {
            repository = new Repository<Enterprise, Guid>(context);
        }

        [HttpGet("[action]")]
        public List<Enterprise> EnterpriseList()
        {
            return repository.GetAll().ToList();
        }

        [HttpGet("[action]")]
        public List<Enterprise> Search(string id, string name)
        {
            return repository.FindAll(item => string.Equals(item.EnterpriseID, id, StringComparison.Ordinal) || string.Equals(item.EnterpriseName, name, StringComparison.Ordinal)).ToList();
        }

        [HttpPost("[action]")]
        public JsonResult Entry([FromBody]EnterpriseEntry model)
        {
            try
            {
                if (model == null)
                    throw new ArgumentNullException("model");

                repository.Add(new Enterprise
                {
                    ID = Guid.NewGuid(),
                    EnterpriseID = model.Id,
                    EnterpriseName = model.Name,
                    IsActive = true,
                    CreateBy = "System",
                    CreateDate = DateTime.Now,
                    ModifyBy = "System",
                    ModifyDate = DateTime.Now
                });
                repository.SaveChanges();

                return new JsonResult("{status:0, message:success}");
            }
            catch (Exception e)
            {
                return new JsonResult("{status:0, message:" + e.Message + "}");
            }
        }
    }
}