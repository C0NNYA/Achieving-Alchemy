using UnityEngine;

public class CameraSwap : MonoBehaviour
{
    public GameObject MainCam;
    public GameObject SettingsCam;
    public GameObject MainCanvas;
    public GameObject SettingsCanvas;

    public void MainSwitch()
    {
        MainCam.SetActive(false);
        SettingsCam.SetActive(true);
        MainCanvas.SetActive(false);
        SettingsCanvas.SetActive(true);

    }
    public void SettingSwitch()
    {
        MainCam.SetActive(true);
        SettingsCam.SetActive(false);
        SettingsCanvas.SetActive(false);
        MainCanvas.SetActive(true);
    }
}
