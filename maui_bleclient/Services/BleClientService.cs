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
        if (IsEnable == true)
        {
            bool? result = null;
            ScanHandler(foundDevice, ref result);
            return result;
        } 
        return null;
    }

    public bool? Connect(string device)
    {
        if (IsEnable == true)
        {
            bool? result = null;
            ConnectHandler(device, ref result);
            return result;
        }
        return null;
    }

    partial void IsEnableHandler(ref bool? enable);
    partial void ScanHandler(Action<string> foundDevice, ref bool? result);
    partial void ConnectHandler(string device, ref bool? result);
}
