using UnityEngine;
using TMPro;

public class FlightExamManager : MonoBehaviour
{
    [SerializeField] private TMP_Text statusText;

    private bool inDangerZone = false;

    public void EnterDangerZone()
    {
        inDangerZone = true;
        statusText.text = "Entered a Dangerous Zone!";
    }

    public void ExitDangerZone()
    {
        inDangerZone = false;
        statusText.text = "Safe Zone";
    }

    public void OnMissileHit()
    {
        statusText.text = "You got hit!";
    }

    public void ResetMission()
    {
        statusText.text = "Mission Reset";
    }

    public void OnTakeoff()
    {
        statusText.text = "Takeoff successful";
    }
}