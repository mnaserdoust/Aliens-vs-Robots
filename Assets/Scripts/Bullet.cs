using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;

    public float speed = 40f;
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

    }

    void hitTarget()
    {
        GameObject effectIns =(GameObject)Instantiate(effect, transform.position, transform.rotation);
        Destroy(effectIns, 2f);
        Destroy(target.gameObject);
        Destroy(gameObject);
    }
}
