using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class m10Gun : MonoBehaviour
{
    private Transform target;
    public float range = 15f;
    public string enemyTag = "Enemy";
    public float turnspeed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("updateTarget", 0f, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null) return;


        Vector3 dir = target.position - transform.position;
        Quaternion look = Quaternion.LookRotation(dir);
        Vector3 rotation =Quaternion.Lerp(transform.rotation,look,Time.deltaTime *turnspeed).eulerAngles;
        transform.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }

    void updateTarget()
    {
        
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestdestination = Mathf.Infinity;
        GameObject nearestEnemy = null;
        foreach (GameObject enemy in enemies)
        {
            float distance = Vector3.Distance(transform.position, enemy.transform.position);
            if (distance < shortestdestination)
            {
                shortestdestination = distance;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestdestination <= range)
        {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }
    }
}
