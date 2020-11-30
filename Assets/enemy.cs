using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public float speed = 10f;
    public float turnSmoothTime = 0.1f;

    private Transform target;
    private int wavepointIndex = 0;
    private float turnSmoothVelocity;
    private void Start()
    {
        target = wayPoints.points[0];
    }

    private void Update()
    {
        Vector3 dir = target.position - transform.position;
        float targetAngle = Mathf.Atan2(dir.x, dir.z) *Mathf.Rad2Deg;
        float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
        transform.rotation = Quaternion.Euler(0f, angle, 0f);
        transform.Translate(dir.normalized * speed * Time.deltaTime,Space.World);

        if(Vector3.Distance(transform.position,target.position)<=0.2f)
        {
            getNextWaypoint();
        }
    }

    void getNextWaypoint()
    {
        if(wavepointIndex >= wayPoints.points.Length-1)
        {
            Destroy(gameObject);
            return;
        }
        wavepointIndex++;
        target = wayPoints.points[wavepointIndex];
    }
}
