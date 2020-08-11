using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class Escalar : MonoBehaviour {
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
	public void Vsync(int Vsync){
		QualitySettings.vSyncCount = Vsync;}

	public void SDResolucion(int W){
		Screen.SetResolution(W, 480, true);}	
}
