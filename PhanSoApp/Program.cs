using PhanSoApp;

PhanSo ps1 = new PhanSo(1, 2); // 1/2
PhanSo ps2 = new PhanSo(2, 4); // 2/4, rut gon thanh 1/2
PhanSo ps3 = new PhanSo(1, 3); // 1/3

Console.WriteLine($"ps1: {ps1}");
Console.WriteLine($"ps3: {ps3}");
Console.WriteLine($"ps1 + ps3: {ps1 + ps3}"); //5/6
Console.WriteLine($"ps1 - ps3: {ps1 - ps3}"); //1/6
Console.WriteLine($"ps1 * ps3: {ps1 * ps3}"); //1/6
Console.WriteLine($"ps1 / ps3: {ps1 / ps3}"); //3/2



