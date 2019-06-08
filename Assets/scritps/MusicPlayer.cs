using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicPlayer : MonoBehaviour {
	private void Awake()
	{
		DontDestroyOnLoad(gameObject);
	}

	// Use this for initialization
	void Start () {
		Invoke("LoadGamePlayScene",5f);
	}
	
	private void LoadGamePlayScene()
	{
		SceneManager.LoadScene(1);
	}
}
