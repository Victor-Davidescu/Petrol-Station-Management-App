//Transaction class
using System;
using System.IO;

namespace MyAssignment
{
    class Transaction
    {
        public string vehicleType;
        public float numberOfLitres;
        public int pumpNumber;

        public Transaction(string vt, float l, int pn)
        {
            vehicleType = vt;
            numberOfLitres = l;
            pumpNumber = pn;

            WriteTransaction();
        }

        //Storing all transactions on the text file "transactions.txt" in the program's current directory

        private void WriteTransaction() {
            try
            {
                // https://stackoverflow.com/questions/18813475/c-sharp-saving-a-txt-file-to-the-project-root | 2018
                // https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/file-system/how-to-write-to-a-text-file | 2018

                StreamWriter sw = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + @"\transactions.txt", true);

                string text = "Vehicle type:" + vehicleType + " | Number of litres:" + numberOfLitres + " | Pump number:" + (pumpNumber+1);

                sw.WriteLine(text);
                sw.Close();

            }
            catch (Exception e)
            {
                //Ouput an error if the file cannot be created or accessed.
                Console.WriteLine(e.ToString());
            }
        }
    }
}