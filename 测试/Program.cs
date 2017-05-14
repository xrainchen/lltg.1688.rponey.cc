using System;
using RPoney.Utilty.Extend;

namespace 测试
{
    class Program
    {
        static void Main(string[] args)
        {
            var time = "20171105210318000+0800";
            Console.WriteLine(time.GetDateTimeFromUtc(DateTime.MinValue));
            Console.WriteLine(DateTime.Today.ToLocalTimeStamp());
            Console.WriteLine(DateTimeExtend.GetDateTimeFromTimeStamp(1494339852));
            Console.Read();
        }
    }
}
