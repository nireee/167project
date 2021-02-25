using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Transform cam;
    public Transform player;
    public float xSensitivity;
    public float ySensitivity;
    public float angle;
    public static bool locked = true;

    private Quaternion camera;
    void Start()
    {
        camera = cam.localRotation;
    }

    void Update()
    {
        float input1 = Input.GetAxisRaw("Mouse Y")* ySensitivity * Time.deltaTime;
        Quaternion ang1 = Quaternion.AngleAxis(input1, Vector3.right);
        Quaternion delta1 = cam.localRotation * ang1;
        if(Quaternion.Angle(camera,delta1)<angle){
            cam.localRotation = delta1;
        }

        float input2 = Input.GetAxisRaw("Mouse X")* xSensitivity * Time.deltaTime;
        Quaternion ang2 = Quaternion.AngleAxis(input2, Vector3.up);
        Quaternion delta2 = player.localRotation * ang2;
        player.localRotation = delta2;

        CursorLocked();
    }

    void CursorLocked(){
        if(locked){
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            if(Input.GetKeyDown(KeyCode.Escape)){
                locked = false;
            }
        }else{
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            if(Input.GetKeyDown(KeyCode.Escape)){
                locked = true;
            }
        }
    }
}
