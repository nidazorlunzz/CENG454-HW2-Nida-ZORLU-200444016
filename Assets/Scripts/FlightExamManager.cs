using UnityEngine;
using TMPro;

public class FlightExamManager : MonoBehaviour
{
    [SerializeField] private TMP_Text statusText;

    private bool hasTakenOff = false;
    private bool inDangerZone = false;
    private bool threatCleared = false;

    
    public void EnterDangerZone()
    {
        inDangerZone = true;
        statusText.text = "Entered a Dangerous Zone!";
    }

    
    public void ExitDangerZone()
    {
        inDangerZone = false;
        threatCleared = true;
        statusText.text = "Safe Zone";
    }

    
    public void OnTakeoff()
    {
        hasTakenOff = true;
        statusText.text = "Takeoff Successful";
    }

  
    public void OnMissileHit()
    {
        statusText.text = "You got hit!";
    }
}