using Vector;
using Mn;

Vector2D v1 = new Vector2D(3, 4);
Vector2D v2 = new Vector2D(1, 2);

Console.WriteLine(" Bai1: ");
Console.WriteLine($"v1 = {v1}");             // (3.00, 4.00)
Console.WriteLine($"v2 = {v2}");             // (1.00, 2.00)
Console.WriteLine($"v1 + v2 = {v1 + v2}");  // (4.00, 6.00)
Console.WriteLine($"v1 - v2 = {v1 - v2}");  // (2.00, 2.00)
Console.WriteLine($"v1 * 2  = {v1 * 2}");   // (6.00, 8.00)
Console.WriteLine($"3 * v2  = {3 * v2}");   // (3.00, 6.00)
Console.WriteLine($"-v1    = {-v1}");        // (-3.00, -4.00)
Console.WriteLine($"|v1|   = {v1.DoDai:F4}"); // 5.0000

Console.WriteLine("--- KIỂM THỬ THÊM MỚI 3 YÊU CẦU ---");

// Test Yêu cầu 3: Chuyển đổi implicit từ tuple (double, double) sang Vector2D
Vector2D v4 = (3.0, 4.0);
Vector2D v5 = (1.0, 2.0);
Vector2D v6 = (3.0, 4.0);

Console.WriteLine($"\n[Yêu cầu 3] Thử nghiệm gán Implicit từ Tuple:");
Console.WriteLine($"v4 = {v4}");
Console.WriteLine($"v5 = {v5}");
Console.WriteLine($"v6 = {v6}");

// Test Yêu cầu 1: Toán tử so sánh == và !=
Console.WriteLine($"\n[Yêu cầu 1] Thử nghiệm so sánh == và !=:");
Console.WriteLine($"v4 == v6: {v4 == v6} (Kỳ vọng: True)");
Console.WriteLine($"v4 == v5: {v4 == v5} (Kỳ vọng: False)");
Console.WriteLine($"v4 != v5: {v4 != v5} (Kỳ vọng: True)");

// Test Yêu cầu 2: Tích vô hướng Vector2D * Vector2D (Trả về double)
// Kết quả kỳ vọng: 3.0 * 1.0 + 4.0 * 2.0 = 3.0 + 8.0 = 11.0
double dotProduct = v4 * v5;
Console.WriteLine($"\n[Yêu cầu 2] Thử nghiệm tích vô hướng (v4 * v5):");
Console.WriteLine($"v4 * v5 = {dotProduct} (Kỳ vọng: 11.00)");

Console.ReadLine();





Console.WriteLine("\n Bai2: ");
Money luong = new Money(15_000_000, "VND");
Money thuong = new Money(3_000_000, "VND");
Money lamThemGio = luong * 1.5m;  // Luong lam them = 1.5x luong

Console.WriteLine($"Luong co ban:   {luong}");
Console.WriteLine($"Thuong thang:   {thuong}");
Console.WriteLine($"Luong lam them: {lamThemGio}");
Console.WriteLine($"Tong thu nhap:  {luong + thuong}");
Console.WriteLine($"Luong > Thuong: {luong > thuong}");  // True

// Kiem tra bep logic – khac don vi
try
{
    Money usd = new Money(100, "USD");
    Money tong = luong + usd;  // Nem ngoai le!
}
catch (InvalidOperationException ex)
{
    Console.WriteLine($"Loi: {ex.Message}");
    // In: Loi: Khong the thuc hien phep toan giua VND va USD...
}

Console.WriteLine("--- KIỂM THỬ THÊM MỚI LỚP MONEY ---\n");

// Khởi tạo các đối tượng tiền tệ mẫu
Money usd100 = new Money(100, "USD");
Money vnd2550 = new Money(2550000, "VND");
Money usd100_Phu = new Money(100, "USD");
Money vnd100 = new Money(100, "VND");

// 1. Test Yêu cầu 1: Quy đổi tiền tệ
Console.WriteLine("[Yêu cầu 1] Thử nghiệm phương thức QuyDoi:");
Money vndSauQuyDoi = Money.QuyDoi(usd100, "VND", 25500);
Console.WriteLine($"Quy đổi {usd100} sang VND với tỷ giá 25.500 => Kết quả: {vndSauQuyDoi}");
Console.WriteLine($"Kỳ vọng: 2,550,000 VND\n");

// 2. Test Yêu cầu 2: Toán tử so sánh == và !=
Console.WriteLine("[Yêu cầu 2] Thử nghiệm toán tử so sánh == và !=:");
Console.WriteLine($"So sánh cùng loại (100 USD == 100 USD): {usd100 == usd100_Phu} (Kỳ vọng: True)");
Console.WriteLine($"So sánh khác số tiền (2,550,000 VND == 100 VND): {vnd2550 == vnd100} (Kỳ vọng: False)");
Console.WriteLine($"So sánh khác đơn vị (100 USD == 100 VND): {usd100 == vnd100} (Kỳ vọng: False)");
Console.WriteLine($"So sánh toán tử != (100 USD != 100 VND): {usd100 != vnd100} (Kỳ vọng: True)\n");

// 3. Test Yêu cầu 3: Chia hóa đơn tiền tệ
Console.WriteLine("[Yêu cầu 3] Thử nghiệm chia hóa đơn (Toán tử /):");
Money tongHoaDon = new Money(1200000, "VND"); // 1 triệu 200 nghìn VND
int soNguoi = 4;
Money phanCua1Nguoi = tongHoaDon / soNguoi;
Console.WriteLine($"Tổng hóa đơn là {tongHoaDon} chia cho {soNguoi} người.");
Console.WriteLine($"Phần của mỗi người là: {phanCua1Nguoi}");
Console.WriteLine($"Kỳ vọng: 300,000 VND");

Console.ReadLine();



