using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class Quality : MonoBehaviour {

    public void Muy_bajo()
	{
		QualitySettings.SetQualityLevel(0);
		QualitySettings.vSyncCount = 0;
    }
	public void bajo()
	{
		QualitySettings.SetQualityLevel(1);
		QualitySettings.vSyncCount = 0;
	}
	public void Bueno()
	{
		QualitySettings.SetQualityLevel(2);
        QualitySettings.vSyncCount = 0;
    }
	public void Muy_Bueno()
	{
		QualitySettings.SetQualityLevel(3);
		QualitySettings.vSyncCount = 0;
	}
	public void Altos()
	{
		QualitySettings.SetQualityLevel(4);
		QualitySettings.vSyncCount = 0;
    }
	public void level (string name)
	{
		SceneManager.LoadScene (name);
	}
    public void Ultra()
    {
        QualitySettings.SetQualityLevel(5);
		QualitySettings.vSyncCount = 0;
    }
	public void no_vsync()
	{
		QualitySettings.vSyncCount = 0;
	}
	public void yes_vsync60()
	{
		QualitySettings.vSyncCount = 1;
	}
	public void yes_vsync30()
	{
		QualitySettings.vSyncCount = 2;
	}
    public void Resolution()
    {
        Screen.fullScreen = !Screen.fullScreen;
    }
	public void SDResolucion()
	{
		Screen.SetResolution(848, 480, true);
	}
	public void HDResolucion()
	{
		Screen.SetResolution(1280, 720, true);
	}
	public void novecientosP()
	{
		Screen.SetResolution(1600, 900, true);
	}
	public void FullHDResolucion()
	{
		Screen.SetResolution(1920, 1080, true);
	}
	public void milcuatroP()
	{
		Screen.SetResolution(2560, 1440, true);
	}
	public void dosmilP()
	{
		Screen.SetResolution(3840, 2160, true);
	}

}


