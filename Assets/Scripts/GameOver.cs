using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{

    public string objectTag; // the tag to search for
    GameController gameController;
    public GameObject gameOverUI;

    void Update()
    {

        bool allInactive = true;

        // find all objects with the specified tag
        GameObject[] objects = GameObject.FindGameObjectsWithTag(objectTag);

        // check if any objects are still active
        foreach (GameObject obj in objects)
        {
            if (obj.activeSelf)
            {
                allInactive = false;
                break;
            }
        }

        // if all objects are inactive, trigger the game over sequence
        if (allInactive)
        {
           
            gameOverUI.SetActive(true);
            Debug.Log("All done");
        }
    }
}
