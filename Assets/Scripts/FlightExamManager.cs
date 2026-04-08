using UnityEngine;
using TMPro;

public class FlightExamManager : MonoBehaviour
{
    [SerializeField] private TMP_Text statusText;

    private bool hasTakenOff = false;
    private bool enteredDanger = false;
    private bool threatCleared = false;

    public void OnTakeoff()
    {
        hasTakenOff = true;
        statusText.text = "Takeoff OK";
    }

    public void EnterDangerZone()
    {
        enteredDanger = true;
        statusText.text = "Entered Dangerous Zone!";
    }

    public void ExitDangerZone()
    {
        if (enteredDanger)
        {
            threatCleared = true;
            statusText.text = "Escaped Danger Zone";
        }
    }

    public void OnLanding()
    {
        if (hasTakenOff && threatCleared)
        {
            statusText.text = "MISSION COMPLETE";
        }
        else
        {
            statusText.text = "Mission Failed (Wrong Order)";
        }
    }
}