using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class RoadManager : MonoBehaviour
{
    public List<GameObject> roadList;
    public float lerpSpeed;
    GameObject newRoad;


    private void Start()
    {
        //roadList = new List<GameObject>();
        roadList.Capacity = 10;
        newRoad = roadList[0];
    }

    private void Update()
    {
        Debugging();
        MoveRoadForeach();    //나의 답
        //MoveRoadFor();
    }

    void MoveRoadForeach()
    {
        foreach(GameObject gameobj in roadList)
        {
            //나의 답
            /*float targetZ = gameobj.transform.position.z - 25f;
            Vector3 targetPosition = new Vector3(gameobj.transform.position.x, gameobj.transform.position.y, targetZ);

            gameobj.transform.position = Vector3.Lerp(gameobj.transform.position, targetPosition, lerpSpeed * Time.deltaTime);*/
            gameobj.transform.Translate(Vector3.back * lerpSpeed * Time.deltaTime);
        }
        
    }

    void MoveRoadFor()
    {
        for(int i = 0; i < roadList.Count; i++)
        {
            roadList[i].transform.Translate(Vector3.back * lerpSpeed * Time.deltaTime);
        }
    }

    public void NewRoad()
    {
        roadList.RemoveAt(0);
        roadList.Add(newRoad);
        newRoad.transform.position = new Vector3(0, 0, 72);
        newRoad = roadList[0];
    }



    void Debugging()
    {
        Debug.Log(roadList);
    }
}
