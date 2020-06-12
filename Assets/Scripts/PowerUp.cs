﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : PowerUpAbstract
{
    //set in the Inspector
    //T0:shot1 cd to 0
    //T1:shot2 cd to 0
    //T2:speed to 60
    //T3:health+40
    //T4:shot3 cd to 0
    


    public int type;
    public float duration;

    bool active = false;
    BasicMove player;
    playerWeapon weapon;


    public override void Start(){
        //type = 0;
        //duration = 4f;
    }

    public override void Update(){
        if(active){
            duration -= Time.fixedDeltaTime;
            if(duration <= 0){
                active = false;
                endEffect();
            }
        }
        
    }
    // Start is called before the first frame update
    public override void OnTriggerEnter2D(Collider2D hitInfo){
        //what other objects do when a bullet hits it
        //only destroys itself when it hits something other than a player or bullet
        if(hitInfo.CompareTag("Player")){//true if hit player
            player = hitInfo.GetComponent<BasicMove>();
            weapon = player.GetComponent<playerWeapon>();
            startEffect();
        }
    }

    public override void startEffect(){
        active = true; 
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<CircleCollider2D>().enabled = false;
        player.powerUp(true,type);
        weapon.powerUp(true, type);
    }

    public override void endEffect(){
        player.powerUp(false,type);
        weapon.powerUp(false, type);
        Destroy(gameObject);
    }
}
