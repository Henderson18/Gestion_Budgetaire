using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GesBudgetaire.Models.Repository.GesBudgetaire
{
    public interface IRevenuRepository
    {
        IEnumerable<Revenu> ListRevenu { get; }
        Revenu Add(Revenu revenu);
    }
}
