using Hub.Infrastructure.MQTT;

namespace Hub;


public partial class MainPage : ContentPage
{
    private readonly MqttClientProvider _mqttClientProvider;

    public MainPage(IServiceProvider serviceProvider)
    {
        InitializeComponent();

        _mqttClientProvider = serviceProvider.GetRequiredService<MqttClientProvider>();
    }
}
