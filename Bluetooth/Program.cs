using System;
using System.IO.Ports;
using System.Text;

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            string portName = "COM4"; 
            int baudRate = 9600; 

            SerialPort serialPort = new SerialPort(portName, baudRate);
            serialPort.Open();

            Console.WriteLine("Bluetooth communication started...");

            while (true)
            {
                if (serialPort.IsOpen && serialPort.BytesToRead > 0)
                {
                    string receivedData = serialPort.ReadLine();
                    Console.WriteLine($"Received data from Bluetooth: {receivedData}");
                }

                Console.Write("Enter data to send: ");
                string dataToSend = Console.ReadLine();

                if (!string.IsNullOrEmpty(dataToSend))
                {
                    serialPort.WriteLine(dataToSend);
                    Console.WriteLine($"Sent data to Bluetooth: {dataToSend}");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
        Console.ReadLine();
    }
}