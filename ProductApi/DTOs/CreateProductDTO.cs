using System.ComponentModel.DataAnnotations;

namespace ProductApi.DTOs;

public class CreateProductDTO
{
    [Required(ErrorMessage = "O nome é obrigatório.")]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "O nome deve ter entre 3 e 100 caracteres.")]
    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessage = "O preço é obrigatório.")]
    [Range(0.01, 1000000, ErrorMessage = "O preço deve ser maior que zero.")]
    public decimal Price { get; set; }

    [Required(ErrorMessage = "A categoria é obrigatória.")]
    [StringLength(50, MinimumLength = 3, ErrorMessage = "A categoria deve ter entre 3 e 50 caracteres.")]
    public string Category { get; set; } = string.Empty;
}
