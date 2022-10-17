using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGameController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }


    private void OnCollisionEnter(Collision collision)
    {
        print(collision.transform.tag);
        if (collision.transform.CompareTag("Car"))
        {
            GameManager.instance.LevelFail();
        }else if (collision.transform.CompareTag("FinishGround"))
        {
            GameManager.instance.LevelComplete();
        }
    }
}