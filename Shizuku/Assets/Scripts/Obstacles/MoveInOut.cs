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
    Vector3 startPosition;


    private void Start()
    {
        movingOut = false;
        finishedMoving = true;
        dir = moveDirection.normalized;
        distanceTraveled = 0;
        startPosition = transform.position;
    }

    private void FixedUpdate()
    {
        if (finishedMoving)
            return;

        distanceTraveled += movingOut ? speed * Time.deltaTime : -speed * Time.deltaTime;

        if(distanceTraveled >= moveDistance)
        {
            distanceTraveled = moveDistance;
            finishedMoving = true;
        }
        else if(distanceTraveled <= 0)
        {
            distanceTraveled = 0;
            finishedMoving = true;
        }

        transform.position = startPosition + dir * distanceTraveled;
        print(transform.position);
    }

    public void MoveOut()
    {
        movingOut = true;
        finishedMoving = false;
    }

    public void MoveIn()
    {
        movingOut = false;
        finishedMoving = false;
    }
}
