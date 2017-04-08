using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataStore.Interfaces.Events;
using DataStore.Interfaces.LowLevel;

namespace DataStore.Tests.TestHarness
{
    public interface ITestHarness
    {
        DataStore DataStore { get; }

        List<IDataStoreEvent> Events { get; }

        //add to the underlying db directly (i.e. not via datastore)
        Task AddToDatabase<T>(T aggregate) where T : IAggregate;

        //query the underlying db directly (i.e. not via datastore)
        Task<IEnumerable<T>> QueryDatabase<T>(Func<IQueryable<T>, IQueryable<T>> extendQueryable = null)
            where T : IHaveSchema, IHaveAUniqueId;
    }
}