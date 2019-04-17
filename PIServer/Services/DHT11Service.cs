using Iot.Device.DHTxx;

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
            using (DHTSensor dht = new DHTSensor(2, DhtType.Dht11))
            {
                return new DHT11Result
                {
                    Temperature = dht.Temperature.Celsius,
                    Humidity = dht.Humidity
                };
            }
        }
    }

    public class DHT11Result
    {
        public double Temperature { get; set; }

        public double Humidity { get; set; }
    }
}
