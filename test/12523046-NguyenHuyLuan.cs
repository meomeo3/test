/* cài đặt các giải thuật lập lệnh cho cpu
 * input:
 * n : só lượng tiến trình
 * tdv[n]: thời điểm vào Rl
 * do ut [n] : độ ưu tiên 
 * tgth[n]: thời gian thực hiện
 * output:
 * biểu đồ gantt cho mỗi giải thuật
 * tgian chờ tb của các tt
 * thời gian lưu lại 
 * 4 ky tu ve gantt ├ ─ ┼ ┤
 */
using System;
using System.Text;

namespace test
{
    internal class Program
    {
        // ham viet ki tu kt voi so lan la "SL"
        static void vekt(char kt, int sl)
        {
            for (int i = 0; i < sl; i++)
            {
                Console.Write(kt);
            }
        }
        static int Min(int[] tmp)
        {
            int nhonhat = tmp[0];
            for (int i = 1; i < tmp.Length; i++)

                if (tmp[i] <= nhonhat)

                    nhonhat = tmp[i];

            return nhonhat;

        }
        static int tongtg(int[] tmp)
        {
            int tong = tmp[0];
            for (int i = 1; i < tmp.Length; i++)
            {
                tong += tmp[i];
            }
            return tong;
        }

        static void Main(string[] args)
        {

            Console.OutputEncoding = Encoding.UTF8;
            int i;
            int n = 4;
            int[] tt = { 1, 2, 3, 4 };// tien trinh
            int[] tdv = { 0, 1, 2, 3 };
            int[] dut = { 2, 3, 4, 1 };
            int[] tgth = { 13, 8, 21, 16 };
            // tinh tgian chờ tung tien trinh
            int[] tgc = new int[n];// mang chua thoi gian cho
            tgc[0] = 0;
            for (i = 1; i < n; i++)
            {
                tgc[i] = tgc[i - 1] + tgth[i - 1];
            }
            //tinh toan de ve
            Console.WriteLine("cài đăt  các giải thuật ");
            Console.WriteLine("\n1.Giải thuật FCFS: ");
            Console.WriteLine("* BIỂU ĐÒ GANTT");
            Console.WriteLine("   Tiến Trình: ");
            Console.WriteLine("\nThời Gian Chờ: ");
            Console.SetCursorPosition(15, 5);//dau con tro den hang 15 cot 5
            vekt('├', 1);//VE kt dau tien cua gantt
            // tinh so vach '-' cho moi tt
            int dem = 0;
            for (i = 0; i < n; i++)
            {
                int SoVach = tgth[i] / Min(tgth);
                if (tgth[i] % Min(tgth) > Min(tgth) / 2)
                    SoVach++;
                Console.SetCursorPosition(15 + i + dem, 4);
                Console.Write("P{0}", tt[i]);
                Console.SetCursorPosition(16 + i + dem, 5);
                vekt('─', SoVach * 5);
                if (i != n - 1)
                    vekt('┼', 1);
                else
                    vekt('┤', 1);
                Console.SetCursorPosition(15 + i + dem, 6);
                Console.Write("{0}", tgc[i]);
                dem += SoVach * 5;
            }



            Console.SetCursorPosition(15 + dem + i, 6);
            Console.Write("{0}", tongtg(tgth));
            
            for (i = 0; i < n; ++i)
            {
                Console.SetCursorPosition(15, i+7);
                Console.Write($"thời gian chờ của tiến trình P{i + 1} là: " + tgc[i]);
                Console.SetCursorPosition(15+42, i + 7);
                Console.Write($"thời gian lưu lại  của tiến trình P{i + 1} là: " + (tgth[i] + tgc[i]));
            }
            
         
            Console.ReadKey();
        }

       
    }
}
