using UnityEngine;
using System.Collections;

public class DangerZoneController : MonoBehaviour
{
    [SerializeField] private FlightExamManager examManager;
    [SerializeField] private float missileDelay = 5f;

    private Coroutine countdown;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            examManager.EnterDangerZone();

            countdown = StartCoroutine(StartCountdown());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            examManager.ExitDangerZone();

            if (countdown != null)
            {
                StopCoroutine(countdown);
            }
        }
    }

    private IEnumerator StartCountdown()
    {
        yield return new WaitForSeconds(missileDelay);

        Debug.Log("Missile should launch now");
    }
}