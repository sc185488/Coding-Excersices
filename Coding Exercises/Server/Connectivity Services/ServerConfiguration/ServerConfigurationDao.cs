using Common.Logging;
using NHibernate;
using NHibernate.Criterion;
using Retalix.Jumbo.Model.ServerConfiguration;
using Retalix.Jumbo.ModuleInstaller.Model.RegistrationAttributes;
using Retalix.StoreServices.Model.Infrastructure.DataAccess;
using Retalix.StoreServices.Model.Infrastructure.DataMovement;
using System;
using System.Collections.Generic;
using System.Runtime.Caching;
using Retalix.StoreServices.Infrastructure.Cache;
using Retalix.Jumbo.Common.Utils;
using System.Linq;
using Retalix.StoreServices.Model.Infrastructure.DataMovement.DeleteAllProviders;
using NHibernate.Linq;

namespace Retalix.Jumbo.ConnectivityServices.ServerConfiguration
{
    [RegisterAddition]
    public class ServerConfigurationDao : IServerConfigurationDao
    {
        protected static readonly ILog Log = LogManager.GetCurrentClassLogger();
        private const string ServerConfigurationKey = "ServerConfiguration";

        private readonly ISessionProvider _sessionProvider;

        public ServerConfigurationDao(ISessionProvider sessionProvider)
        {
            _sessionProvider = sessionProvider;
        }

        private ISession Session
        {
            get { return _sessionProvider.GetDefaultSession<ISession>(); }
        }


        public void SaveOrUpdate(IServerConfiguration serverConfiguration)
        {
            Session.SaveOrUpdate(serverConfiguration);
            CleanCache();
        }

        public List<IServerConfiguration> GetAllBusinessServiceForAllBusinessUnitId(ServerConfigurationCriteria searchingCriteria)
        {
            if (searchingCriteria == null)
                return new List<IServerConfiguration>();



            return Session.Query<IServerConfiguration>().AsQueryable().ToList();
        }

        public void Delete(IServerConfiguration serverConfiguration)
        {
            CleanCache();
            var configuration = GetByCriteria(new ServerConfigurationCriteria
            {
                ServerConfigurationId = serverConfiguration.ServerConfigurationId ,
                ServerConfigurationName = serverConfiguration.ServerConfigurationName ,
                EntityParameter = serverConfiguration.EntityParameter ,
                EntityType = serverConfiguration.EntityType ,
                Value = serverConfiguration.Value
            });
            using(ITransaction transaction = Session.BeginTransaction())
            {
                if (configuration != null)
                {
                    foreach (var item in configuration)
                    {
                        Session.Delete(item);
                        transaction.Commit();
                    }
                }
            }
        }

        public IEnumerable<IServerConfiguration> GetByCriteria(ServerConfigurationCriteria searchingCriteria)
        {
            if (searchingCriteria == null)
                return new IServerConfiguration[] { };

            var ServerConfigurationId = searchingCriteria.ServerConfigurationId;
            var ServerConfigurationName = searchingCriteria.ServerConfigurationName;
            var EntityParameter = searchingCriteria.EntityParameter;
            var EntityType = searchingCriteria.EntityType;
            var Value = searchingCriteria.Value;

            string cacheKey = string.Format("{0}|{1}|{2}|{3}|{4}", ServerConfigurationKey, (ServerConfigurationName ?? ""), (ServerConfigurationId ?? ""), (EntityParameter ?? ""), (EntityType ?? ""), (Value ?? ""));
            return CacheProvider.GetCache().AddOrGetNullable(cacheKey, () => GetByCriteria(ServerConfigurationName, ServerConfigurationId, EntityParameter, EntityType , Value), new CacheItemPolicy());
        }

        private IEnumerable<IServerConfiguration> GetByCriteria(string ServerConfigurationName , string ServerConfigurationId , string EntityParameter , string EntityType , string Value)
        {
            var criteria = Session.CreateCriteria<IServerConfiguration>();

            if (!string.IsNullOrEmpty(ServerConfigurationId))
                criteria.Add(Restrictions.Eq("ServerConfigurationId", ServerConfigurationId));

            if (!string.IsNullOrEmpty(ServerConfigurationId))
                criteria.Add(Restrictions.Eq("ServerConfigurationName", ServerConfigurationName));

            if (!string.IsNullOrEmpty(ServerConfigurationId))
                criteria.Add(Restrictions.Eq("EntityParameter", EntityParameter));

            if (!string.IsNullOrEmpty(ServerConfigurationId))
                criteria.Add(Restrictions.Eq("EntityType", EntityType));

            if (!string.IsNullOrEmpty(ServerConfigurationId))
                criteria.Add(Restrictions.Eq("Value", Value));

            return criteria.List<IServerConfiguration>();
        }

        public void Add(IEnumerable<IMovable> movables)
        {
            Log.Info(message => message("TestTouchPointConfigurationDao.Add enter"));
            try
            {
                foreach (var movable in movables.OfType<IServerConfiguration>())
                {
                    SaveOrUpdate(movable);
                }
                CleanCache();
            }
            catch (Exception e)
            {
                Log.Error("ServerConfigurationDao:Add ", e);
                throw;
            }
        }

        public void Delete(IEnumerable<IMovable> movables)
        {
            Log.Info(message => message("ServerConfigurationDao.Delete enter"));
            try
            {
                foreach (var movable in movables.OfType<IServerConfiguration>())
                {
                    Delete(movable);
                }
                CleanCache();
            }
            catch (Exception e)
            {
                Log.Error("ServerConfigurationDao:Delete ", e);
                throw;
            }

        }

        public void DeleteAll(ITruncateHelperDao truncateHelperDao)
        {
            Log.Info(message => message("ServerConfigurationDao.DeleteAll enter"));

            try
            {
                truncateHelperDao.TruncateTable("ServerConfiguration");
                CleanCache();
            }
            catch (Exception e)
            {
                Log.Error("ServerConfigurationDao:DeleteAll ", e);
                throw;
            }
        }

        public IList<string> GetTableNamesInDependencyOrder()
        {
            return new List<string>
                    {
                        "ServerConfiguration",
                    };
        }

        public IEnumerable<IMovable> GetAll(IMovable startingPosition)
        {
            Log.Info(message => message("ServerConfigurationDao.GetAll startingPosition enter"));
            var startingAccount = (IServerConfiguration)startingPosition;
            var accounts = GetAll().OfType<IServerConfiguration>().ToList();
            var filteredAccounts = new List<IServerConfiguration>();
            var foundStartingAccount = false;
            for (var i = 0; i < accounts.Count(); i++)
            {
                if (foundStartingAccount)
                {
                    filteredAccounts.Add(accounts[i]);
                }
                else if (accounts[i].ServerConfigurationId.Equals(startingAccount.ServerConfigurationId))
                {
                    foundStartingAccount = true;
                }
            }

            return filteredAccounts;
        }

        public IEnumerable<IMovable> GetAll()
        {
            Log.Info(message => message("ServerConfigurationDao.GetAll enter"));
            return Session.QueryOver<IServerConfiguration>().List();
        }

        public void Update(IEnumerable<IMovable> movables)
        {
            Log.Info(message => message("Entering PromotionalPriceDao: Executing SaveOrUpdateWithPriceStatusCalculation"));
            try
            {
                foreach (var movable in movables.OfType<IServerConfiguration>())
                {
                    SaveOrUpdate(movable);
                }
                CleanCache();
            }
            catch (Exception e)
            {
                Log.Error("ServerConfigurationDao:Update ", e);
                throw;
            }
        }

        private static void CleanCache()
        {
            CacheProvider.GetCache().CleanCache(ServerConfigurationKey);
        }

    }
}
