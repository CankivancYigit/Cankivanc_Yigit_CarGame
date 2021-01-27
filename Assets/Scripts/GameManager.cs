using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] CarSpawner[] carSpawners; //Hiyerarsideki butun CarSpawner nesnelerini bir diziye atiyoruz.
    [SerializeField] GameObject[] finishLines; //Hiyerarsideki butun Finish nesnelerini bir diziye atiyoruz.
    List<GameObject> carList;
    int carSpawnersIndex;
    int finishLineIndex;
    [SerializeField] GameObject resumePlayingScreen;
    LevelLoader levelLoader;

    public List<GameObject> CarList { get => carList; set => carList = value; }

    void Start()
    {
        StopGame();
        levelLoader = FindObjectOfType<LevelLoader>();
        CarList = new List<GameObject>();
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

    public void SpawnCar() 
    {
        if (carSpawnersIndex == 8)
        {
            carSpawnersIndex = 0;
        }
        carSpawners[carSpawnersIndex].SpawnCar();
        //carSpawnersIndex++;
    }

    public void FinishLineSwitch()
    {
        if (finishLineIndex == 7)
        {
            levelLoader.LoadNextScene();
            finishLineIndex = 0;
        }
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
        foreach (var item in gameObjects)
        {
            item.GetComponent<WaypointsFollower>().moveSpeed = 2f;
        }
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
            gameObjects[i].GetComponent<WaypointsFollower>().IsFollowing = true;
        }
    }
}
