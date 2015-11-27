using UnityEngine;
using System.Collections;

public class LoadLevel : MonoBehaviour {

	public void LoadNewLevel (int level)
	{
		Application.LoadLevel (level);
	}
}
