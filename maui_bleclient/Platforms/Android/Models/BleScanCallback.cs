using Android.Bluetooth;
using Android.Bluetooth.LE;

namespace maui_bleclient.Models;

internal sealed class BleScanCallback : ScanCallback
{
    public Action<string> FoundDevice { get; set; }

    public List<BluetoothDevice> Devices { get; set; }

    public override void OnScanResult(ScanCallbackType callbackType, ScanResult result)
    {
        if (Devices != null)
            if (result?.Device?.Name != null)
                if (!Devices.Any(d => d.Name == result?.Device?.Name))
                {
                    FoundDevice?.Invoke(result?.Device?.Name);
                    Devices.Add(result.Device);
                }
    }
}
