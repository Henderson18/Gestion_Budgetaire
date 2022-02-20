using GesBudgetaire.Models.Repository.GesBudgetaire;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GesBudgetaire.Models.Implementations.GesBudgetaire
{
    public class DepenseRepository : IDepenseRepository
    {

        private gestionbudgetaireContext bd_gestionbudgetaireContext;

        public DepenseRepository(gestionbudgetaireContext context)
        {
            this.bd_gestionbudgetaireContext = context;
        }
        public IEnumerable<Depense> ListDepenses => bd_gestionbudgetaireContext.Depense
            .ToArray();

        public Depense Add(Depense depense)
        {
            Depense depense1 = bd_gestionbudgetaireContext.Depense.Add(depense).Entity;
            bd_gestionbudgetaireContext.SaveChanges();
            return depense1;
        }
    }
}
