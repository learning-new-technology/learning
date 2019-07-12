using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessDomain
{
    public interface IResort
    {
        List<ResortModel> LoadResort();
        ResortModel ResortDetail(int Id);
        bool UpdateResort(ResortModel resort);
        bool RemoveResort(int Id);
    }
}
