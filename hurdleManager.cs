using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hurdleManager : MonoBehaviour
{
    public GameObject[] hurdles;
    public float hurdleTime;
    private Transform player;

    
    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        StartCoroutine(spawnHurdle());
    }
    
    // Update is called once per frame
    IEnumerator spawnHurdle()
    {
        yield return new WaitForSeconds(hurdleTime);
        spawn();
    }
    
    void spawn()
    {
        //int randomHurdle = UnityEngine.Random.Range(0, hurdles.Length-1);
        int randomHurdle = Random.Range(0, 11);
        float xpos = Random.Range(-1.2f, 1.2f);
        float zpos = Random.Range(20f, 28f);
        float ypos = 0.57f;
        if(randomHurdle == 0 || randomHurdle == 1)
        {
            //xpos = Random.Range(-1.2f, 1.2f);
            if (randomHurdle == 0) ypos = 0.77f;
            else ypos = 0.72f;
        }
        else if (randomHurdle == 3)
        {
            xpos = 0.08f;
            ypos = 0.21f;
            //zpos = -4.51f;
        }
        else if (randomHurdle == 4)
        {
            ypos = 0.056f;
        }
        else if (randomHurdle == 5)
        {
            ypos = 0.4f;
        }
        else if (randomHurdle == 6)
        {
            xpos = Random.Range(-0.14f, 1.87f);
            ypos = 0.03f;
        }
        else if (randomHurdle == 7)
        {
            ypos = 0.0569f;
        }
        else if (randomHurdle == 8)
        {
            xpos = -0.24f;
            ypos = 0.0569f;
        }
        else if (randomHurdle == 9)
        {
            xpos = Random.Range(-100f, 120f);
            ypos = 0.084f;
        }
        else if (randomHurdle == 10)
        {
            xpos = -0.01f;
            ypos = 0.013f;
        }


        Vector3 hposition = new Vector3(xpos, ypos, player.position.z + zpos);
        if (randomHurdle == 10)
        {
            Instantiate(hurdles[randomHurdle], hposition, hurdles[randomHurdle].transform.rotation);
            xpos = 1.253f;
            ypos = 0.013f;
            hposition = new Vector3(xpos, ypos, player.position.z + zpos);
            Instantiate(hurdles[randomHurdle], hposition, hurdles[randomHurdle].transform.rotation);
            xpos = -1.144f;
            ypos = 0.013f;
            hposition = new Vector3(xpos, ypos, player.position.z + zpos);
            Instantiate(hurdles[randomHurdle], hposition, hurdles[randomHurdle].transform.rotation);

        }
        else Instantiate(hurdles[randomHurdle], hposition, hurdles[randomHurdle].transform.rotation);
        //tree generating
        int abol = Random.Range(1, 10);
        int tabol = Random.Range(1, 10);
        if (abol * tabol < 100)
        {
            int random_number = Random.Range(11, 14);
            Vector3 hposition1;
            if (random_number == 11)
            {
                hposition1 = new Vector3(15.25f, -1.69f, player.position.z + 70f);
                Instantiate(hurdles[11], hposition1, hurdles[11].transform.rotation);
            }
			else if (random_number == 12)
            {
                hposition1 = new Vector3(21.2f, -1.39f, player.position.z + 70f);
                Instantiate(hurdles[12], hposition1, hurdles[12].transform.rotation);
            }
            else if (random_number == 13)
            {
                hposition1 = new Vector3(20.0f, -2.8f, player.position.z + 70f);
                Instantiate(hurdles[13], hposition1, hurdles[13].transform.rotation);
            }
            random_number = Random.Range(14, 17);
            if (random_number == 16)
            {
                hposition1 = new Vector3(-17.7f, -1.87f, player.position.z + 70f);
                Instantiate(hurdles[16], hposition1, hurdles[16].transform.rotation);
            }
            else if (random_number == 14)
            {
                hposition1 = new Vector3(-10.3f, 3.9f, player.position.z + 70f);
                Instantiate(hurdles[14], hposition1, hurdles[14].transform.rotation);
            }
            else if (random_number == 15)
            {
                hposition1 = new Vector3(-17.92f, -0.1f, player.position.z + 70f);
                Instantiate(hurdles[15], hposition1, hurdles[15].transform.rotation);
            }

        }


        StartCoroutine(spawnHurdle());
    }
}