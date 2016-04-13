using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SwitchScene : MonoBehaviour {

	public void ChangeToScene (string sceneToChangeTo){
		SceneManager.LoadScene (sceneToChangeTo);
	}
}