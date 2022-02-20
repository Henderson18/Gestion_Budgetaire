using System;
using System.Collections.Generic;

namespace GesBudgetaire.table
{
    public partial class Utilisateur
    {
        public Utilisateur()
        {
            Depense = new HashSet<Depense>();
            Revenu = new HashSet<Revenu>();
        }

        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public string Statut { get; set; }
        public int Idutilisateur { get; set; }

        public virtual ICollection<Depense> Depense { get; set; }
        public virtual ICollection<Revenu> Revenu { get; set; }
    }
}
