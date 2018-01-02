using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NModbus.Events
{
    public class AfterWriteMultipleCoilsEventArgs : EventArgs
    {
        public Dictionary<ushort, bool> CoilValues { get; }

        public AfterWriteMultipleCoilsEventArgs(Dictionary<ushort, bool> coilValues)
        {
            this.CoilValues = coilValues;
        }
    }
}
