using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PhanSoApp   {

public class PhanSo
{
    public int TuSo { get; private set; }
    public int MauSo { get; private set; }

    public PhanSo(int tuSo, int mauSo)
    {
        if (mauSo == 0) {
            throw new ArgumentException("Mau so khong duoc bang 0!");
        }
        // Xu ly dau: dua dau am len tu so
        if (mauSo < 0) { 
            tuSo = -tuSo; 
            mauSo = -mauSo; 
        }
        int ucln = UCLN(Math.Abs(tuSo), mauSo);
        TuSo = tuSo / ucln;
        MauSo = mauSo / ucln;
    }

    private static int UCLN(int a, int b)
    {
        while (b != 0) { 
            int t = b; 
            b = a % b; 
            a = t; 
        }
        return a;
    }

    public PhanSo RutGon() {
        return new PhanSo(TuSo, MauSo); // Constructor da tu dong rut gon
    }

    public override string ToString() {
        if (MauSo == 1) return TuSo.ToString();
        return $"{TuSo}/{MauSo}";
    }
//BaiTap2:
    public static PhanSo operator + (PhanSo a, PhanSo b) 
    {
            int tuSoMoi = a.TuSo * b.MauSo + b.TuSo * a.MauSo;
            int mauSoMoi = a.MauSo * b.MauSo;
            return new PhanSo(tuSoMoi, mauSoMoi);
        }
   
    public static PhanSo operator - (PhanSo a, PhanSo b)
        {
            int tuSoMoi = a.TuSo * b.MauSo - b.TuSo * a.MauSo;
            int mauSoMoi = a.MauSo * b.MauSo;
            return new PhanSo(tuSoMoi, mauSoMoi);
        }

    public static PhanSo operator * (PhanSo a, PhanSo b)
        {
            int tuSoMoi = a.TuSo * b.TuSo;
            int mauSoMoi = a.MauSo * b.MauSo;
            return new PhanSo(tuSoMoi, mauSoMoi);
        }
    
    public static PhanSo operator / (PhanSo a, PhanSo b)
        {
            int tuSoMoi = a.TuSo * b.MauSo;
            int mauSoMoi = a.MauSo * b.TuSo;
            if (mauSoMoi == 0) {
                throw new DivideByZeroException("Khong the chia cho phan so co tu so bang 0!");
            }
            return new PhanSo(tuSoMoi, mauSoMoi);
        }

        // Yêu cầu nâng cao: 
        // Thêm operator + nhận một tham số PhanSo và một tham 
        // số int để tính ps1 + 2 (cộng phân số với số nguyên). 
        // Gợi ý: đổi số nguyên 2 thành phân số 2/1.
    public static PhanSo operator + (PhanSo a, int b)
    {
        if (b == 0)
            {
                throw new ArgumentException("Khong the cong voi so nguyen bang 0!");
            }
            int tuSoMoi = a.TuSo + b * a.MauSo; // b được nhân với mẫu số để chuyển thành phân số
            int mauSoMoi = a.MauSo;
            return new PhanSo(tuSoMoi, mauSoMoi);
    }

// Cũng nên thêm operator + để hỗ trợ cộng ngược: int + PhanSo
    public static PhanSo operator + (int a, PhanSo b)
    {
        return b + a; // Sử dụng operator đã định nghĩa ở trên
    }

// BaiTap3: Nap Chong Toan Tu
    public static bool operator == (PhanSo a, PhanSo b)
        {
            return a.TuSo * b.MauSo == a.MauSo * b.TuSo; // quy dong roi so sanh tu so
        }
    
    public static bool operator != (PhanSo a, PhanSo b)
        {
            return !( a == b ); //Tai su dung logic da dinh nghia o ==
        }
    
    //ToanTu nho hon
    public static bool operator < (PhanSo a, PhanSo b)
        {
            return a.TuSo * b.MauSo < a.MauSo * b.TuSo;
        }

    //Toan Tu lon hon
    public static bool operator > (PhanSo a, PhanSo b)
        {
            return a.TuSo * b.MauSo > a.MauSo * b.TuSo;
        }



  }
}