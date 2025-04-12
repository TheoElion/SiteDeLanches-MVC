using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LanchesMac.Models;

[Table("Lanches")]
public class Lanche 
{
    [Key]
    public int LancheId { get; set; }

    [Required(ErrorMessage = "O nome do lanche deve ser informado.")]
    [Display(Name = "Nome do lanche")]
    [StringLength(80, MinimumLength= 10, ErrorMessage = "O {0} deve ter no mínimo {1} e no maximo {2} caracteres.")]
    public string Nome { get; set; }

    [Required(ErrorMessage = "A descrição do lanche deve ser informada.")]
    [Display(Name = "Descrição do lanche")]
    [StringLength(200, MinimumLength = 20, ErrorMessage = "O {0} deve ter no mínimo {1} e no maximo {2} caracteres.")]
    public string DescricaoCurta { get; set; }

    [Required(ErrorMessage = "A descrição detalhada do lanche deve ser informada.")]
    [Display(Name = "Descrição do lanche")]
    [StringLength(200, MinimumLength = 20, ErrorMessage = "O {0} deve ter no mínimo {1} e no maximo {2} caracteres.")]
    public string DescricaoDetalhada { get; set; }

    [Required(ErrorMessage = "O preço do lanche deve ser informado.")]
    [Display(Name = "Preço")]
    [Column(TypeName = "decimal(10,2)")]
    [Range(1,999.99, ErrorMessage = "O preço deve estar entre R$1,00 e R$999,99")]
    public decimal Preco { get; set; }

    [StringLength(200, ErrorMessage = "O {0} deve ter no máximo {1} caracteres.")]
    [Display(Name = "Caminho Imagem Normal")]
    public string ImagemUrl { get; set; }

    [StringLength(200, ErrorMessage = "O {0} deve ter no máximo {1} caracteres.")]
    [Display(Name = "Caminho Imagem Thumbnail")]
    public string ImagemThumbnailUrl { get; set; }

    [Display(Name = "Preferido?")]
    public bool IsLanchePreferido { get; set; }

    [Display(Name = "Estoque")]
    public bool EmEstoque { get; set; }


    public int CategoriaId { get; set; }
    public virtual Categoria Categoria { get; set; }
}
