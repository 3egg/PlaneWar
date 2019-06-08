using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicPlayer : MonoBehaviour
{
    private void Awake()
    {
        int length = FindObjectsOfType<MusicPlayer>().Length;
        if (length > 1)
        {
            DestroyObject(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    // Use this for initialization
    void Start()
    {
        Invoke("LoadGamePlayScene", 5f);
    }

    private void LoadGamePlayScene()
    {
        SceneManager.LoadScene(1);
    }
}