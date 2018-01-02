using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NModbus.Events
{
    public class BeforeReadHoldingInputRegistersEventArgs: EventArgs
    {
        public List<ushort> AddressesRequested { get; }

        public BeforeReadHoldingInputRegistersEventArgs(List<ushort> addressesRequested)
        {
            this.AddressesRequested = addressesRequested;
        }
    }
}
