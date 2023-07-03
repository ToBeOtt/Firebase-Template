using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hub.Infrastructure.MQTT
{
    public class MqttClientSettings
    {
        public string BrokerUrl { get; set; }
        public int Port { get; set; }
        public string ClientId { get; set; }

        public MqttClientSettings(string brokerUrl, int port, string clientId)
        {
            BrokerUrl = brokerUrl;
            Port = port;
            ClientId = clientId;
        }
    }
}
