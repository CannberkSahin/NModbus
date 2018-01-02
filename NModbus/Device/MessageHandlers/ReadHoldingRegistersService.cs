﻿using System.Collections.Generic;
using NModbus.Data;
using NModbus.Events;
using NModbus.Message;

namespace NModbus.Device.MessageHandlers
{
    internal class ReadHoldingRegistersService : ModbusFunctionServiceBase<ReadHoldingInputRegistersRequest>
    {
        public ReadHoldingRegistersService() 
            : base(ModbusFunctionCodes.ReadHoldingRegisters)
        {
        }

        public override int GetRtuRequestBytesToRead(byte[] frameStart)
        {
            return 1;
        }

        public override int GetRtuResponseBytesToRead(byte[] frameStart)
        {
            return frameStart[2] + 1;
        }

        protected override IModbusMessage Handle(ReadHoldingInputRegistersRequest request, ISlaveDataStore dataStore)
        {
            ((ISlaveDataStoreWithEventDispatcher)dataStore).DispatchBeforeReadHoldingInputRegisters(request.StartAddress, request.NumberOfPoints);
            ushort[] registers = dataStore.HoldingRegisters.ReadPoints(request.StartAddress, request.NumberOfPoints);

            RegisterCollection data = new RegisterCollection(registers);

            return new ReadHoldingInputRegistersResponse(request.FunctionCode, request.SlaveAddress, data);
        }
    }
}