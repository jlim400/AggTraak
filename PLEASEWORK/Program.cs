// See https://aka.ms/new-console-template for more information
//THIS WORKS 6:14pm 10/13


using com.caen.RFIDLibrary;
using System.IO.Ports;
using System.Reflection.PortableExecutable;
using System.Threading.Tasks;
//using MySql.Data.MySqlClient;

namespace AggTRAKcSHARP
{

    public class Program
    {

        static void Main(string[] args)
        {
            var mc = new Program();

            Console.WriteLine("Program START:");



            //Create reader called MyReader
            CAENRFIDReader MyReader = new CAENRFIDReader();



            //User enter name of serial port
            Console.Write("Enter serial port name: ");
            string serial = Console.ReadLine();




            //connect MyReader to the entered port
            MyReader.Connect(CAENRFIDPort.CAENRFID_RS232, serial);
            //Console.WriteLine(MyReader.GetSourceNames);
            CAENRFIDLogicalSource MySource = MyReader.GetSource("Source_0");

            CAENRFIDTag[] MyTags = MySource.InventoryTag();


            int h = 0;
            int delay = 500;

            //     MyReader.SetDateTime(date);

            Console.Write("Reading...");

            while (true)
            {

                if (MyTags == null)
                {
                    Console.Write(".");
                    Thread.Sleep(750);

                }

                if (MyTags != null)
                {
                    for (int i = 0; i < MyTags.Length; i++)
                    {

                        String s = BitConverter.ToString(MyTags[i].GetId());
                        Console.WriteLine("Tag EPC: "+s);
                        
                        Console.WriteLine("Tag Location: " + MyTags[i].GetReadPoint());
                        Console.WriteLine("");

                    }

                    Thread.Sleep(delay);

                }
                MyTags = MySource.InventoryTag();

            }
        }
    }
}

