using System;
using System.IO;
using System.Security.Cryptography;

class Program
{
    static void Main(string[] args)
    {
        if (args.Length == 0)
        {
            Console.WriteLine("用法: FileHasher <文件路径>");
            return;
        }

        string filePath = args[0];

        if (!File.Exists(filePath))
        {
            Console.WriteLine($"文件不存在: {filePath}");
            return;
        }

        using FileStream stream = File.OpenRead(filePath);
        using SHA256 sha256 = SHA256.Create();

        byte[] hashBytes = sha256.ComputeHash(stream);
        string hashHex = Convert.ToHexString(hashBytes);

        Console.WriteLine($"文件: {filePath}");
        Console.WriteLine($"大小: {new FileInfo(filePath).Length} 字节");
        Console.WriteLine($"SHA256: {hashHex}");
    }
}