using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessDomain
{
    public interface IResort
    {
        List<ResortModel> LoadResort();
    }
}
