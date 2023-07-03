using Hub.Infrastructure.MQTT;

namespace Hub;

public partial class App : Application
{
    public static IServiceProvider ServiceProvider { get; private set; }

    public App()
    {
        InitializeComponent();

        ServiceProvider = ConfigureServices();
        MainPage = new MainPage(ServiceProvider);
    }


    private ServiceProvider ConfigureServices()
    {
        var services = new ServiceCollection();

        services.AddSingleton<MqttClientProvider>(provider =>
        {
            MqttClientSettings mqttClientSettings = new MqttClientSettings("localhost", 1883, "someClient");
            return new MqttClientProvider(mqttClientSettings);
        });

        return services.BuildServiceProvider();
    }
}
