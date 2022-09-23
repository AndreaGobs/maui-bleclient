namespace maui_bleclient.Services;

internal partial class BleClientService
{
    partial void IsEnableHandler(ref bool? enable)
    {
        throw new NotImplementedException();
    }

    partial void ScanHandler(Action<string> foundDevice, ref bool? result)
    {
        throw new NotImplementedException();
    }

    partial void ConnectHandler(string device, ref bool? result)
    {
        throw new NotImplementedException();
    }
}
