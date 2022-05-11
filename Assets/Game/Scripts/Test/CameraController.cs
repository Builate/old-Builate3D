using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float Speed;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        float Horizontal = Input.GetAxisRaw("Horizontal");
        float Vertical = Input.GetAxisRaw("Vertical");
        Vector3 MoveVec = new Vector3(0, 0, 0);

        if (Input.GetKey(KeyCode.LeftShift))
        {
            Quaternion horizontalRotation = Quaternion.AngleAxis(Camera.main.transform.eulerAngles.y, Vector3.up);
            MoveVec = horizontalRotation * new Vector3(Horizontal, 0, Vertical);
            MoveVec = MoveVec * Speed;
        }
        else
        {
            MoveVec = Camera.main.transform.forward * Vertical * Speed + Camera.main.transform.right * Horizontal * Speed;
        }

        transform.position += MoveVec * Time.deltaTime;





    }
}
