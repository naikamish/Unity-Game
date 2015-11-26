using UnityEngine;
using System.Collections;

public class LoadSceneOnClick: MonoBehaviour {
	public void LoadScene (int scene)
	{
		Application.LoadLevel (scene);
	}
}
