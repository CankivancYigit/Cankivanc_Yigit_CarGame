using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StopGame();
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetMouseButtonDown(0))
        {
            StartGame();
        }
        */
    }

    public void StartGame()
    {          
            Time.timeScale = 1f;         
    }

    private void StopGame()
    {
        Time.timeScale = 0f;
    }
}
