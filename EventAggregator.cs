using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppPetT
{
    public class DataTransferEventArgs : EventArgs
    {
        public IEnumerable<object> Data { get; }

        public DataTransferEventArgs(IEnumerable<object> data)
        {
            Data = data;
        }
    }
    public static class EventAggregator
    {
        public static event EventHandler<DataTransferEventArgs> DataTransferred;

        public static void RaiseDataTransferred(IEnumerable<object> data)
        {
            DataTransferred?.Invoke(null, new DataTransferEventArgs(data));
        }
    }
}
