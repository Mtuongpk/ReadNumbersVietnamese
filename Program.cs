using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocSoThanhChu
{
    class Program
    {
        static public int SoChuSo(int a)
        {
            //Hàm đếm số chữ số của 1 số
            int d = 0;
            while (a != 0)
            {
                a /= 10;
                d++;
            }
            return d;
        }
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8; //Support display vietnamese language
            Console.SetWindowSize(Console.WindowWidth + 35, Console.WindowHeight);
            //Set width and height of console screen
            var cs = new DocSo();
            int d; //number of elements of array a
            //for (var i = 0; i < 1000; i++)
            //{
            //    cs.ThreeDigit(i, 0);
            //    Console.WriteLine();
            //}
            string chuso; //string chuso dùng để lưu số cần đọc. Tránh bị tràn giá trị do giới hạn kiểu nguyên / thực
            continueProgram:
            double[] a = new double[30]; //mảng dùng để tách số cần đọc thành những số có 9 chữ số
            d = 0;
            Console.Write("Nhập một số tự nhiên bất kỳ: ");
            chuso = Console.ReadLine();
            var len_cs = chuso.Length; // variable store length of chuso
            //Kiểm tra chuỗi chuso có ký tự nào ngoài số không.
            foreach (char value in chuso)
            {
                if (value < '0' || value > '9')
                {
                    Console.WriteLine("Chỉ được nhập số tự nhiên!");
                    goto checkContinue;
                }
            }
            Console.Write($"Số {chuso} đọc là: ");
            for (int i = len_cs - 1; i >= 0; i--)
            {
                a[d] += (chuso[i] - '0') * Math.Pow(10, (len_cs - i - 1 - (9 * d)));
                if ((len_cs - i) % 9 == 0)
                    d++;
            }

            //for (var i = 0; i <= d; i++)
            //{
            //    Console.WriteLine($"{d}, {i}");
            //    Console.WriteLine(SoChuSo(Convert.ToInt32(a[i])));
            //    Console.WriteLine(a[i]);
            //}

            if (a[d] == 0)
            {
                 for (int i = d - 1; i >= 0; i--)
                 {
                     if ((a[i] > 0 && a[i + 1] == 0) || a[0] > 0)
                         goto normalCase;
                 }
                Console.Write("không ");
            }
            normalCase:
            if (a[d] > 0)
            {
                cs.NineDigit(Convert.ToInt32(a[d]), 0);
                for (int i = d; i > 0; i--)
                    Console.Write("tỷ ");
            }
            for (int i = d - 1; i >= 0; i--)
            {
                int k = 1;
                if (a[i] == 0 || (SoChuSo(Convert.ToInt32(a[i])) % 3 != 0 && i != 0) || a[i + 1] == 0)
                    k = 0;
                cs.NineDigit(Convert.ToInt32(a[i]), k);
                for (int j = i; j > 0; j--)
                {
                    if (a[j] != 0)
                        Console.Write("tỷ ");
                }
            }
            checkContinue:
            try
            {
                Console.WriteLine();
                Console.WriteLine("Bạn có muốn tiếp tục không (y/n)?");
                char kiemtra = char.Parse(Console.ReadLine());
                if (kiemtra == 'y' || kiemtra == 'Y')
                {
                    goto continueProgram;
                }
                else
                    return; // Đóng chương trình
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                Console.Read();
                return;
            }
        }
    }
}