using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DeveloperSample.Syncing
{
    public class SyncDebug
    {
        public async Task<List<string>> InitializeListAsync(IEnumerable<string> items)
        {
            var innerLstC = new ConcurrentBag<string>();
            var lstTasks = items.Select(async i =>
            {
                var item = await Task.Run(() => i).ConfigureAwait(false);
                innerLstC.Add(item);
            });
            await Task.WhenAll(lstTasks);
            return innerLstC.ToList();
        }

        public Dictionary<int, string> InitializeDictionary(Func<int, string> getItem)
        {
            var lstrange = Enumerable.Range(0, 100).ToList();
            var itemsLookup = new ConcurrentDictionary<int, string>();
            int tCount = 3;
            var lstpartictions = Partitioner.Create(0, lstrange.Count, lstrange.Count / tCount + 1);
            var lstThreads = lstpartictions.GetPartitions(tCount)
                .Select(pt =>
                    new Thread(() =>
                    {
                        try
                        {
                            while (pt.MoveNext())
                            {
                                for (long i = pt.Current.Item1; i < pt.Current.Item2; i++)
                                {
                                    int item = lstrange[(int)i];
                                    itemsLookup.GetOrAdd(item, getItem);
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error Occured {ex.Message}");
                        }
                        
                    })
                ).ToList();

            lstThreads.ForEach(t => t.Start());
            lstThreads.ForEach(t => t.Join());

            return itemsLookup.ToDictionary(kv => kv.Key, kv => kv.Value);
        }
    }
}