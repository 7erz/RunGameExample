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
        //WaitforSecond�� Dictionary�� ����

        //CourutineCache.WaitForSecond(������)
        while (GameManager.instance.state)
        {
            for(int i = 0; i<Random.Range(1,3); i++)
            {

                carRand = Random.Range(0, vehicleObj.Length);
                //���� ���� ������Ʈ�� Ȱ��ȭ �Ǿ� �ִ��� Ȯ��
                while (vehicleList[carRand].activeSelf)
                {
                    //����Ʈ�� �ִ� ��� ������Ʈ�� Ȱ��ȭ �Ǿ��ִ��� Ȯ��
                    if(isVehicleFull())
                    {
                        //��� ���� ������Ʈ�� Ȱ��ȭ�Ǿ� �ִٸ� ���� ������Ʈ�� ���� ������ ����
                        //vehicle�� ����Ʈ�� �־���
                        GameObject vehicle = Instantiate(vehicleObj[Random.Range(0, vehicleObj.Length)]);

                        vehicle.SetActive(false);

                        vehicleList.Add(vehicle);

                    }
                    //���� ����Ʈ�� �ִ� ��� ���� ������Ʈ�� Ȱ��ȭ�Ǿ� ���� �ʴٸ� Random ���� ���� +1 �ؼ� �ٽ� �˻� ��
                    carRand = (carRand + 1) % vehicleList.Count;
                }
                roadRand = Random.Range(0, spawnTransform.Length);
                //���� ����� ������ �ٽ� ���� roadRand���� compareRoad�� ���ٸ� �ߺ����� �ʵ��� ���
                if (compareRoad == roadRand)
                {
                    roadRand = (roadRand + 1) % spawnTransform.Length;
                }
                //compareRoad �� roadRand �� ������ ������ ���� �־���
                compareRoad = roadRand;

                vehicleList[carRand].transform.position = spawnTransform[roadRand].transform.position;
                vehicleList[carRand].SetActive(true);
            }


            yield return CoroutineCache.waitForSeconds(spawnRate);
        }
    }
}

//������Ʈ Ȱ��ȭ ��ġ ����
