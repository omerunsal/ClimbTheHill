using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class SpeedScript : MonoBehaviour
{
    private bool isWorkedOnce;

    // Start is called before the first frame update
    void Start()
    {
        isWorkedOnce = false;
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Player") && isWorkedOnce == false)
        {
            isWorkedOnce = true;
            other.transform.GetComponent<PlayerController>().moveSpeed += 2.5f;
        }
    }
}