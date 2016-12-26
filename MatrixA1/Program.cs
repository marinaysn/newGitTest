using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace MatrixA1
{
    class Program
    {
        static void Main(string[] args)
        {
            char yesToContinue = 'y';

            //Application rolls over until user decides to leave the program
            while (yesToContinue == 'y')
            {
                RunMatrix rm = new RunMatrix();
                rm.MatrixList = new List<int>();

                //ask to enter values
                //validation is done
                try
                {
                    Console.WriteLine("Please enter number of rows: ");
                    rm.RowNum = int.Parse(Console.ReadLine());

                    Console.WriteLine("Please enter number of columns: ");
                    rm.ColNum = int.Parse(Console.ReadLine());

                    Console.WriteLine("Please enter first numbers of the Matrix Grid:");
                    rm.MatrixList.Add(int.Parse(Console.ReadLine()));
                    //populate list with range of numbers starting at the number 
                    //user enters and increament by 1
                    populateList(rm);

                    Console.WriteLine("Please enter operation: I, D or T ");
                    rm.Operation = char.Parse(Console.ReadLine());
                    showResults(rm);
                }
                catch (Exception)
                {
                    Console.WriteLine("Sorry, you entered invalid value");
                    yesToContinue = 'n';
                }

                Console.ReadLine();
                Console.Clear();
                Console.WriteLine("Would you like to try again?\nY - yes\nEnything else- no");

                try
                {
                    //validation for continued operation check
                    yesToContinue = char.Parse(Console.ReadLine());
                }
                catch (Exception)
                {
                    yesToContinue = 'n';
                    break;
                }
                Console.Clear();
            }
        }

        private static void showResults(RunMatrix rm)
        {
            int i = 0; // helper value
            int a = 0; // helper value to demonstrate add or subtruct of operation

            Console.WriteLine("\nMatrix Grid:");

            //choice I – Increase all elements in this matrix by 1.
            if (rm.Operation == 'i' || rm.Operation == 'I')
            {
                a = 1;   // set to 1 to increasethe values by 1
                DrawMatrixGrid(rm.MatrixList, rm.ColNum, i, a);
            }
            //choice D – Decrease all elements in this matrix by 1.
            else if (rm.Operation == 'd' || rm.Operation == 'D')
            {
                a = 2; // set to 2 to decreasethe values by 1
                DrawMatrixGrid(rm.MatrixList, rm.ColNum, i, a);
            }

            //choice T - Return the transpose of this matrix.
            else if (rm.Operation == 't' || rm.Operation == 'T')
            {
                List<int> temp = new List<int>();

                //Clone the List

                rm.MatrixList.ForEach((item) =>
                {
                    temp.Add(item);
                });

                //swap the values of the List to show in correct order
                int rows = 0;
                for (int roll = 0; roll < rm.MatrixList.Count(); roll++)
                {
                    temp[roll] = rm.MatrixList[rows];
                    rows += rm.ColNum;
                    if (rows >= rm.MatrixList.Count())
                    {
                        rows = rows - rm.MatrixList.Count() + 1;
                    }
                }

                // Show the Matrix to the user

                DrawMatrixGrid(temp, rm.RowNum, i, a);
            }
            else
            {
                Console.WriteLine("Unknown Operation");
            }
        }

        private static void DrawMatrixGrid(List<int> temp, int Num, int i, int a)
        {
            foreach (int c in temp)
            {
                if (a == 1) { Console.Write(temp[i] + 1); }
                else if (a == 2) { Console.Write(temp[i] - 1); }
                else { Console.Write(temp[i]); }

                i++;
                if (i < temp.Count)
                {
                    Console.Write(", ");
                    if (i % Num == 0) { Console.Write("\n"); }
                }
            }
        }

        // populate List with range of numbers
        private static void populateList(RunMatrix rmM)
        {
            rmM.MatrixList = Enumerable.Range(rmM.MatrixList[0], rmM.RowNum * rmM.ColNum).ToList();
        }
    }

    //Matrix class
    class RunMatrix
    {
        public int RowNum { get; set; }
        public int ColNum { get; set; }
        public char Operation { get; set; }
        public List<int> MatrixList { get; set; }
    }
}
