using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NModbus.Events
{
    public class AfterWriteSingleCoilEventArgs : EventArgs
    {
        public KeyValuePair<ushort, bool> CoilValue { get; }

        public AfterWriteSingleCoilEventArgs(KeyValuePair<ushort, bool> coilValue)
        {
            this.CoilValue = coilValue;
        }
    }
}
