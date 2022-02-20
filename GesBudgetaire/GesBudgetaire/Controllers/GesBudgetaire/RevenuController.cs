using GesBudgetaire.Models;
using GesBudgetaire.Models.Repository.GesBudgetaire;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GesBudgetaire.Controllers.GesBudgetaire
{
    [Route("api/revenu")]
    public class RevenuController : ControllerBase
    {

        private IRevenuRepository revenuRepository;

        public RevenuController(IRevenuRepository repository)
        {
            this.revenuRepository = repository;
        }

        [HttpGet]
        public IEnumerable<Revenu> List() => revenuRepository.ListRevenu;

        [HttpPost]
        public Revenu Add([FromBody] Revenu revenu)
        {
            Revenu revenu1 = null;

            revenu1 = revenuRepository.Add(revenu);

            if (revenu1.Equals(null))
            {
                this.HttpContext.Response.StatusCode = 400;
                return (revenu1);
            }
            this.HttpContext.Response.StatusCode = 201;
            return (revenu1);
        }

    }
}
