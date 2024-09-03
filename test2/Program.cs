using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test2
{
    internal class Program
    {
        static int tongtg(int[] tmp)
        {
            int tong = tmp[0];
            for (int i = 1; i < tmp.Length; i++)
            {
                tong += tmp[i];
            }
            return tong;
        }
        // ham hoan doi 
        static void Swap(ref int a, ref int b)
        {
            int tmp = a;
            a = b;
            b = tmp;    
        }
        /*
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            int n = 4;
            int[] tt = { 1, 2, 3, 4 };
            int[] tdv = { 0, 1, 2, 3 };
            int[] dut = { 2, 3, 4, 1 };
            int[] tgth = { 13, 8, 21, 16 };
            Console.ReadKey();
            Console.WriteLine("mang chua sx: ");
            Console.WriteLine(dut);
            Console.WriteLine("mang da sx: ");


        }
        //mang dau tien tang dan cac mang khac keo theo
        static void SXtang(int[] tmp1, int[] tmp2, int[] tmp3,int [] tmp4,int n)
        {
            int i,j;
            for (i = 0; i < tmp1.Length; i++) 
            {
                for (j = i+1;j<tmp1.Length;j++)
                {
                        Swap(ref tmp1[i], ref tmp1[j]);
                        Swap(ref tmp2[i], ref tmp2[j]); 
                        Swap(ref tmp3[i], ref tmp3[j]);
                        Swap(ref tmp4[i], ref tmp4[j]);

                    
                }
            }
        }
        */



        static void Main()
        {
            int n = 4;
            int[] tt = { 1, 2, 3, 4 };
            int[] tgth = { 13, 8, 21, 16 };

            // Tính thời gian chờ cho từng tiến trình
            int[] tgc = new int[n];
            tgc[0] = 0;
            for (int i = 1; i < n; i++)
            {
                tgc[i] = tgc[i - 1] + tgth[i - 1];
            }

            // Vẽ biểu đồ Gantt
            Console.WriteLine("GIẢI THUẬT FCFS - BIỂU ĐỒ GANTT");
            Console.WriteLine("Tiến Trình\tThời Gian Chờ");
            for (int i = 0; i < n; i++)
            {
                Console.Write($"P{tt[i]}");
                for (int j = 0; j < tgth[i]; j++)
                {
                    Console.Write("-");
                }
                Console.WriteLine($"\t\t{tgc[i]}");
            }

            Console.WriteLine($"Tổng thời gian lưu lại: {tgc[n - 1] + tgth[n - 1]}");
            Console.ReadKey();
        }
    }

}

