using BusinessDomain;
using Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using DataAccess;

namespace BusinessLogic
{
    public class ResortManager : IResort
    {
        public List<ResortModel> LoadResort()
        {
            var result = new List<ResortModel>();
            try
            {
                using (var dbContext = new ResortDbContext())
                {
                    var resortList = dbContext.Resort.ToList();
                    if (resortList.Count() > 0)
                    {
                        foreach (var item in resortList)
                        {
                            var _resort = new ResortModel
                            {
                                Id = item.Id,
                                Name = item.ResortName,
                                Address = item.ResortAddress,
                                Price = (int)item.Price,
                                Rating = (int)item.Rating,
                                Image = item.ResortImage
                            };
                            result.Add(_resort);
                        }
                    }
                }
            }
            catch(Exception ex)
            {

            }
            return result;
        }
    }
}
