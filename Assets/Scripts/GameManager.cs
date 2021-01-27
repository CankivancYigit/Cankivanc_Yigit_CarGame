using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] CarSpawner[] carSpawners; //Hiyerarsideki butun CarSpawner nesnelerini bir diziye atiyoruz.
    [SerializeField] GameObject[] finishLines; //Hiyerarsideki butun Finish nesnelerini bir diziye atiyoruz.
    int carSpawnersIndex;
    int finishLineIndex;
    [SerializeField] GameObject resumePlayingScreen;
    void Start()
    {
        StopGame();
    }

    void Update()
    {
       
    }

    public void FirstGameStart() //Level ilk acildiginda ekrana tiklama ile calisir
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
        //carSpawnersIndex++;
        if (carSpawnersIndex == 8)
        {
            //LoadNextScene();
        }
    }

    public void FinishLineSwitch()
    {
        finishLines[finishLineIndex].SetActive(false);
        finishLineIndex++;
        finishLines[finishLineIndex].SetActive(true);
    }

    public void DisableCarController(GameObject gameObject) //gameObject'e ait olan CarController Scriptini deaktif eder
    {
        gameObject.GetComponent<CarController>().enabled = false;
    }

    public void DisableCarMovement(GameObject gameObject) //gameObject'e ait olan CarMovement Scriptini deaktif eder
    {
        gameObject.GetComponent<CarMovement>().enabled = false;
    }

    public void DeleteCollisionHandler(GameObject gameObject) //gameObject'e ait olan CollisionHandler Scriptini siler
    {
        Destroy(gameObject.GetComponent<CollisionHandler>());
    }

    public void DeleteWaypointSpawner(GameObject gameObject) //gameObject'e ait olan WaypointSpawner Scriptini siler
    {
        Destroy(gameObject.GetComponent<WaypointSpawner>());
    }

    public void ResetPositions(List<GameObject> gameObjects)
    {   
        for (int i = 0; i < gameObjects.Count; i++)
        {
            gameObjects[i].transform.position = gameObjects[i].GetComponent<CarMovement>().GetStartPosition();
            gameObjects[i].transform.rotation = gameObjects[i].GetComponent<CarMovement>().GetStartRotation();
        }
        carSpawnersIndex++;
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

    public void ChangeRigidBodyToStatic(GameObject gameObject)
    {
        gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
    }

    public void EnableCarsPathFollowing(List<GameObject> gameObjects)
    {
        for (int i = 0; i < gameObjects.Count; i++)
        {
            gameObjects[i].GetComponent<WaypointsCollector>().IsFollowing = true;
        }
    }
}
