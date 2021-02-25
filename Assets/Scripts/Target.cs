using UnityEngine;

public class Target : MonoBehaviour
{
    public float health = 100f;
    public void damage(float damage){
        health -= damage;
        if (health == 0f){
            die();
        }
    }
    private void die(){
        
    }
}
