using Flunt.Notifications;
using Flunt.Validations;
using Income.Tax.Willian.Santos.Kinvo.Shared.Commands.Interfaces;
using System;

namespace Income.Tax.Willian.Santos.Kinvo.Domain.Command.Input
{
    public class ApplicationITCommand: Notifiable, ICommand
    {
        public ApplicationITCommand(float value, DateTime contributionTime)
        {
            Value = value;
            ContributionTime = contributionTime;
        }

        public float Value { get; set; }

        public DateTime ContributionTime { get; set; }

        public void Validate()
        {
            AddNotifications(new Contract().Requires().IsNotNull(Value, "Valor", "Preencha algum valor!")
                                                      .IsGreaterThan(Value, 0.0F,"Valor aplicado", "O valor deve ser maior que zero(0)!")
                                                      .IsLowerThan(ContributionTime, DateTime.Now,"Data de contribuição","Data de contribução precisa ser menor que a data atual!"));


        }
    }
}
