using GesBudgetaire.Models.Repository.GesBudgetaire;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GesBudgetaire.Models.Implementations.GesBudgetaire
{
    public class UtilisateurRepository : IUtilisateurRepository
    {
        private gestionbudgetaireContext bd_gestionbudgetaireContext;

        public UtilisateurRepository(gestionbudgetaireContext context)
        {
            this.bd_gestionbudgetaireContext = context;
        }

        public Utilisateur this[int idlocataire] => bd_gestionbudgetaireContext.Utilisateur
            .First(n => n.Idutilisateur == idlocataire);
        public IEnumerable<Utilisateur> ListUtilisateur => bd_gestionbudgetaireContext.Utilisateur
            .ToArray();
        public Utilisateur Add(Utilisateur utilisateur)
        {
            Utilisateur user = bd_gestionbudgetaireContext.Utilisateur.Add(utilisateur).Entity;
            bd_gestionbudgetaireContext.SaveChanges();
            return user;
        }

        public void Delete(int idutilisateur)
        {
            bd_gestionbudgetaireContext.Utilisateur.Remove(this[idutilisateur]);
            bd_gestionbudgetaireContext.SaveChanges();
        }

        public Utilisateur UpdateAsync(Utilisateur utilisateur)
        {
            Utilisateur user = bd_gestionbudgetaireContext.Utilisateur.Update(utilisateur).Entity;
            bd_gestionbudgetaireContext.SaveChanges();
            return user;
        }

        public bool UtilisateurExists(int id)
        {
            return bd_gestionbudgetaireContext.Utilisateur.Any(e => e.Idutilisateur == id);
        }

    }
}
