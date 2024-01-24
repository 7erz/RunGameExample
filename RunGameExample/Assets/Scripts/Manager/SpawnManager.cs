using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] Transform[] spawnTransform;
    [SerializeField] GameObject[] vehicleObj;
    [SerializeField] List<GameObject> vehicleList;


    [SerializeField] int count, carRand, roadRand;
    [SerializeField] int compareRoad = -1;
    [SerializeField] float spawnRate;
    


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

    public bool isVehicleFull()
    {
        for(int i = 0;i < vehicleList.Count;i++)
        {
            if (vehicleList[i].activeSelf == false)
            {
                return false;
            }   
        }
        return true;
    }

    IEnumerator ActivateVehicle()
    {
        //WaitforSecond를 Dictionary에 저장

        //CourutineCache.WaitForSecond(변수값)
        while (GameManager.instance.state)
        {
            for(int i = 0; i<Random.Range(1,3); i++)
            {

                carRand = Random.Range(0, vehicleObj.Length);
                //현재 게임 오브젝트가 활성화 되어 있는지 확인
                while (vehicleList[carRand].activeSelf)
                {
                    //리스트에 있는 모든 오브젝트가 활성화 되어있는지 확인
                    if(isVehicleFull())
                    {
                        //모든 게임 오브젝트가 활성화되어 있다면 게임 오브젝트를 새로 생성한 다음
                        //vehicle을 리스트에 넣어줌
                        GameObject vehicle = Instantiate(vehicleObj[Random.Range(0, vehicleObj.Length)]);

                        vehicle.SetActive(false);

                        vehicleList.Add(vehicle);

                    }
                    //현재 리스트에 있는 모든 게임 오브젝트가 활성화되어 있지 않다면 Random 변수 값을 +1 해서 다시 검색 함
                    carRand = (carRand + 1) % vehicleList.Count;
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


            yield return CoroutineCache.waitForSeconds(spawnRate);
        }
    }
}

//오브젝트 활성화 위치 조정
