using static Microsoft.Maui.ApplicationModel.Permissions;

namespace maui_bleclient.Models;

internal class BluetoothConnectPermission : BasePlatformPermission
{
    public override (string androidPermission, bool isRuntime)[] RequiredPermissions => new List<(string androidPermission, bool isRuntime)>
    {
        (global::Android.Manifest.Permission.BluetoothScan, true),
        (global::Android.Manifest.Permission.BluetoothConnect, true)
    }.ToArray();
}
