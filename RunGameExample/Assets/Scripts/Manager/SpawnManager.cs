using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] Transform[] spawnTransform;
    [SerializeField] GameObject[] vehicleObj;
    [SerializeField] List<GameObject> vehicleList;


    [SerializeField] int count, carRand, roadRand;


    private void Start()
    {
        vehicleList.Capacity = 20;
        //Create();
        MakeVehicle();
        StartCoroutine(ActivateVehicle());
    }

    private void Update()
    {
        
    }

    public void Create()
    {
        for(int i = 0; i < vehicleObj.Length; i++)
        {
            GameObject vehicle = Instantiate(vehicleObj[i]);
            vehicle.SetActive(false);

            vehicleList.Add(vehicle);
        }
    }

    public void MakeVehicle()
    {
        foreach (GameObject vehiclePrefab in vehicleObj)
        {
            GameObject vehicle = Instantiate(vehiclePrefab);
            vehicle.SetActive(false);

            vehicleList.Add(vehicle);
            
        }
    }

    IEnumerator ActivateVehicle()
    {
        //WaitforSecond를 Dictionary에 저장

        //CourutineCache.WaitForSecond(변수값)
        while (true)
        {
            carRand = Random.Range(0,vehicleObj.Length);
            while (vehicleList[carRand].activeSelf)
            {
                count++;
                if(count >= vehicleObj.Length)
                {
                    Debug.Log("탈출");
                    yield break;
                }
                carRand = (carRand + 1) % vehicleObj.Length;
            }

            vehicleList[carRand].SetActive(true);
            roadRand = Random.Range(0, spawnTransform.Length);
            vehicleList[carRand].transform.position = spawnTransform[roadRand].transform.position;

            yield return new WaitForSeconds(3f);
        }
    }
}
