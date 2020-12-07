using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;

    public float speed = 40f;
    public float explosionRadious = 0f;
    public GameObject effect;

    public void seek(Transform _Target)
    {
        target = _Target;
    }

    // Update is called once per frame
    void Update()
    {
        if(target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float disFrame = speed * Time.deltaTime;

        if(dir.magnitude <= disFrame)
        {
            hitTarget();
            return;
        }

        transform.Translate(dir.normalized * disFrame, Space.World);
        transform.LookAt(target);

    }

    void hitTarget()
    {
        GameObject effectIns =(GameObject)Instantiate(effect, transform.position, transform.rotation);
        Destroy(effectIns, 5f);

        if(explosionRadious>0f)
        {
            explode();
        }

        else
        {
            Destroy(target.gameObject);
        }
        
        
    }

    void damage(Transform enemy)
    {
        Destroy(enemy.gameObject);
    }

    void explode()
    {
        Collider[] colliders =  Physics.OverlapSphere(transform.position,explosionRadious);
        
        foreach (Collider collider  in colliders)
        {
           
            if (collider.tag == "Enemy")
            {
                //Debug.Log(collider.tag.ToString());
                damage(collider.transform);
            }
        }
    }
}
