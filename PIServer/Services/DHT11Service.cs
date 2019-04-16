namespace PIServer.Service
{
    public interface IDHT11Service
    {
        DHT11Result CurrentStatus();
    }

    public class DHT11Service : IDHT11Service
    {
        public DHT11Result CurrentStatus()
        {
            return new DHT11Result
            {
                temperature = 1,
                humidity = 1
            };
        }
    }

    public class DHT11Result
    {
        public float temperature { get; set; }

        public float humidity { get; set; }
    }
}
