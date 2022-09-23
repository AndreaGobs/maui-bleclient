namespace maui_bleclient.Services;

internal partial class PermissionService
{
    public Task<PermissionStatus> CheckBluetooth()
    {
        Task<PermissionStatus> result = null;
        CheckBluetoothHandler(ref result);
        if (result != null)
            return result;
        else
            return result = Task.FromResult(PermissionStatus.Unknown);
    }

    partial void CheckBluetoothHandler(ref Task<PermissionStatus> task);
}
