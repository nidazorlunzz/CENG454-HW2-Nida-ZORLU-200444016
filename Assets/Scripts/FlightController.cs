using UnityEngine;

public class FlightController : MonoBehaviour
{
    public float speed;
    public float maxSpeed = 400f;
    public float minSpeed = 0f;
    public float rotspeed1 = 30f;
    public float rotspeed2 = 30f;

    void Update() 
    {
        // DOĞRU ileri hareket
        transform.Translate(Vector3.forward * Time.deltaTime * speed);

        // Hızlan / yavaşla
        if(Input.GetKey(KeyCode.Space)){
            if(speed < maxSpeed){
                speed += 50f * Time.deltaTime;
            }
        }
        if(Input.GetKey(KeyCode.LeftShift)){
            if(speed > minSpeed){
                speed -= 50f * Time.deltaTime;
            }
        }

        // ROLL (Q / E)
        if(Input.GetKey(KeyCode.Q)){
            transform.Rotate(Vector3.forward * rotspeed1 * Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.E)){
            transform.Rotate(Vector3.forward * -rotspeed1 * Time.deltaTime);
        }

        // PITCH (W / S)
        if(Input.GetKey(KeyCode.W)){
            transform.Rotate(Vector3.right * -rotspeed2 * Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.S)){
            transform.Rotate(Vector3.right * rotspeed2 * Time.deltaTime);
        }

        // YAW (A / D)
        if(Input.GetKey(KeyCode.A)){
            transform.Rotate(Vector3.up * -rotspeed2 * Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.D)){
            transform.Rotate(Vector3.up * rotspeed2 * Time.deltaTime);
        }
    }
}