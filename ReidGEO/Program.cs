using StackExchange.Redis;

namespace ReidGEO
{
    internal static class Program
    {
        static void Main(string[] args)
        {
            // https://stackoverflow.com/questions/33196237/how-to-set-expire-when-using-redis-geoadd

            var connection = ConnectionMultiplexer.Connect("localhost:6379");
            var db = connection.GetDatabase();

            // 添加位置
            //db.GeoAdd("beijing", new GeoEntry(116.359387, 40.066074, "东南门"));
            //db.GeoAdd("beijing", new GeoEntry(116.359044, 40.066033, "亮哲剪艺"));

            // 两个位置之间的距离
            //var distance = db.GeoDistance("beijing", "东南门", "亮哲剪艺", GeoUnit.Meters);

            // 以某个位置为中心方圆30米内的位置，返回结果里包含中心位置
            var results = db.GeoRadius("beijing", "东南门", 20);
            foreach (var item in results)
            {
                Console.WriteLine(item.Member.ToString() + item.Distance);
            }

            Console.WriteLine("Hello, World!");
            Console.ReadKey();
        }
    }
}