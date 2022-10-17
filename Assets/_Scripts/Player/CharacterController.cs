using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{




    [Header("Movement")][SerializeField] private float moveSpeed;
    [SerializeField] private float rotateSpeed;

    [Header("Limits")][SerializeField] protected Vector2 xLimits;
    [SerializeField] protected Vector2 zLimits;

    public Vector3 direction;
    private Rigidbody rigidbody;

    private PlayArea playArea;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
        playArea = GameObject.FindGameObjectWithTag("PlayArea").GetComponent<PlayArea>();
    }


    protected void GetLimits()
    {
        xLimits = playArea.playLimit.xLimits;
        zLimits = playArea.playLimit.zLimits;
    }


    protected virtual void Movement()
    {
        //Move Transform
        // Vector3 pos = Vector3.MoveTowards(transform.position, transform.position + direction,
        //     Time.deltaTime * moveSpeed);
        // pos = LimitPosition(pos);
        // transform.position = pos;

        //Move Physics
        rigidbody.MovePosition(transform.position + direction * Time.fixedDeltaTime * moveSpeed);
    }

    protected void RotateToDirection()
    {
        if (direction != Vector3.zero)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(direction), rotateSpeed * Time.deltaTime);
        }
    }

    private Vector3 LimitPosition(Vector3 pos)
    {
        float x = Mathf.Clamp(pos.x, xLimits.x, xLimits.y);
        float z = Mathf.Clamp(pos.z, zLimits.x, zLimits.y);

        Vector3 limitedPos = new Vector3(x, pos.y, z);
        return limitedPos;
    }



    IEnumerator SpeedCooldown()
    {
        float speed = moveSpeed;
        moveSpeed = 0f;
        while (moveSpeed != speed)
        {
            moveSpeed += Time.deltaTime;
            if (moveSpeed >= speed)
                moveSpeed = speed;

            yield return new WaitForEndOfFrame();
        }
    }


}