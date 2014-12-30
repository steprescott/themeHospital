﻿using System;
using System.Collections.Generic;
using System.Linq;
using TH.Domain.Other;

namespace TH.Interfaces
{
    public interface IBedBusinessLogic
    {
        bool CreateOrUpdateBed (Bed bed);
        bool AssignBedToWard(Bed bed, Ward ward);
    }
}
