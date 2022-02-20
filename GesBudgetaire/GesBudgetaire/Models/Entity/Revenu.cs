using System;
using System.Collections.Generic;

namespace GesBudgetaire.Models
{
    public partial class Revenu
    {
        public Revenu()
        {
            Depense = new HashSet<Depense>();
        }

        public int Idrevenu { get; set; }
        public int? Idutilisateur { get; set; }
        public int? Idcategorie { get; set; }
        public double? Montant { get; set; }
        public DateTime? Date { get; set; }

        public virtual CategorieOperation IdcategorieNavigation { get; set; }
        public virtual Utilisateur IdutilisateurNavigation { get; set; }
        public virtual ICollection<Depense> Depense { get; set; }
    }
}
