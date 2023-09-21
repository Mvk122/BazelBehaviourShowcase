using System;
using System.Text.Json;

namespace FakeNamespace {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("Hello World!");
        }
        JsonSerializerOptions options = new JsonSerializerOptions {
            WriteIndented = true
        };
    }

}