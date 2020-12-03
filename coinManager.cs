using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinManager : MonoBehaviour
{
    public GameObject[] coins;
    public float coinTime;
    private Transform player;
 
    // Use this for initialization
    void Start()
    {
       player = GameObject.FindGameObjectWithTag("Player").transform;
       StartCoroutine(spawnCoin());
    }
    void OnTriggerEnter(Collider other)
    {
        //player = GameObject.FindGameObjectWithTag("Player").transform;
        if (other.CompareTag("Player"))
        {
           
            StartCoroutine(spawnCoin());
        }
    }

    // Update is called once per frame
    IEnumerator spawnCoin()
    {
        yield return new WaitForSeconds(coinTime);
        Spawn();
    }

    void Spawn()
    {
        //int randomCoin = UnityEngine.Random.Range(0, coins.Length - 1);
		int randomCoin = Random.Range(0, 3);
        float xpos = Random.Range(-1.2f, 1.2f);
        float zpos = Random.Range(22f, 25f);
		float ypos;
		if (randomCoin == 0)
			ypos = 0.5f;
		else if (randomCoin == 1)
			ypos = 1.5f;
		else {
			ypos = 0.165f;
			xpos = Random.Range(-2.26f, -0.05f);
		}
		Vector3 hposition = new Vector3(xpos, ypos, player.position.z + zpos);
		int i;
		if(randomCoin==0) i = 15;
		else i = 1;
        float z = player.position.z + zpos;
        while (i > 0)
        {
            Instantiate(coins[randomCoin], hposition, coins[randomCoin].transform.rotation);
            i--;
            z = z + 0.8f;
            hposition = new Vector3(xpos, 0.5f, z);
        }
        //yield return new WaitForSeconds(coinTime);
        //Spawn();
        StartCoroutine(spawnCoin());
    }
}