using UnityEngine;

public class MoveInOut : MonoBehaviour
{
    public Vector3 moveDirection = Vector3.forward;
    public float speed = 1;
    public float moveDistance = 3;

    bool finishedMoving;
    bool movingOut;
    Vector3 dir;
    float distanceTraveled;


    private void Start()
    {
        movingOut = false;
        finishedMoving = true;
        dir = moveDirection.normalized;
        distanceTraveled = 0;
    }

    private void FixedUpdate()
    {
        if (finishedMoving)
            return;

        transform.position += dir * speed * Time.deltaTime;
        distanceTraveled += movingOut ? speed * Time.deltaTime : -speed * Time.deltaTime;

        if(distanceTraveled >= moveDistance || distanceTraveled <= 0)
        {
            finishedMoving = true;
        }
    }

    public void MoveOut()
    {
        movingOut = true;
        finishedMoving = false;
        dir = moveDirection.normalized;
    }

    public void MoveIn()
    {
        movingOut = false;
        finishedMoving = false;
        dir = moveDirection.normalized * -1;
    }
}
