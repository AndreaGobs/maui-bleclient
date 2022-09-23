namespace maui_bleclient.Services;

internal partial class BleClientService
{
    public bool? IsEnable
    {
        get
        {
            bool? enable = null;
            IsEnableHandler(ref enable);
            return enable;
        }
    }

    public bool? Scan(Action<string> foundDevice)
    {
        var result = IsEnable;
        if (IsEnable == true)
        {

        }
        return result;
    }

    public bool? Connect(string device)
    {
        var result = IsEnable;
        if (IsEnable == true)
        {

        }
        return result;
    }

    partial void IsEnableHandler(ref bool? enable);
    partial void ScanHandler(Action<string> foundDevice);
    partial void ConnectHandler(string device);
}
