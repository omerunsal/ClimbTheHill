using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : CharacterController
{
    //Touch Control
    private Vector3 firstTouchPosition;
    private Vector3 lastTouchPosition;
    public bool isTouched;

    private Vector3 lastPos;

    public Transform back;

    public bool GamePaused;

    public float x = 0f;

    private void Start()
    {

        //handController.ChangeHandScale(1);
    }

    void Update()
    {
        InputType();

        if (!isTouched || direction == Vector3.zero || GamePaused == true)
        {
            return;
        }

        RotateToDirection();

        lastPos = transform.position;
    }

    private void FixedUpdate()
    {
        base.Movement();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Cube"))
        {
            //SetCharacterState(CharacterState.Push);
            AddToObstacle(other.gameObject);
            Destroy(other.gameObject);
        }

        if (other.transform.CompareTag("FirstTutorial"))
        {
            // Time.timeScale = 0f;
            // GamePaused = true;

            // StartCoroutine(ShowSecTutorial()); //tutorial göster ve button'a yönlerdir 1f yap

            // if (GamePaused == true)
            // {
            //     Time.timeScale = 1f;
            //     GamePaused = false;
            // }
            // else
            // {
            //     Time.timeScale = 0f;
            //     GamePaused = true;
            // }

            print("Tutorial");


            return;
        }
    }

    IEnumerator ShowSecTutorial()
    {
        yield return new WaitForSeconds(3f);
        if (GamePaused == true)
        {
            Time.timeScale = 1f;
            GamePaused = false;
        }
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.transform.CompareTag("Cube"))
    //    {
    //        //SetCharacterState(CharacterState.Push);
    //        AddToObstacle(collision.gameObject);
    //    }
    //}

    private void AddToObstacle(GameObject cube)
    {
        GameObject gO = Instantiate(cube,
            new Vector3(back.transform.position.x, back.transform.position.y + x, back.transform.position.z),
            transform.rotation);
        gO.transform.SetParent(back.transform);
        x += 0.025f;
    }

    //private void OnCollisionExit(Collision other)
    //{
    //    if (other.transform.CompareTag("Cube"))
    //    {
    //        SetCharacterState(CharacterState.Run);
    //        // other.transform.parent = null;
    //    }
    //}


    private void InputType()
    {
#if UNITY_EDITOR

        if (!Input.GetMouseButton(0) && !Input.GetMouseButtonUp(0))
        {
            isTouched = false;
        }
        else
        {
            isTouched = true;

            if (Input.GetMouseButtonDown(0))
            {
                firstTouchPosition = Input.mousePosition;
            }
            else if (Input.GetMouseButtonUp(0))
            {
                direction = Vector3.zero;
                lastTouchPosition = Input.mousePosition;
            }
            else
            {
                Vector3 screenDirection = Input.mousePosition - firstTouchPosition;
                direction = new Vector3(screenDirection.x, 0, screenDirection.y);
                direction.Normalize();
            }
        }

#else
        if (Input.touchCount > 0)
        {
            isTouched = true;
            var inputTouch = Input.GetTouch(0);

            if (inputTouch.phase == TouchPhase.Began)
            {
                firstTouchPosition = inputTouch.position;
            }
            else if (inputTouch.phase == TouchPhase.Moved || inputTouch.phase == TouchPhase.Stationary)
            {
                Vector3 screenDirection = (Vector3)inputTouch.position - firstTouchPosition;
                direction = new Vector3(screenDirection.x, 0, screenDirection.y);
                direction.Normalize();
            }
            else
            {
                direction = Vector3.zero;
                lastTouchPosition = inputTouch.position;
            }
        }
        else
        {
            isTouched = false;
        }

#endif
    }
}