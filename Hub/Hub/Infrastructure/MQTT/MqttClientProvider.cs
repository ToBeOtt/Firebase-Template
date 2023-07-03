using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hub.Infrastructure.MQTT
{
    public class MqttClientProvider
    {
        private readonly IMqttClient _mqttClient;
        private readonly MqttClientOptions _options;
        public MqttClientProvider(MqttClientSettings mqttClientSettings)
        {
            var factory = new MqttFactory();
            _mqttClient = factory.CreateMqttClient();
            _options = CreateClient(mqttClientSettings);
        }

        private MqttClientOptions CreateClient(MqttClientSettings mqttClientSettings)
        {
            return new MqttClientOptionsBuilder()
                .WithClientId(mqttClientSettings.ClientId)
                .WithTcpServer(mqttClientSettings.BrokerUrl, mqttClientSettings.Port)
                .Build();
        }

        public async Task ConnectAsync()
        {
            await _mqttClient.ConnectAsync(_options);
        }

        public IMqttClient GetMqttClient()
        {
            return _mqttClient;
        }

        public async Task DisconnectAsync()
        {
            await _mqttClient.DisconnectAsync();
        }

    }
}
