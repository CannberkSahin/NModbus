using System;
using System.Collections.Generic;
using NModbus.Data;
using NModbus.Events;

namespace NModbus
{
    /// <summary>
    /// Object simulation of a device memory map.
    /// </summary>
    public interface ISlaveDataStoreWithEventDispatcher: ISlaveDataStore
    {
        void DispatchBeforeReadHoldingInputRegisters(ushort start, ushort numberOfPoints);
        void DispatchAfterWriteSingleCoil(ushort coilAddress, bool newCoilValue);
        void DispatchAfterWriteMultipleCoils(ushort startAddress, bool[] newCoilValues);
    }
}