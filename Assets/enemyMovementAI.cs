 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMovementAI : MonoBehaviour
{

    public Transform[] waypoint;
    public float patrolSpeed = 3f;
    public bool loop = true;
    public float dampingLook = 6.0f;
    public float pauseDuration = 0;

    public float curTime;
    public int currenWaypoint = 0;
    public CharacterController controller;

    
    void Start()
    {
        controller = GetComponent<CharacterController>();    
    }

    // Update is called once per frame
    void Update()
    {
        if (currenWaypoint < waypoint.Length)
        {
            patrol();
            
        } else
        {
            if (loop)
            {
                currenWaypoint = 0;
            }
        }
    }

    void patrol()
    {
        Vector3 target = waypoint[currenWaypoint].position;
        target.y = transform.position.y;
        Vector3 moveDirection = target - transform.position;
        //Debug.Log(moveDirection.magnitude);
        if (moveDirection.magnitude > 0.5f)
        {
            Quaternion rotation = Quaternion.LookRotation(target - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * dampingLook);
            Debug.Log("working");
            controller.Move(moveDirection.normalized * patrolSpeed * Time.deltaTime);

        }
        else
        {

            if (curTime == 0)
            {

                curTime = Time.time;
            }
            if ((Time.time - curTime) >= pauseDuration)
            {
                currenWaypoint++;
                curTime = 0;
            }
            Debug.Log(moveDirection.magnitude);

        }
    }
}
