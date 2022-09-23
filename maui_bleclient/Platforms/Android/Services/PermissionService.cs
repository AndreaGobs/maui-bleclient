namespace maui_bleclient.Services;

internal partial class PermissionService
{
    partial void CheckBluetoothHandler(ref Task<PermissionStatus> task)
    {
        task = CheckBluetoothHandlerTask();
    }

    private async Task<PermissionStatus> CheckBluetoothHandlerTask()
    {
        PermissionStatus status = PermissionStatus.Unknown;

        if (DeviceInfo.Version < new Version(12, 0))
        {
            status = await Permissions.CheckStatusAsync<Permissions.LocationWhenInUse>();
            if (status != PermissionStatus.Granted)
                status = await Permissions.RequestAsync<Permissions.LocationWhenInUse>();
            await Task.Delay(1000);
        }

        if (DeviceInfo.Version >= new Version(12, 0))
        {
            status = await Permissions.CheckStatusAsync<Models.BluetoothConnectPermission>();
            if (status != PermissionStatus.Granted)
                status = await Permissions.RequestAsync<Models.BluetoothConnectPermission>();
            await Task.Delay(1000);
        }

        return status;
    }
}
