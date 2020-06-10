﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotScript : MonoBehaviour
{
    public Rigidbody2D rb;
    public GameObject impactEffect;
    public float speed = 0f;
    int timeToExist = 1;
    float timeExisting = 0f;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    void FixedUpdate()
    {
        timeExisting += Time.fixedDeltaTime;  
        if(timeExisting >= timeToExist){
            GameObject bulletAnim = Instantiate(impactEffect,transform.position,transform.rotation);
            Destroy(gameObject);
            Destroy(bulletAnim, .34f);
        } 
    }

    //called when enter trigger
    void OnTriggerEnter2D(Collider2D hitInfo){
        BasicMove playerObject = hitInfo.GetComponent<BasicMove>();
        ShotScript shotObject = hitInfo.GetComponent<ShotScript>();
        PowerUp pwrUp = hitInfo.GetComponent<PowerUp>();

        string tag = hitInfo.tag;
        //what other objects do when a bullet hits it
        //only destroys itself when it hits something other than a player or bullet
        if(tag != "Player" && tag != "Bullet" && tag != "PlayerInteract"){//true if didnt hit player or bullet or powerup
            EnemyBehavior hitObject1 = hitInfo.GetComponent<EnemyBehavior>();
            JumperBehavior hitObject2 = hitInfo.GetComponent<JumperBehavior>();
            OctoBehavior hitObject3 = hitInfo.GetComponent<OctoBehavior>();

            if(hitObject1 != null){//true if hit an enemy
                hitObject1.Hit(10f);
            }else if(hitObject2 != null){
                hitObject2.Hit(10f);
            }else if (hitObject3 != null){
                hitObject3.Hit(10f);
            }
            endEffect(hitInfo);
        }
    }

    //what the bullet does when it hits an object
    void endEffect(Collider2D hitInfo){
        GameObject bulletAnim = Instantiate(impactEffect,transform.position,transform.rotation);
        Destroy(gameObject);
        Destroy(bulletAnim, .34f);
    }
}