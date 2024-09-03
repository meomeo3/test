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
 *             //int left = Console.CursorLeft;
            //int top = Console.CursorTop;
            //Console.WriteLine($"\nVị trí con trỏ hiện tại: Left = {left}, Top = {top}");
            //Console.SetCursorPosition(left, top + 1);
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
            int[] tt = { 1, 2, 3, 4 };// thu tu chi tien trinh
            int[] tdv = { 0, 1, 2, 3 };
            int[] dut = { 2, 3, 4, 1 };// do uu tienn cac tien trinh
            int[] tgth = { 13, 8, 21, 16 };//tg cho cac tien trinh
            // tinh tgian chờ tung tien trinh

            int[] tgc = new int[n];// mang chua thoi gian cho
            tgc[0] = 0;
            for (i = 1; i < n; i++)
            {
                tgc[i] = tgc[i - 1] + tgth[i - 1];
            }

            FCFS(tt, tgth, tgc);

            Sxtang(dut, tt, tgth, tgc);
            priority(tt, tgth, tgc);
            Sxtang(tgth, tt, tgc,dut);

            Console.ReadKey();
        }
        static void Swap(ref int x, ref int y)
        {
            int temp = x;
            x = y;
            y = temp;

        }
        static void Sxtang(int[] a, int[] b, int[] c, int[] d)
        {
            int n = a.Length;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    if (a[i] < a[j]) // So sánh các phần tử trong mảng a
                    {
                        // Hoán đổi các phần tử trong tất cả các mảng
                        Swap(ref a[i], ref a[j]);
                        Swap(ref b[i], ref b[j]);
                        Swap(ref c[i], ref c[j]);
                        Swap(ref d[i], ref d[j]);
                    }
                }
            }
        }

        static void FCFS(int[] tt, int[] tgth, int[] tgc)
        {
            int n = tt.Length;
            Console.WriteLine("\n1. Giải thuật FCFS:");
            Console.WriteLine("* BIỂU ĐỒ GANTT");
            Console.WriteLine("   Tiến Trình:");
            int dem = 0;
            Console.SetCursorPosition(15, 5);
            vekt('├', 1);
            for (int i = 0; i < n; i++)
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

            Console.SetCursorPosition(15 + dem + n, 6);
            Console.Write("{0}", tongtg(tgth));

            for (int i = 0; i < n; ++i)
            {
                Console.SetCursorPosition(15, i + 7);
                Console.Write($"Thời gian chờ của tiến trình P{i + 1} là: " + tgc[i]);
                Console.SetCursorPosition(57, i + 7);
                Console.Write($"Thời gian lưu lại của tiến trình P{i + 1} là: " + (tgth[i] + tgc[i]));
            }
        }
        static void priority(int[] tt, int[] tgth, int[] tgc)
        {
            int n = tt.Length;
            Console.WriteLine("\n1. Giải thuật Priority:");
            Console.WriteLine("* BIỂU ĐỒ GANTT");
            Console.WriteLine("   Tiến Trình:");
            int dem = 0;
            Console.SetCursorPosition(15, 15);
            vekt('├', 1);
            for (int i = 0; i < n; i++)
            {
                int SoVach = tgth[i] / Min(tgth);
                if (tgth[i] % Min(tgth) > Min(tgth) / 2)
                    SoVach++;
                Console.SetCursorPosition(15 + i + dem, 14);
                Console.Write("P{0}", tt[i]);
                Console.SetCursorPosition(16 + i + dem, 15);

                vekt('─', SoVach * 5);
                if (i != n - 1)
                    vekt('┼', 1);
                else
                    vekt('┤', 1);
                Console.SetCursorPosition(15 + i + dem, 16);
                Console.Write("{0}", tgc[i]);
                dem += SoVach * 5;
            }

            Console.SetCursorPosition(15 + dem + n, 16);
            Console.Write("{0}", tongtg(tgth));

            for (int i = 0; i < n; ++i)
            {
                Console.SetCursorPosition(15, i + 17);
                Console.Write($"Thời gian chờ của tiến trình P{i + 1} là: " + tgc[i]);
                Console.SetCursorPosition(57, i + 17);
                Console.Write($"Thời gian lưu lại của tiến trình P{i + 1} là: " + (tgth[i] + tgc[i]));
            }
        }
        static void SJF(int[] tt, int[] tgth, int[] tgc)
        {
            int n = tt.Length;
            Console.WriteLine("\n1. Giải thuật SJF:");
            Console.WriteLine("* BIỂU ĐỒ GANTT");
            Console.WriteLine("   Tiến Trình:");
            int dem = 0;
            Console.SetCursorPosition(15, 25);
            vekt('├', 1);
            for (int i = 0; i < n; i++)
            {
                int SoVach = tgth[i] / Min(tgth);
                if (tgth[i] % Min(tgth) > Min(tgth) / 2)
                    SoVach++;
                Console.SetCursorPosition(15 + i + dem, 24);
                Console.Write("P{0}", tt[i]);
                Console.SetCursorPosition(16 + i + dem, 25);

                vekt('─', SoVach * 5);
                if (i != n - 1)
                    vekt('┼', 1);
                else
                    vekt('┤', 1);
                Console.SetCursorPosition(15 + i + dem, 26);
                Console.Write("{0}", tgc[i]);
                dem += SoVach * 5;
            }

            Console.SetCursorPosition(15 + dem + n, 26);
            Console.Write("{0}", tongtg(tgth));

            for (int i = 0; i < n; ++i)
            {
                Console.SetCursorPosition(15, i + 27);
                Console.Write($"Thời gian chờ của tiến trình P{i + 1} là: " + tgc[i]);
                Console.SetCursorPosition(57, i + 27);
                Console.Write($"Thời gian lưu lại của tiến trình P{i + 1} là: " + (tgth[i] + tgc[i]));
            }
        }

    }
}
