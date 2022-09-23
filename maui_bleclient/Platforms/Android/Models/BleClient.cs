using Android.Bluetooth;
using Android.Bluetooth.LE;
using Android.Content;

namespace maui_bleclient.Models;

internal sealed class BleClient
{
    private BluetoothManager mCentralManager;
    private BleScanCallback mScanCallback;
    private BleConnectCallback mConnectCallback;

    private Timer _ScanTimer;
    private Timer _ConnectTimer;
    private BluetoothGatt _BluetoothGatt;

    public BleClient()
    {
        mScanCallback = new BleScanCallback();
        mConnectCallback = new BleConnectCallback();
    }

    public bool IsEnable
    {
        get
        {
            try
            {
                return ((BluetoothManager)Android.App.Application.Context.GetSystemService(Context.BluetoothService)).Adapter.IsEnabled;
            }
            catch
            {
                return false;
            }
        }
    }

    public bool Scan(Action<string> foundDevice)
    {
        if (mCentralManager == null)
            mCentralManager = (BluetoothManager)Android.App.Application.Context.GetSystemService(Android.App.Application.BluetoothService);

        mScanCallback.FoundDevice -= foundDevice;
        mScanCallback.FoundDevice += foundDevice;
        mScanCallback.Devices = new List<BluetoothDevice>();

        _ScanTimer = new Timer((obj) =>
        {
            mCentralManager.Adapter.BluetoothLeScanner.StopScan(mScanCallback);
        }, null, 10000, Timeout.Infinite);

        var settings = new ScanSettings.Builder().SetScanMode(Android.Bluetooth.LE.ScanMode.LowLatency).Build();
        mCentralManager.Adapter.BluetoothLeScanner.StartScan(null, settings, mScanCallback);

        return false;
    }

    public bool Connect(string device)
    {
        var bleDevice = mScanCallback.Devices?.FirstOrDefault(d => d.Name == device);
        if (bleDevice != null)
        {
            _ConnectTimer = new Timer((obj) =>
            {
                _BluetoothGatt?.Disconnect();
                _BluetoothGatt?.Dispose();
            }, null, 10000, Timeout.Infinite);

            _BluetoothGatt = bleDevice.ConnectGatt(Android.App.Application.Context, false, mConnectCallback, BluetoothTransports.Le);
            return true;
        }
        return false;
    }
}
