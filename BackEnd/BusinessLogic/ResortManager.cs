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

        public bool UpdateResort(ResortModel resort)
        {
            var result = false;
            using(var dbContext = new ResortDbContext())
            {
                using(var dbTran = dbContext.Database.BeginTransaction())
                {
                    try
                    {
                        var _resort = dbContext.Resort.FirstOrDefault(x => x.Id == resort.Id);
                        if (_resort != null)
                        {
                            _resort.ResortName = resort.Name;
                            _resort.ResortAddress = resort.Address;
                            _resort.Price = resort.Price;
                            _resort.Rating = resort.Rating;
                            dbContext.SaveChanges();
                            dbTran.Commit();
                        }
                        result = true;
                    }
                    catch(Exception ex)
                    {
                        dbTran.Rollback();
                    }
                }
            }
            return result;
        }

        public bool RemoveResort(int Id)
        {
            var result = false;
            using(var dbContext = new ResortDbContext())
            {
                using(var dbTran = dbContext.Database.BeginTransaction())
                {
                    try
                    {
                        var _resort = dbContext.Resort.FirstOrDefault(x => x.Id == Id);
                        if (_resort != null)
                        {
                            dbContext.Remove(_resort);
                            dbContext.SaveChanges();
                            dbTran.Commit();
                            result = true;
                        }
                    }
                    catch(Exception ex)
                    {
                        dbTran.Rollback();
                    }
                }
            }
            return result;
        }

        public ResortModel ResortDetail(int Id)
        {
            var resort = new ResortModel();
            try
            {
                using(var dbContext = new ResortDbContext())
                {
                    var _resort = dbContext.Resort.FirstOrDefault(x => x.Id == Id);
                    if (_resort != null)
                    {
                        resort.Id = _resort.Id;
                        resort.Name = _resort.ResortName;
                        resort.Address = _resort.ResortAddress;
                        resort.Price = (int)_resort.Price;
                        resort.Rating = (int)_resort.Rating;
                        resort.Image = _resort.ResortImage;
                    }
                }
            }
            catch(Exception ex)
            {

            }
            return resort;
        }
    }
}
