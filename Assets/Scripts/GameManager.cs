using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] CarSpawner[] carSpawners; //Hiyerarsideki butun CarSpawner nesnelerini bir diziye atiyoruz.
    int carSpawnersIndex;
    
    void Start()
    {
        StopGame();
    }

    void Update()
    {
       
    }

    public void StartGame()
    {          
        Time.timeScale = 1f;
        //FindObjectOfType<CarSpawner>().SpawnCar();
    }

    private void StopGame()
    {
        Time.timeScale = 0f;
    }

    public void IncreaseCarSpawnersIndex() 
    {
        carSpawners[carSpawnersIndex].SpawnCar();
        carSpawnersIndex++;
        if (carSpawnersIndex == 7)
        {
            //LoadNextScene();
        }
    }

    public void DisableCarMovement(GameObject gameObject) //gameObject'e ait olan CarMovement Scriptini deaktif eder
    {
        gameObject.GetComponent<CarMovement>().enabled = false;
    }
}
