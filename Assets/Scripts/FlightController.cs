using UnityEngine;

public class AircraftController : MonoBehaviour
{
    [SerializeField] private FlightExamController missionController;

    [Header("Speed Settings")]
    [SerializeField] private float currentSpeed = 0f;
    [SerializeField] private float acceleration = 50f;
    [SerializeField] private float maxVelocity = 500f;
    [SerializeField] private float minVelocity = 0f;

    [Header("Rotation Settings")]
    [SerializeField] private float rollSpeed = 25f;
    [SerializeField] private float pitchYawSpeed = 25f;

    private bool takeoffTriggered = false;

    void Update()
    {
        HandleMovement();
        HandleRotation();
        HandleExamControls();
        CheckTakeoff();
    }

    private void HandleMovement()
    {
        
        transform.position += -transform.forward * currentSpeed * Time.deltaTime;

        
        if (Input.GetKey(KeyCode.Space))
        {
            currentSpeed = Mathf.Min(currentSpeed + acceleration * Time.deltaTime, maxVelocity);
        }

        
        if (Input.GetKey(KeyCode.LeftShift))
        {
            currentSpeed = Mathf.Max(currentSpeed - acceleration * Time.deltaTime, minVelocity);
        }
    }

    private void HandleRotation()
    {
        bool canRotate = currentSpeed >= 150f || transform.position.y >= 5f;

        // roll
        if (Input.GetKey(KeyCode.Q) && currentSpeed >= 150f)
        {
            transform.Rotate(Vector3.back * rollSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.E) && currentSpeed >= 150f)
        {
            transform.Rotate(Vector3.forward * rollSpeed * Time.deltaTime);
        }

        
        if (Input.GetKey(KeyCode.W) && canRotate)
        {
            transform.Rotate(Vector3.left * pitchYawSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S) && canRotate)
        {
            transform.Rotate(Vector3.right * pitchYawSpeed * Time.deltaTime);
        }

        
        if (Input.GetKey(KeyCode.A) && canRotate)
        {
            transform.Rotate(Vector3.down * pitchYawSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D) && canRotate)
        {
            transform.Rotate(Vector3.up * pitchYawSpeed * Time.deltaTime);
        }
    }

    private void HandleExamControls()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            missionController.OnMissileHit();
            missionController.ResetMission();

            currentSpeed = 0f;
            rollSpeed = 0f;
            pitchYawSpeed = 0f;
        }
    }

    private void CheckTakeoff()
    {
        if (!takeoffTriggered && transform.position.y >= 20f)
        {
            missionController.OnTakeoff();
            takeoffTriggered = true;
        }
    }
}