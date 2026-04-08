using UnityEngine;

public class MissileHoming : MonoBehaviour
{
    public float speed = 30f;
    public float turnSpeed = 5f;

    private Transform target;

    public void SetTarget(Transform t)
    {
        target = t;
    }

    void Update()
    {
        if (target == null) return;

        Vector3 dir = (target.position - transform.position).normalized;

        Quaternion rot = Quaternion.LookRotation(dir);
        transform.rotation = Quaternion.Lerp(transform.rotation, rot, turnSpeed * Time.deltaTime);

        transform.position += transform.forward * speed * Time.deltaTime;
    }
}