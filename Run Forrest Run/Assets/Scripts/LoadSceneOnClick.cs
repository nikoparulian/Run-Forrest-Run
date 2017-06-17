using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;



public class LoadSceneOnClick : MonoBehaviour {
	

	public void LoadByIndex(string newLevel)
	{
		SceneManager.LoadScene(newLevel); 
	}
}
