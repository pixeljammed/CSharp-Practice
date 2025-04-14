using System;
using System.IO;

namespace MenuStruct
{
    struct MenuItem
    {
        public string itemName;
        public double price;
    }

    class Program
    {
        static void Main(string[] args)
        {
            MenuItem Item1 = new MenuItem();

            Item1.itemName = "Veg Lasagne";
            Item1.price = 9.99;

            WriteBinaryFile(Item1);
            MenuItem ItemFromBinary = ReadBinaryFile();

            Console.WriteLine(ItemFromBinary.itemName);
            Console.WriteLine(ItemFromBinary.price);
        }

        static void WriteBinaryFile(MenuItem Item)
        {   
            // Stored in the bin/Debug folder by default
            string filename = "Menu Item Binary File.bin";

            // Declare and initialise a BinaryWriter in Create mode
            using (BinaryWriter writer = new BinaryWriter(File.Open(filename, FileMode.Create)))
            {
                // Write each value of the Item object to the binary file
                writer.Write(Item.itemName);
                writer.Write(Item.price);
            }
        }

        static MenuItem ReadBinaryFile()
        {
            // Stored in the bin/Debug folder by default
            string filename = "Menu Item Binary File.bin";

            // Declare and initialise a BinaryReader in Open mode
            using (BinaryReader reader = new BinaryReader(File.Open(filename, FileMode.Open)))
            {
                // Declare an Item object of type MenuItem
                MenuItem Item = new MenuItem();

                // Read each value of the Item object from the binary file
                Item.itemName = reader.ReadString();
                Item.price = reader.ReadDouble();

                // Return the Item object
                return Item;
            }
        }

    }
}
