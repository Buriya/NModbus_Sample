using System.Net.Sockets;
using NModbus;

namespace ModbusTest2
{
    internal class ModbusClient
    {
        private const string PrimarySerialPortName = "COM1";

        private static async Task<int> Main(string[] args)
        {
            var cts = new CancellationTokenSource();

            Console.CancelKeyPress += (sender, eventArgs) => cts.Cancel();

            try
            {
                await Task.Run(() => { });

                // 使いたい関数のコメントアウトを消す
                ModbusTcpReadDiscreteInputs();
                //ModbusTcpReadCoils();
                //ModbusTcpReadInputRegisters();
                //ModbusTcpReadHoldingRegisters();

                //ModbusTcpWriteSingleCoil();
                //ModbusTcpWriteMultipleCoils();
                //ModbusTcpWriteSingleHoldingRegister();
                //ModbusTcpWriteMultipleHoldingRegisters();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.WriteLine("Press any key to continue");
            Console.ReadKey();

            return 0;
        }

        // ここからRead関数
        public static void ModbusTcpReadDiscreteInputs()
        {
            using (TcpClient client = new TcpClient("127.0.0.1", 502))
            {
                var factory = new ModbusFactory();
                IModbusMaster master = factory.CreateMaster(client);

                byte slaveAddress = 1;
                ushort startAddress = 0;
                ushort endAddress = 5;

                bool[] inputs = master.ReadInputs(slaveAddress, startAddress, endAddress);

                for (int i = 0; i < endAddress; i++)
                {
                    Console.WriteLine($"Input {(startAddress + i)}={(inputs[i] ? 1 : 0)}");
                }
            }
        }
        public static void ModbusTcpReadCoils()
        {
            using (TcpClient client = new TcpClient("127.0.0.1", 502))
            {
                var factory = new ModbusFactory();
                IModbusMaster master = factory.CreateMaster(client);

                byte slaveAddress = 1;
                ushort startAddress = 0;
                ushort endAddress = 5;

                bool[] inputs = master.ReadCoils(slaveAddress, startAddress, endAddress);

                for (int i = 0; i < endAddress; i++)
                {
                    Console.WriteLine($"Input {(startAddress + i)}={(inputs[i] ? 1 : 0)}");
                }
            }
        }
        public static void ModbusTcpReadInputRegisters()
        {
            using (TcpClient client = new TcpClient("127.0.0.1", 502))
            {
                var factory = new ModbusFactory();
                IModbusMaster master = factory.CreateMaster(client);

                byte slaveAddress = 1;
                ushort startAddress = 0;
                ushort endAddress = 5;

                ushort[] inputs = master.ReadInputRegisters(slaveAddress, startAddress, endAddress);

                for (int i = 0; i < endAddress; i++)
                {
                    Console.WriteLine($"Input {(startAddress + i)}={(inputs[i])}");
                }
            }
        }
        public static void ModbusTcpReadHoldingRegisters()
        {
            using (TcpClient client = new TcpClient("127.0.0.1", 502))
            {
                var factory = new ModbusFactory();
                IModbusMaster master = factory.CreateMaster(client);

                byte slaveAddress = 1;
                ushort startAddress = 0;
                ushort endAddress = 5;

                ushort[] inputs = master.ReadHoldingRegisters(slaveAddress, startAddress, endAddress);

                for (int i = 0; i < endAddress; i++)
                {
                    Console.WriteLine($"Input {(startAddress + i)}={(inputs[i])}");
                }
            }
        }

        // ここからWrite関数
        public static void ModbusTcpWriteSingleCoil()
        {
            using (TcpClient client = new TcpClient("127.0.0.1", 502))
            {
                var factory = new ModbusFactory();
                IModbusMaster master = factory.CreateMaster(client);

                byte slaveAddress = 1;
                ushort coilAddress = 0;
                bool value = true;

                master.WriteSingleCoil(slaveAddress, coilAddress, value);

            }
        }
        public static void ModbusTcpWriteMultipleCoils()
        {
            using (TcpClient client = new TcpClient("127.0.0.1", 502))
            {
                var factory = new ModbusFactory();
                IModbusMaster master = factory.CreateMaster(client);

                byte slaveAddress = 1;
                ushort startAddress = 0;
                bool[] value = { true, true, true, true, true };

                master.WriteMultipleCoils(slaveAddress, startAddress, value);
            }
        }
        public static void ModbusTcpWriteSingleHoldingRegister()
        {
            using (TcpClient client = new TcpClient("127.0.0.1", 502))
            {
                var factory = new ModbusFactory();
                IModbusMaster master = factory.CreateMaster(client);

                byte slaveAddress = 1;
                ushort startAddress = 0;
                ushort value = 1;

                master.WriteSingleRegister(slaveAddress, startAddress, value);
            }
        }
        public static void ModbusTcpWriteMultipleHoldingRegisters()
        {
            using (TcpClient client = new TcpClient("127.0.0.1", 502))
            {
                var factory = new ModbusFactory();
                IModbusMaster master = factory.CreateMaster(client);

                byte slaveAddress = 1;
                ushort startAddress = 0;
                ushort[] value = { 1, 2, 3, 44, 555 };

                master.WriteMultipleRegisters(slaveAddress, startAddress, value);
            }
        }
    }
}
