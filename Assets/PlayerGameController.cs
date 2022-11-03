using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlayerGameController : MonoBehaviour
{
    public ParticleSystem bloodyAnimation;

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
        if (collision.transform.CompareTag("Car") || collision.transform.CompareTag("Razor"))
        {
            Instantiate(bloodyAnimation, transform.position, quaternion.identity);
            gameObject.SetActive(false);

            GameManager.instance.LevelFail();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("FinishGround"))
        {
            GameManager.instance.LevelComplete();

            SetPlayerMovementZero();
        }
    }


    void SetPlayerMovementZero()
    {
        GetComponent<PlayerController>().direction = Vector3.zero;
        GetComponent<PlayerController>().moveSpeed = 0f;
        GetComponent<PlayerController>().moveSpeed = 0f;
        GetComponent<PlayerController>().GamePaused = true;
        GetComponent<PlayerController>().SetCharacterState(CharacterState.Dance);
    }
}