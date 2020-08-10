namespace carglass.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Fornecedor")]
    public partial class Fornecedor
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Fornecedor()
        {
            Telefone_Fornecedor = new HashSet<Telefone_Fornecedor>();
        }
        
        [Display(Name = "Fornecedor")]
        [Key]
        public int ID_FORNECEDOR { get; set; }

        [Display(Name = "Empresa")]
        public int ID_EMPRESA { get; set; }

        [Required]
        [StringLength(30)]
        public string NOME { get; set; }

        [Required]
        [StringLength(14)]
        [Display(Name = "CPF/CNPJ")]
        public string CPFCNPJ { get; set; }

        [Display(Name = "Data Hora Cadastro")]
        public DateTime DHCADASTRO { get; set; }

        public virtual Empresa Empresa { get; set; }

        public virtual FornecedorPF FornecedorPF { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Telefone_Fornecedor> Telefone_Fornecedor { get; set; }

    }
}
