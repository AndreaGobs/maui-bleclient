using maui_bleclient.Services;

namespace maui_bleclient;

public partial class BleClientPage : ContentPage
{
	private PermissionService _permissionService;
	private BleClientService _bleClientService;
	private List<string> _Devices;

	public BleClientPage()
	{
		InitializeComponent();

		_permissionService = new PermissionService();
		_bleClientService = new BleClientService();

		_Devices = new List<string>();
    }

	private void CheckPermissionBtn_Clicked(object sender, EventArgs e)
	{
		_ = MainThread.InvokeOnMainThreadAsync(async () =>
		{
            Busy(true);

            var result = await _permissionService.CheckBluetooth();
			BlePermission.Text = result.ToString();
			Console.WriteLine("DEBUG | " + result);

            Busy(false);
        });
    }

    private void CheckBluetoothBtn_Clicked(object sender, EventArgs e)
    {
		var enable = _bleClientService.IsEnable == true;
		BleStatus.Text = enable.ToString();
        Console.WriteLine("DEBUG | " + enable);
    }

    private void ScanBtn_Clicked(object sender, EventArgs e)
	{
		_Devices.Clear();
		var result = _bleClientService.Scan(FoundDevice);
        Console.WriteLine("DEBUG | " + result);
    }

	private void ConnectBtn_Clicked(object sender, EventArgs e)
	{
        if (_Devices.Count > 0)
        {
			var device = _Devices.OrderBy(d => d.Length).Last();
			var result = _bleClientService.Connect(device);
            Console.WriteLine("DEBUG | " + result);
        }
		else
            Console.WriteLine("WARN | empty list");
    }

	private void FoundDevice(string device)
	{
		if (device?.Length > 0 && !_Devices.Any(d => d == device))
		{
            Console.WriteLine("DEBUG | " + device);
            _Devices.Add(device);
        }
	}

	private void Busy(bool busy)
	{
		if (busy)
		{
            MainLayout.IsEnabled = false;
            MainLayout.Opacity = 0.5;
            BusyIndicator.IsVisible = true;
        }
		else
		{
            MainLayout.IsEnabled = true;
            MainLayout.Opacity = 1;
            BusyIndicator.IsVisible = false;
        }
	}
}