using System;
using Rponey.AlbbSDK;

namespace 测试
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = ApiCategory.GetList("4c9a7827-8028-4236-a798-e5ac155bc070",
                 "3518486",
                 "0K024PEUxUI",
                 0);
            Console.Read();
        }
    }
}
