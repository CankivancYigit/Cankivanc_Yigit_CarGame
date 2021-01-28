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

    public void DisableCarController(GameObject car) //car'a ait olan CarController Scriptini deaktif eder
    {
        car.GetComponent<CarController>().enabled = false;
    }

    public void DisableCarMovement(GameObject car) //car'a ait olan CarMovement Scriptini deaktif eder
    {
        car.GetComponent<CarMovement>().enabled = false;
    }

    public void DeleteCollisionHandler(GameObject car) //car'a ait olan CollisionHandler Scriptini siler
    {
        Destroy(car.GetComponent<CollisionHandler>());
    }

    public void DeleteWaypointSpawner(GameObject car) //car'a ait olan WaypointSpawner Scriptini siler
    {
        Destroy(car.GetComponent<WaypointSpawner>());
    }

    public void ResetPositions(List<GameObject> carList) //finish cizgisi gecilir ise butun aralabaların pozisyonlarinin resetlenmesini saglar
    {
        foreach (var car in carList)
        {
            car.GetComponent<WaypointsFollower>().WaypointIndex = 0;
            car.GetComponent<WaypointsFollower>().moveSpeed = 2f;
        }
        for (int i = 0; i < carList.Count; i++)
        {
            carList[i].transform.position = carList[i].GetComponent<CarMovement>().GetStartPosition();
            carList[i].transform.rotation = carList[i].GetComponent<CarMovement>().GetStartRotation();
        }
        carSpawnersIndex++;    //CollisionHandler da ResetPositions SpawnCar dan once cagirildigi icin carSpawnersIndex i burada arttırdım
    }

    public void ResetPositionsWhenCollide(List<GameObject> carList) //
    {
        foreach (var car in carList)
        {
            car.GetComponent<WaypointsFollower>().WaypointIndex = 0;
            car.GetComponent<WaypointsFollower>().moveSpeed = 2f;
        }
        for (int i = 0; i < carList.Count; i++)
        {
            carList[i].transform.position = carList[i].GetComponent<CarMovement>().GetStartPosition();
            carList[i].transform.rotation = carList[i].GetComponent<CarMovement>().GetStartRotation();
        }
    }

    public void StartGameAgain()
    {
        Time.timeScale = 1f;
    }

    public void StopGameWithPanel()  //Araba finish cizgisine deger ise ya da bir yere carpar ise ekran panelini aktif edip oyunu durdurur
    {
        resumePlayingScreen.SetActive(true);
        Time.timeScale = 0f;
    }

    public void ChangeCarTag(GameObject car)
    {
        car.tag = "UsedCar";
    }

    public void ChangeRigidBodyToStatic(GameObject car) //araba finish cizgisini gecince Waypointleri takip edebilmesi icin rigidbody2d sini static yapar
    {
        car.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
    }

    public void EnableCarsPathFollowing(List<GameObject> carList) //Listeye eklenen arabaların eklenen Waypointleri takip edebilmeleri 
    {                                                             //icin WaypointsFollowerlarindaki isFollowing i true yapar
        for (int i = 0; i < carList.Count; i++)
        {
            carList[i].GetComponent<WaypointsFollower>().IsFollowing = true;
        }
    }
}
