using DVLD.Application.Abstractions.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.Application.Tests.GetTestRoadmap
{
    public sealed record GetTestRoadmapQuery(int LocalApplicationId) : IQuery<TestRoadmapResponse>
    {

    }
    
}
