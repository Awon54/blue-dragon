﻿using blue_dragon.Dto.V1;
using blue_dragon.Models.V1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace blue_dragon.Service.V1
{
    interface IActivity
    {
        public Activity GetActivity(PatchActivityStatusDto patchActivityStatusDto);
    }
}
