using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocSoThanhChu
{
    class DocSo
    {
        string[] chucai = { "không ", "một ", "hai ", "ba ", "bốn ", "năm ", "sáu ", "bảy ", "tám ", "chín ", "mười " };
        string[] donvi = { "", "nghìn", "triệu" };
        public void SoSangChu(int a)
        {
            Console.Write(chucai[a]);
            //In chữ cái trong chuỗi chucai lên màn hình
        }
        public void DocDonVi(int a)
        {
            Console.Write(donvi[a]);
        }
        //Hàm đọc hai chữ số
        //----------------------------------------------------------------------
        public void TwoDigit(int a)
        {
            int hc, dv; //Biến lưu chữ số hàng chục và đơn vị của số có 2 chữ số
            hc = a / 10;
            dv = a % 10;
            //----------------------------------------
            //Đọc chữ số hàng chục
            if (hc == 1)
            {
                Console.Write("mười ");
            }
            else if (hc != 0)
            {
                SoSangChu(hc);
                Console.Write("mươi ");
            }
            else
            {
                SoSangChu(hc);
            }
            //----------------------------------------
            //Đọc chữ số hàng đơn vị
            if (dv != 1 && dv != 4 && dv != 5)
            {
                //expect 16: mười sáu
                //69: sáu mươi chín
                if (dv != 0)
                {
                    SoSangChu(dv);
                }
            }
            if (dv == 1)
            {
                //expect 11: mười một
                //21: hai mươi mốt
                if (hc == 1 || hc == 0)
                {
                    SoSangChu(dv);
                }
                else
                    Console.Write("mốt ");
            }
            if (dv == 4)
            {
                //expect 14: mười bốn
                //24: hai mươi tư
                if (hc == 1 || hc == 0)
                    SoSangChu(dv);
                else
                    Console.Write("tư ");
            }
            if (dv == 5)
            {
                //expect 15: mười lăm
                //05: năm (305: ba trăm linh năm)
                if (hc != 0)
                    Console.Write("lăm ");
                else
                    SoSangChu(dv);
            }
        }
        //Hàm đọc ba chữ số
        //----------------------------------------------------------------------
        public void ThreeDigit(int a, int b)
        {
            int ht, hc, dv;//Biến lưu trữ hàng trăm, hàng chục, đơn vị của số có 3 chữ số
            ht = a / 100;
            dv = a % 10;
            hc = (a / 10) % 10;
            //b: variable store a signal.
            //expect b == 1: 028 đọc là không trăm hai mươi tám
            // b == 0: 028 đọc là hai mươi tám
            if (b == 1)
            {
                if (ht == 0)
                {
                    //hàng trăm có giá trị 0
                    if (hc == 0)
                    {
                        //Hàng chục có giá trị 0
                        if (dv == 0)
                            Console.Write("không ");
                        else
                        {
                            Console.Write("không trăm linh ");
                            SoSangChu(dv);
                        }
                    }
                    else
                    {
                        //hàng chục có giá trị khác không
                        Console.Write("không trăm ");
                        TwoDigit(a % 100); //đọc 2 chữ số
                    }
                }
                else
                    ThreeDigit(a, 0); //gọi lại hàm này với tham số b = 0 trong trường hợp hàng trăm khác 0
            }
            else
            {
                if (ht != 0)
                {
                    SoSangChu(ht);
                    Console.Write("trăm ");
                }
                if (hc == 0)
                    if (dv == 0)
                    {
                        //Console.Write("không ");
                        return;
                    }
                    else
                    {
                        if (ht > 0)
                            Console.Write("linh ");
                        SoSangChu(dv);
                    }
                else
                    TwoDigit(a % 100);
            }
        }
        //Hàm đọc chín chữ số
        //----------------------------------------------------------------------
        public void NineDigit(int n, int k)
        {
            int[] a = new int[3]; //Mảng lưu giá trị 3 chữ số, tách ra từ số có 9 chữ số
            int d = 0;//number of elements of array a
            if (n < 1000)
            {
                ThreeDigit(n, k);
                return;
            }
            else while (n != 0)
                {
                    a[d] = n % 1000;
                    d++;
                    n /= 1000;
                }
            for (var i = d - 1; i >= 0; i--)
            {
                ThreeDigit(a[i], k);
                if ((i > 0 && a[i] != 0))
                {
                    DocDonVi(i);
                    Console.Write(" ");
                }
                if (a[i] == 0 && i > 0 && a[i-1] > 0)
                {
                    //expect: 1000148 đọc là một triệu không nghìn một trăm bốn mươi tám
                    Console.Write("không ");
                    DocDonVi(i);
                    Console.Write(" ");
                }
                if (i > 0 && a[i - 1] != 0)
                    k = 1;
                if ((i > 0 && a[i - 1] == 0) || (i == 0 && a[0] == 0))
                    k = 0;
            }
        }
    }
}
