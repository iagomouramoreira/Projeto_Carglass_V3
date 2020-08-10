namespace carglass.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FornecedorPF")]
    public partial class FornecedorPF
    {
        [Display(Name = "Fornecedor")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID_FORNECEDOR { get; set; }

        [Required]
        [StringLength(20)]
        public string RG { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Data Nascimento")]
        public DateTime DTNASCIMENTO { get; set; }

        public virtual Fornecedor Fornecedor { get; set; }
    }
}
