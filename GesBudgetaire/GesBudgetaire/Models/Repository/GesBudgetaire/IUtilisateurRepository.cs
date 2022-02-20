using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GesBudgetaire.Models.Repository.GesBudgetaire
{
    public interface IUtilisateurRepository
    {
        IEnumerable<Utilisateur> ListUtilisateur { get; }

        Utilisateur Add(Utilisateur utilisateur);

        Utilisateur UpdateAsync(Utilisateur utilisateur);

        Utilisateur this[int idutilisateur] { get; }
        void Delete(int idutilisateur);

        bool UtilisateurExists(int id);

        Utilisateur findByEmail(string email);
    }
}
