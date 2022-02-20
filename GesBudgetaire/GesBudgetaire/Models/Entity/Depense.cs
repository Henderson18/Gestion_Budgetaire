using System;
using System.Collections.Generic;

namespace GesBudgetaire.Models
{
    public partial class Depense
    {
        public int Iddepense { get; set; }
        public int? Idutilisateur { get; set; }
        public int? Idrevenu { get; set; }
        public int? Idcategorie { get; set; }
        public double? Montant { get; set; }
        public DateTime? Date { get; set; }

        public virtual CategorieOperation IdcategorieNavigation { get; set; }
        public virtual Revenu IdrevenuNavigation { get; set; }
        public virtual Utilisateur IdutilisateurNavigation { get; set; }
    }
}
