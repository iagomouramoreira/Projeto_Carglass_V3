namespace carglass.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Telefone_Fornecedor
    {
        [Key]
        public int ID_TELEFONE { get; set; }

        public int ID_FORNECEDOR { get; set; }

        [Required]
        [StringLength(2)]
        public string DDD { get; set; }

        [Required]
        [StringLength(9)]
        public string TELEFONE { get; set; }

        public virtual Fornecedor Fornecedor { get; set; }
    }
}
