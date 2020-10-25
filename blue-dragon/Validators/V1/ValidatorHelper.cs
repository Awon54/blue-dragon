using System;
using System.Collections.Generic;

namespace blue_dragon.Validators.V1
{
    public class ValidatorHelper
    {

        public static List<String> GetPossibleAccountStatus()
        {
            return new List<string>() { "Pending", "Completed", "Cancelled" };
        }

    }
}
