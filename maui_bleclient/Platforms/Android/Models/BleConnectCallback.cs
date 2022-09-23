using Android.Bluetooth;
using Android.Runtime;

namespace maui_bleclient.Models;

internal sealed class BleConnectCallback : BluetoothGattCallback
{
    public override void OnConnectionStateChange(BluetoothGatt gatt, [GeneratedEnum] GattStatus status, [GeneratedEnum] ProfileState newState)
    {
        Console.WriteLine($"DEBUG | device={gatt?.Device?.Name} status={status} newState={newState}");
    }
}
