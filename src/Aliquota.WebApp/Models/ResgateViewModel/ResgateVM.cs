using System;
using System.ComponentModel.DataAnnotations;

namespace Aliquota.WebApp.Models.ResgateViewModel
{
    public class ResgateVM
    {
        [Required(ErrorMessage ="O campo Id é obrigatório")]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "O campo Data do Resgate é obrigatório")]
        [Display(Name ="Data do Resgate")]
        [StringLength(10,MinimumLength =10,ErrorMessage ="A Data de Resgate precisa estar completa. ex: dia/mês/ano")]
        public string DataResgate { get; set; }
    }
}
