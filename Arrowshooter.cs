using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrowshooter : MonoBehaviour
{

    private GameObject arrowPrefab;
    private Transform transform;
    // Use this for initialization
    void Start()
    {
        arrowPrefab = Resources.Load("arrow") as GameObject;
        transform = GameObject.FindGameObjectWithTag("Player").transform;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject newArrow = Instantiate(arrowPrefab) as GameObject;
            newArrow.transform.position = transform.position;
            Rigidbody rb = newArrow.GetComponent<Rigidbody>();
            rb.velocity = Camera.main.transform.forward * 30;
        }
    }
}