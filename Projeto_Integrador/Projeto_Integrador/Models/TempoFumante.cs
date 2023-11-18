using System.ComponentModel.DataAnnotations;

namespace Projeto_Integrador.Models
{
    public enum TempoFumante
    {
        [Display(Name = "Mais de um ano")]
        MenosDeUmAno,
        [Display(Name = "De um a cinco anos")]
        DeUmACincoAnos,
        [Display(Name = "De cinco a dez anos")]
        DeCincoADezAnos,
        [Display(Name = "Mais de dez anos")]
        MaisDeDezAnos
    }
}
