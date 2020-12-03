using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Birdflying : MonoBehaviour
{
    public GameObject[] hurdles;
    public float hurdleTime;
    private Transform player;
    public float Bullet_Forward_Force = 1000.0f;

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
        GameObject Temporary_Bullet_Handler;
        int randomHurdle = Random.Range(0, 11);
        float xpos = Random.Range(-1.2f, 1.2f);
        float zpos = Random.Range(15f, 20f);
        float ypos = 2.88f;
        

        int abol = Random.Range(1, 10);
        int tabol = Random.Range(1, 10);
        if (abol * tabol < 10)
        {
            //1
            Vector3 hposition = new Vector3(xpos, ypos, player.position.z + zpos);
            Temporary_Bullet_Handler = Instantiate(hurdles[0], hposition, hurdles[0].transform.rotation);
            //2
            hposition = new Vector3(xpos+1f, ypos, player.position.z + zpos);
            Temporary_Bullet_Handler = Instantiate(hurdles[1], hposition, hurdles[1].transform.rotation);
            //3
            hposition = new Vector3(xpos + 1, ypos-1f, player.position.z + zpos);
            Temporary_Bullet_Handler = Instantiate(hurdles[2], hposition, hurdles[2].transform.rotation);
            //4
            hposition = new Vector3(xpos - 1, ypos-1f, player.position.z + zpos);
            Temporary_Bullet_Handler = Instantiate(hurdles[3], hposition, hurdles[3].transform.rotation);
            Rigidbody Temporary_RigidBody;
            Temporary_RigidBody = Temporary_Bullet_Handler.GetComponent<Rigidbody>();
            Temporary_RigidBody.AddForce(transform.forward * Bullet_Forward_Force);
        }


        StartCoroutine(spawnHurdle());
    }
}