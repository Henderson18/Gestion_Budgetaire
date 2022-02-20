using GesBudgetaire.Models.Repository.GesBudgetaire;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GesBudgetaire.Models.Implementations.GesBudgetaire
{
    public class RevenuRepository : IRevenuRepository
    {
        private gestionbudgetaireContext bd_gestionbudgetaireContext;

        public RevenuRepository(gestionbudgetaireContext context)
        {
            this.bd_gestionbudgetaireContext = context;
        }
        public IEnumerable<Revenu> ListRevenu => bd_gestionbudgetaireContext.Revenu
            .ToArray();

        public Revenu Add(Revenu revenu)
        {
            Revenu revenu1 = bd_gestionbudgetaireContext.Revenu.Add(revenu).Entity;
            bd_gestionbudgetaireContext.SaveChanges();
            return revenu1;
        }
    }
}
