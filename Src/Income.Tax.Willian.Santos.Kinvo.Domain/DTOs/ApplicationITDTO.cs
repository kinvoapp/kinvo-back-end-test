using Income.Tax.Willian.Santos.Kinvo.Shared.Entities;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Income.Tax.Willian.Santos.Kinvo.Domain.DTOs
{

    public class ApplicationITDTO: Entity
    {

        public ApplicationITDTO(float value, DateTime contributionTime, DateTime dateRetreat, float? valueRetreat)
        {
            Value = value;
            ContributionTime = contributionTime;
            DateRetreat = dateRetreat;
            ValueRetreat = valueRetreat;
        }

        [Required]
        [Range(1, 999999)]
        [Column(TypeName = "float")]
        [Display(Name = "Valor aplicado")]
        public float Value { get; set; }

        [DataType(DataType.DateTime)]
        [Required]
        [Display(Name = "Data da aplicação")]
        public DateTime ContributionTime { get; set; }


        [DataType(DataType.DateTime)]
        [Required]
        [Display(Name = "Data de retirada")]
        public DateTime DateRetreat { get; set; }

        [Required]
        [Display(Name = "Valor de retirada")]
        public float? ValueRetreat { get; set; }

    }
}
