using UnityEngine;
using System.Runtime.InteropServices;

public enum GameMode
{
    VsBot,
    VsFriend
}

public class GlobalGameManager : MonoBehaviour
{
    public static GlobalGameManager Instance { get; private set; }
    public GameMode currentGameMode = GameMode.VsBot;

    public enum DeviceTypeEnum
    {
        Desktop,
        Mobile,
        Tablet
    }
    public DeviceTypeEnum currentDevice;


    [DllImport("__Internal")]
    private static extern int GetDeviceType();
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        DeviceDetect();
    }

    private void DeviceDetect()
    {

#if UNITY_WEBGL && !UNITY_EDITOR
        int deviceType = GetDeviceType();
#else
        int deviceType = 0; // Default to desktop in editor
#endif

        switch (deviceType)
        {
            case 0: // Desktop
                currentDevice = DeviceTypeEnum.Desktop;
                break;
            case 1: // Mobile
                currentDevice = DeviceTypeEnum.Mobile;
                break;
            case 2: // Tablet
                currentDevice = DeviceTypeEnum.Tablet;
                break;
            default:
                currentDevice = DeviceTypeEnum.Desktop;
                break;
        }
    }
    public void SetGameMode(GameMode mode)
    {
        currentGameMode = mode;
    }


}
