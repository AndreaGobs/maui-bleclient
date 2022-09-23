namespace maui_bleclient.Services;

internal partial class BleClientService
{
    private Models.BleClient mBleClient;

    public BleClientService()
    {
        mBleClient = new Models.BleClient();
    }

    partial void IsEnableHandler(ref bool? enable)
    {
        enable = mBleClient.IsEnable;
    }

    partial void ScanHandler(Action<string> foundDevice, ref bool? result)
    {
        result = mBleClient.Scan(foundDevice);
    }

    partial void ConnectHandler(string device, ref bool? result)
    {
        result = mBleClient.Connect(device);
    }
}
