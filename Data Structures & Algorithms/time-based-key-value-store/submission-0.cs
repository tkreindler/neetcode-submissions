public class TimeMap {

    // Dictionary does key -> list map
    // each list is sorted by timestamp
    private readonly Dictionary<string, List<(int timestamp, string value)>> dictionary = new ();

    public void Set(string key, string value, int timestamp)
    {
        ref var listRef = ref System.Runtime.InteropServices.CollectionsMarshal.GetValueRefOrAddDefault(this.dictionary, key, out bool exists);
        if (!exists)
        {
            listRef = new List<(int timestamp, string value)>();
        }

        // adding to the end is auto-sorted as adds are in strictly increasing order by timestamp
        listRef.Add((timestamp, value));
    }
    
    public string Get(string key, int timestamp)
    {
        if (!this.dictionary.TryGetValue(key, out List<(int timestamp, string value)> list))
        {
            return string.Empty;
        }

        // binary search by timestamp within the list
        int low = 0;
        int high = list.Count;

        // default to string.Empty (for when there are no acceptable results)
        string bestResult = string.Empty;

        while (high > low)
        {
            int mid = (high + low) / 2;
            int foundTimestamp = list[mid].timestamp;

            if (timestamp >= foundTimestamp)
            {
                // this value would we acceptable (newer)
                bestResult = list[mid].value;

                low = mid + 1;
            }
            else
            {
                high = mid;
            }
        }

        return bestResult;
    }
}
