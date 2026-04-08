using UnityEngine;

public class MissileLauncher : MonoBehaviour
{
    public GameObject missilePrefab;
    public Transform launchPoint;

    private GameObject activeMissile;

    public void Launch(Transform target)
    {
        activeMissile = Instantiate(missilePrefab, launchPoint.position, launchPoint.rotation);

        activeMissile.GetComponent<MissileHoming>().SetTarget(target);
    }

    public void DestroyMissile()
    {
        if (activeMissile != null)
        {
            Destroy(activeMissile);
        }
    }
}