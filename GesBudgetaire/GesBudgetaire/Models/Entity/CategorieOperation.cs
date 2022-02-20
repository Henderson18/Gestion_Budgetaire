using System;
using System.Collections.Generic;

namespace GesBudgetaire.Models
{
    public partial class CategorieOperation
    {
        public CategorieOperation()
        {
            Depense = new HashSet<Depense>();
            Revenu = new HashSet<Revenu>();
        }

        public int Idcategorie { get; set; }
        public string Libelle { get; set; }

        public virtual ICollection<Depense> Depense { get; set; }
        public virtual ICollection<Revenu> Revenu { get; set; }
    }
}
