using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GesBudgetaire.Models.Repository.GesBudgetaire
{
    public interface IDepenseRepository
    {
        IEnumerable<Depense> ListDepenses { get; }
        Depense Add(Depense depense);
    }
}
