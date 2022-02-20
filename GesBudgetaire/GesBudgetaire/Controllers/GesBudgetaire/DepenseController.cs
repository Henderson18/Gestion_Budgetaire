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
    [Route("api/depense")]
    public class DepenseController : ControllerBase
    {
        private IDepenseRepository depenseRepository;

        public DepenseController(IDepenseRepository repository)
        {
            this.depenseRepository = repository;
        }

        [HttpGet]
        public IEnumerable<Depense> List() => depenseRepository.ListDepenses;

        [HttpPost]
        public Depense Add([FromBody] Depense depense)
        {
            Depense depense1 = null;

            depense1 = depenseRepository.Add(depense);

            if (depense1.Equals(null))
            {
                this.HttpContext.Response.StatusCode = 400;
                return (depense1);
            }
            this.HttpContext.Response.StatusCode = 201;
            return (depense1);
        }
    }
}
