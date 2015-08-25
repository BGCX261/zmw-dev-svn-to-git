using System.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Objects;
using System.Reflection;
using zmw.dev.Dao.Holders;
using zmw.dev.utils;

namespace zmw.dev.Dao.Context
{
    public class ObjectContext : DatabaseEntities
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
                    if (pInfo.Name.Equals("InsertDate") || pInfo.Name.Equals("UpdateDate") || pInfo.Name.Equals("AccessDate") || pInfo.Name.Equals("RegistDate") || pInfo.Name.Equals("RegisterDateTime"))
                    {
                        pInfo.SetValue(entry.Entity, CurrentInfoHolder.GetBoundDateTime(), null);
                    }
                    else if (pInfo.Name.Equals("InsertUser") || pInfo.Name.Equals("UpdateUser") || pInfo.Name.Equals("RegisterSystem"))
                    {
                        pInfo.SetValue(entry.Entity, CurrentInfoHolder.GetBoundUser(), null);
                    }
                    else if (pInfo.Name.Equals("VersionNo") || pInfo.Name.Equals("Version"))
                    {
                        pInfo.SetValue(entry.Entity, 1, null);
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
                if (pInfo.Name.Equals("UpdateDate") || pInfo.Name.Equals("UpdateDateTime") || pInfo.Name.Equals("AccessDate"))
                {
                    pInfo.SetValue(currentEntity, CurrentInfoHolder.GetBoundDateTime(), null);
                }
                else if (pInfo.Name.Equals("UpdateUser") || pInfo.Name.Equals("UpdateSystem"))
                {
                    pInfo.SetValue(currentEntity, CurrentInfoHolder.GetBoundUser(), null);
                }
                else if (pInfo.Name.Equals("VersionNo") || pInfo.Name.Equals("Version"))
                {
                    var versionNo = currentEntity.GetPropertyValue(pInfo.Name);
                    if (versionNo == null)
                    {
                        pInfo.SetValue(currentEntity, 1, null);
                    }
                    else if (versionNo is int)
                    {
                        pInfo.SetValue(currentEntity, Convert.ToInt32(versionNo) + 1, null);
                    }
                }
            }

            return base.ApplyCurrentValues<TEntity>(entitySetName, currentEntity);
        }
    }
}