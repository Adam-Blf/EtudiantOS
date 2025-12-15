using System;
using System.Collections.Generic;

namespace EtudiantOS.Models
{
    public class BudgetModel
    {
        public decimal Salaire { get; set; }
        public decimal Aides { get; set; }
        public decimal Loyer { get; set; }
        public decimal Transport { get; set; }
        public decimal Telephone { get; set; }
        public decimal AutresFixes { get; set; }
        
        // Calculated properties helper
        public decimal TotalEntrees => Salaire + Aides;
        public decimal TotalSorties => Loyer + Transport + Telephone + AutresFixes;
        public decimal ResteAVivre => TotalEntrees - TotalSorties;
    }
}
