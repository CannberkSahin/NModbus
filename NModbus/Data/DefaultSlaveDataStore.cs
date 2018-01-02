using System;
using System.Collections.Generic;
using NModbus.Events;

namespace NModbus.Data
{
    internal class DefaultSlaveDataStore : ISlaveDataStore, ISlaveDataStoreWithEventDispatcher
    {
        private readonly IPointSource<ushort> _holdingRegisters = new DefaultPointSource<ushort>();
        private readonly IPointSource<ushort> _inputRegisters = new DefaultPointSource<ushort>();
        private readonly IPointSource<bool> _coilDiscretes = new DefaultPointSource<bool>();
        private readonly IPointSource<bool> _coilInputs = new DefaultPointSource<bool>();

        public IPointSource<ushort> HoldingRegisters => _holdingRegisters;

        public IPointSource<ushort> InputRegisters => _inputRegisters;

        public IPointSource<bool> CoilDiscretes => _coilDiscretes;

        public IPointSource<bool> CoilInputs => _coilInputs;

        public event EventHandler<BeforeReadHoldingInputRegistersEventArgs> BeforeReadHoldingInputRegisters;
        public event EventHandler<AfterWriteSingleCoilEventArgs> AfterWriteSingleCoil;
        public event EventHandler<AfterWriteMultipleCoilsEventArgs> AfterWriteMultipleCoils;

        public void DispatchBeforeReadHoldingInputRegisters(ushort start, ushort numberOfPoints)
        {
            var addressesRequested = new List<ushort>();
            for (var i = start; i <= start + numberOfPoints; i++)
            {
                addressesRequested.Add(i);
            }

            this.BeforeReadHoldingInputRegisters?.Invoke(this, new BeforeReadHoldingInputRegistersEventArgs(addressesRequested));
        }

        public void DispatchAfterWriteSingleCoil(ushort coilAddress, bool newCoilValue)
        {
            this.AfterWriteSingleCoil?.Invoke(this, new AfterWriteSingleCoilEventArgs(new KeyValuePair<ushort, bool>(coilAddress, newCoilValue)));
        }

        public void DispatchAfterWriteMultipleCoils(ushort startAddress, bool[] newCoilValues)
        {
            var coilsWritten = new Dictionary<ushort, bool>();

            var address = startAddress;
            foreach (var coilValue in newCoilValues)
            {
                coilsWritten.Add(address, coilValue);
                address++;
            }

            this.AfterWriteMultipleCoils?.Invoke(this, new AfterWriteMultipleCoilsEventArgs(coilsWritten));
        }
    }
}