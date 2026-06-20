using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mn;

public class Money
{
    public decimal Amount { get; private set; }
    public string Currency { get; private set; }

    public Money(decimal amount, string currency)
    {
        if (amount < 0)
            throw new ArgumentException("So tien khong the am!");
        Amount = amount;
        Currency = currency.ToUpper();
    }

    // Ham kiem tra cung don vi – dung lai trong nhieu toan tu
    private static void KiemTraCungDonVi(Money a, Money b)
    {
        if (a.Currency != b.Currency)
            throw new InvalidOperationException(
                $"Khong the thuc hien phep toan giua {a.Currency} va {b.Currency}. " +
                $"Vui long quy doi ve cung don vi truoc.");
    }

    public static Money operator +(Money a, Money b)
    {
        KiemTraCungDonVi(a, b);
        return new Money(a.Amount + b.Amount, a.Currency);
    }

    public static Money operator -(Money a, Money b)
    {
        KiemTraCungDonVi(a, b);
        if (a.Amount < b.Amount)
            throw new InvalidOperationException("Ket qua tru khong duoc am!");
        return new Money(a.Amount - b.Amount, a.Currency);
    }
    // Nhan voi he so (vi du: tinh luong lam them gio)
    public static Money operator *(Money m, decimal heSo)
    {
        if (heSo < 0)
            throw new ArgumentException("He so khong the am!");
        return new Money(m.Amount * heSo, m.Currency);
    }

    public static Money operator *(decimal heSo, Money m) => m * heSo;

    public static bool operator >(Money a, Money b)
    {
        KiemTraCungDonVi(a, b);
        return a.Amount > b.Amount;
    }

    public static bool operator <(Money a, Money b)
    {
        KiemTraCungDonVi(a, b);
        return a.Amount < b.Amount;
    }

    public override string ToString()
        => $"{Amount:N0} {Currency}";

    // 1. Thêm phương thức static Money QuyDoi(Money nguon, string donViDich, decimal tyGia)
    public static Money QuyDoi(Money nguon, string donViDich, decimal tyGia)
    {
        if (nguon == null) return null;

        // Tính số tiền mới dựa trên tỷ giá quy đổi
        decimal soTienMoi = nguon.Amount * tyGia;
        return new Money(soTienMoi, donViDich);
    }

    // 2. Cài đặt operator == và != cho Money (Kể cả khi khác đơn vị thì luôn != nhau)
    public static bool operator ==(Money a, Money b)
    {
        // Kiểm tra null an toàn trước khi so sánh
        if (ReferenceEquals(a, null)) return ReferenceEquals(b, null);
        if (ReferenceEquals(b, null)) return false;

        // Phải cùng đơn vị tiền tệ VÀ cùng số tiền thì mới bằng nhau
        return a.Currency == b.Currency && a.Amount == b.Amount;
    }

    public static bool operator !=(Money a, Money b)
    {
        return !(a == b);
    }

    // Ghi đè Equals và GetHashCode để đồng bộ với toán tử ==
    public override bool Equals(object obj)
    {
        if (obj is Money other) return this == other;
        return false;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Amount, Currency);
    }

    // 3. Thêm toán tử / để chia tiền (chia hóa đơn)
    public static Money operator /(Money m, int k)
    {
        if (k == 0) throw new DivideByZeroException("Không thể chia tiền cho 0 người.");
        if (m == null) return null;

        return new Money(m.Amount / k, m.Currency);
    }
}
