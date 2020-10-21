using blue_dragon.Models.V1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace blue_dragon.Validator.V1
{
    public class ActivityValidator : AbstractValidator<Activity>
    {
      
        public ActivityValidator()
        {
            RuleFor(m => m.DateTime).NotEmpty();
            RuleFor(m => m.Description).NotEmpty();
            RuleFor(m => m.Amount).NotEmpty();

            List<string> conditions = GetPossibleAccountStatus();
            RuleFor(x => x.Status)
               .Must(x => conditions.Contains(x))
               .WithMessage("Accepted Values: " + String.Join(",", conditions));
        }

        private List<String> GetPossibleAccountStatus()
        {
            return new List<string>() { "Pending", "Completed", "Cancelled" };
        }
    }
}
