using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class Escalar : MonoBehaviour {

	// Use this for initialization
	/*void Start () {
		Screen.SetResolution(960, 540, false);
	}*/
	public void SetQuality (int Level){
		QualitySettings.SetQualityLevel(Level);
	}
	public void Quit(){
        #if UNITY_EDITOR 
        EditorApplication.isPlaying = false;
        #else
        Application.Quit();
		#endif
		}
	public void scene(string name){ 
		SceneManager.LoadScene (name);
		}
	public void vsyncoff(){
		QualitySettings.vSyncCount = 0;
	}
	//Vsync 60 fps
	public void vsync60(){
		QualitySettings.vSyncCount = 1;
	}
	//Vsync 30 fps
	public void vsync30(){
		QualitySettings.vSyncCount = 2;
	}
}
