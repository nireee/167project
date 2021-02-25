using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public Camera fpscam;
    public Camera movingcam;
    public ParticleSystem flash;
    public GameObject guns;
    public float damage;
    public float range;
    // public float shooting_speed;
    void Start(){
        flash.Stop();
    }
    
    void Update()
    {
        Aim();
        Shoot();
    }
    void Shoot(){
        if (Input.GetMouseButtonDown(0)){
            flash.Play();
            Debug.Log("fire");
            

            // RaycastHit Hitinfo;
        }
        // lack of the target that going to fight, also need to figure out how to shoot with different speed.
        // if(Physics.Raycast(cam.transform.position, cam.transform.forward, out Hitinfo, range)){
        // // Target target = Hitinfo.transform.GetComponent<Target>();
        // // if(target != null){  
        // //     target.damage(damage);
        // // }
        // }
    }
    void Aim(){
        if (Input.GetMouseButtonDown(1))
        {
            fpscam.enabled = true;
            movingcam.enabled = false;
        }
        else if (Input.GetMouseButtonUp(1))
        {
            movingcam.enabled = true;
            fpscam.enabled = false;
        }
    }
}
