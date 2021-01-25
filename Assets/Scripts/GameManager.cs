using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] CarSpawner[] carSpawners; //Hiyerarsideki butun CarSpawner nesnelerini bir diziye atiyoruz.
    int carSpawnersIndex;
    [SerializeField] GameObject resumePlayingScreen;
    void Start()
    {
        StopGame();
    }

    void Update()
    {
       
    }

    public void FirstGameStart()
    {          
        Time.timeScale = 1f;
        carSpawners[carSpawnersIndex].SpawnCar();
    }

    public void StopGame()
    {
        Time.timeScale = 0f;
    }

    public void SpawnCarAndControlSpawnerIndex() 
    {
        carSpawners[carSpawnersIndex].SpawnCar();
        carSpawnersIndex++;
        if (carSpawnersIndex == 8)
        {
            //LoadNextScene();
        }
    }

    public void DisableCarController(GameObject gameObject) //gameObject'e ait olan CarController Scriptini deaktif eder
    {
        gameObject.GetComponent<CarController>().enabled = false;
    }

    public void AddNavMeshAgent() 
    {

    }

    public void ResetPositions(List<GameObject> gameObjects)
    {
        //gameObject.transform.position = CarMovement.startPosition;
        
        for (int i = 0; i < gameObjects.Count; i++)
        {
            //gameObjects[i].transform.position = carSpawners[i].transform.position;
            //gameObjects[i].transform.rotation = carSpawners[i].transform.rotation;
            gameObjects[i].transform.position = gameObjects[i].GetComponent<CarMovement>().GetStartPosition();
            gameObjects[i].transform.rotation = gameObjects[i].GetComponent<CarMovement>().GetStartRotation();
        }
        //carSpawnersIndex++;
    }

    public void ResetPositionsWhenCollide(List<GameObject> gameObjects)
    {
        for (int i = 0; i < gameObjects.Count; i++)
        {
            gameObjects[i].transform.position = gameObjects[i].GetComponent<CarMovement>().GetStartPosition();
            gameObjects[i].transform.rotation = gameObjects[i].GetComponent<CarMovement>().GetStartRotation();
        }
    }

    public void StartGameAgain()
    {
        Time.timeScale = 1f;
    }

    public void StopGameWithPanel()
    {
        resumePlayingScreen.SetActive(true);
        Time.timeScale = 0f;
    }

    public void ChangeCarTag(GameObject gameObject)
    {
        gameObject.tag = "UsedCar";
    }
}
