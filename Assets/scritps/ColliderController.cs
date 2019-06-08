using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ColliderController : MonoBehaviour
{
    [Tooltip("In seconds")] [SerializeField]
    private float levelLoadDelay = 1f;

    [Tooltip("FX Prefab on player")] [SerializeField]
    GameObject deathFX;

    private void OnTriggerEnter(Collider collider)
    {
        StartDeathSequence();
    }

    private void StartDeathSequence()
    {
        //deathFX.SetActive(true);
        //SendMessage("OnPlayerDeath");
        //Invoke("loadFirstLevel",levelLoadDelay);
    }

    private void loadFirstLevel()
    {
        SceneManager.LoadScene(1);
    }
}