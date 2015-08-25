using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Objects;
using System.Reflection;
using CommonUtils.Extensions;
using Mobile.Dao.Holders;

namespace Mobile.Dao.Context
{
    public class DatabaseContext : DatabaseEntities
    {
        private readonly static IDictionary<Type, PropertyInfo[]> Dict = new Dictionary<Type, PropertyInfo[]>();

        public new int SaveChanges()
        {
            foreach (ObjectStateEntry entry in ObjectStateManager.GetObjectStateEntries(EntityState.Added))
            {
                Type targetType = entry.Entity.GetType();

                PropertyInfo[] pInfoList;

                if (Dict.ContainsKey(targetType))
                {
                    pInfoList = Dict[targetType];
                }
                else
                {
                    pInfoList = targetType.GetProperties(BindingFlags.Public | BindingFlags.Instance);
                }
                foreach (PropertyInfo pInfo in pInfoList)
                {
                    if (pInfo.Name.Equals("InsertTime") || pInfo.Name.Equals("UpdateTime") )
                    {
                        if (!CurrentInfoHolder.GetBoundDateTime().HasValue)
                        {
                            var now = DateTime.Now;
                            pInfo.SetValue(entry.Entity, now, null);
                        }
                        else
                        {
                            pInfo.SetValue(entry.Entity, CurrentInfoHolder.GetBoundDateTime(), null);
                        }

                    }
                }
            }

            foreach (ObjectStateEntry entry in ObjectStateManager.GetObjectStateEntries(EntityState.Modified))
            {
                Type targetType = entry.Entity.GetType();

                PropertyInfo[] pInfoList;

                if (Dict.ContainsKey(targetType))
                {
                    pInfoList = Dict[targetType];
                }
                else
                {
                    pInfoList = targetType.GetProperties(BindingFlags.Public | BindingFlags.Instance);
                }

                foreach (PropertyInfo pInfo in pInfoList)
                {
                    if (pInfo.Name.Equals("UpdateTime"))
                    {
                        if (!CurrentInfoHolder.GetBoundDateTime().HasValue)
                        {
                            var now = DateTime.Now;
                            pInfo.SetValue(entry.Entity, now, null);
                        }
                        else
                        {
                            pInfo.SetValue(entry.Entity, CurrentInfoHolder.GetBoundDateTime(), null);
                        }

                    }
                }
            }

            return base.SaveChanges();
        }

        public new TEntity ApplyCurrentValues<TEntity>(string entitySetName, TEntity currentEntity) where TEntity : class
        {
            Type targetType = currentEntity.GetType();

            PropertyInfo[] pInfoList;

            if (Dict.ContainsKey(targetType))
            {
                pInfoList = Dict[targetType];
            }
            else
            {
                pInfoList = targetType.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            }

            foreach (PropertyInfo pInfo in pInfoList)
            {
                if (pInfo.Name.Equals("UpdateTime") )
                {
                    if (!CurrentInfoHolder.GetBoundDateTime().HasValue)
                    {
                        var now = DateTime.Now;
                        pInfo.SetValue(currentEntity, now, null);
                    }
                    else
                    {
                        pInfo.SetValue(currentEntity, CurrentInfoHolder.GetBoundDateTime(), null);
                    }

                }
            }

            return base.ApplyCurrentValues(entitySetName, currentEntity);
        }
    }
}
