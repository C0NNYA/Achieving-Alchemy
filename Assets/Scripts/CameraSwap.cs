using UnityEngine;

public class CameraSwap : MonoBehaviour
{
    public GameObject MainCam;
    public GameObject SettingsCam;

    public void MainSwitch()
    {
        MainCam.SetActive(false);
        SettingsCam.SetActive(true);
    }
    public void SettingSwitch()
    {
        MainCam.SetActive(true);
        SettingsCam.SetActive(false);
    }
}
