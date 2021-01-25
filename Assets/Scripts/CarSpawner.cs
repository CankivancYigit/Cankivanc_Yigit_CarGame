using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    [SerializeField] GameObject car;
  
    public void SpawnCar()
    {
        GameObject newCar = Instantiate(car, transform.position, transform.rotation);
        newCar.gameObject.tag = "PlayerCar";
    }
}
