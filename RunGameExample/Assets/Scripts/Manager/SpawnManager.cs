using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] Transform[] spawnTransform;
    [SerializeField] GameObject[] vehicleObj;
    [SerializeField] List<GameObject> vehicleList;


    [SerializeField] int count, carRand, roadRand;
    [SerializeField] int compareRoad = -1;


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
            for(int i = 0; i<Random.Range(1,3); i++)
            {
                if (vehicleList.Count >= vehicleList.Capacity)
                {
                    Debug.LogWarning("List is about to reach capacity. Stopping the coroutine.");
                    yield break;  // Capacity 초과 시 코루틴 종료
                }
                carRand = Random.Range(0, vehicleObj.Length);
                while (vehicleList[carRand].activeSelf)
                {
                    
                    carRand = (carRand + 1) % vehicleObj.Length;
                }
                roadRand = Random.Range(0, spawnTransform.Length);
                //이전 저장된 변수와 다시 뽑은 roadRand값이 compareRoad와 같다면 중복되지 않도록 계산
                if (compareRoad == roadRand)
                {
                    roadRand = (roadRand + 1) % spawnTransform.Length;
                }
                //compareRoad 와 roadRand 로 설정된 변수의 값을 넣어줌
                compareRoad = roadRand;

                vehicleList[carRand].transform.position = spawnTransform[roadRand].transform.position;
                vehicleList[carRand].SetActive(true);
            }


            yield return new WaitForSeconds(3f);
        }
    }
}

//오브젝트 활성화 위치 조정
