using blue_dragon.Dto.V1;
using blue_dragon.Validators.V1;
using FluentValidation;
using System;
using System.Collections.Generic;

namespace blue_dragon.Validator.V1
{
    public class PatchActivityStatusDtoValidor : AbstractValidator<PatchActivityStatusRequest>
    {

        public PatchActivityStatusDtoValidor()
        {

            List<string> conditions = ValidatorHelper.GetPossibleAccountStatus();
            RuleFor(x => x.Status)
               .Must(x => conditions.Contains(x))
               .WithMessage("Accepted Values: " + String.Join(",", conditions));
        }

    }
}
