using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadGenerator : MonoBehaviour {
    private float spawnz = -6f;
    private float wavez = 100f;

    public GameObject[] prefabs;

    private float RoadLength = 7.6f;
    private float waveLength = 110f;

    private int amountofRoads = 10;
    private int amountofwave = 3;

    private int lastIndex = 0;
    int i = 0;
    int randomIndex;

    private List<GameObject> roadsList;
    private Transform playertransform;

	// Use this for initialization

	void Start () {
        roadsList = new List<GameObject>();
        playertransform = GameObject.FindGameObjectWithTag("Player").transform;
        SpawnWave();
        for (int i = 0; i < amountofRoads; ++i)
        {
            if (i < 10)
                SpawnRoad(0);
            else
                SpawnRoad();
        }
	}
    // Update is called once per frame
    void Update () {
        if (playertransform.position.z-10f > (spawnz - amountofRoads * RoadLength))
        {
            
            SpawnRoad();
            DeleteRoad();
        }
        if (playertransform.position.z > (wavez - amountofwave * waveLength))
        {

            SpawnWave();
            //DeleteWave();
        }
    }
    void SpawnWave()
    {
        GameObject go;
        //go = Instantiate(prefabs[4]) as GameObject;
        //go.transform.SetParent(transform);
        //go.transform.position = Vector3.forward * (wavez - waveLength);
        //wavez += waveLength;
        //roadsList.Add(go);
        float xpos = 0.03f;
        float zpos = 100;
        Vector3 hposition = new Vector3(xpos, -1.9f, playertransform.position.z + zpos);

        Instantiate(prefabs[7], hposition, prefabs[7].transform.rotation);
        //roadsList.Add(go);
    }
    void DeleteWave()
    {
        //Destroy(roadsList[0]);
        //roadsList.RemoveAt(0);
    }
    void SpawnRoad(int prefabIndex = -1)
    {
        GameObject go;
        if (prefabIndex == -1)
        {
            int num = RandomPrefabIndex();
            if (num!=4) go = Instantiate(prefabs[num]) as GameObject;
            else
            {
                go = Instantiate(prefabs[num]) as GameObject;
            }
        }
        else
            go = Instantiate(prefabs[prefabIndex]) as GameObject;
        go.transform.SetParent(transform);
        go.transform.position = Vector3.forward * (spawnz-7.6f);
        spawnz += RoadLength;
        roadsList.Add(go);
    }
    void DeleteRoad()
    {
        Destroy(roadsList[0]);
        roadsList.RemoveAt(0);
    }
    private int RandomPrefabIndex()
    {
        if (prefabs.Length <= 1) return 0;
        if(i==0)
        {
            randomIndex = Random.Range(0, prefabs.Length-2);
            i++;
            lastIndex = randomIndex;
            return randomIndex;
        }
        else if (lastIndex == 6 && i > 1)
        {
            i = 0;
            return lastIndex;
        }
        else if (lastIndex == 6 && i <= 1)
        {
            i++;
            return lastIndex;
        }
        else if (lastIndex == 5 && i > 2)
        {
            i = 0;
            return lastIndex;
        }
        else if (lastIndex == 5 && i <= 2)
        {
            i++;
            return lastIndex;
        }
        else if(lastIndex==4 && i > 2)
        {
            i = 0;
            return lastIndex;
        }
        else if (lastIndex == 4 && i <= 2)
        {
            i++;
            return lastIndex;
        }
      
        else if (i>2 && lastIndex==3)
        {
            i = 0;
            return lastIndex;
        }
        else if(i<=3 && lastIndex!=2)
        {
            i++;
            return lastIndex;
        }
        else if(i>3 && lastIndex!=2)
        {
            i=0;
            return lastIndex;
        }
        else if(i<=3 && lastIndex == 2)
        {
            i++;
            return lastIndex;
        }
        else
        {
            i = 0;
            return lastIndex;
        }
    }
}
