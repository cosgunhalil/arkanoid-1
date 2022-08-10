using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class Wall : MonoBehaviour
{ 
    
    AudioSource auidoo;
    [SerializeField] Boolean ShortWall;
    Animator wallanimation;
    const string trigger_animation_Short_Wall="iscollide";
    const string trigger_animation_Long_Wall="ıscollide2.0";
    void Start(){
        wallanimation=GetComponent<Animator>();
        auidoo=GetComponent<AudioSource>();
    }
    private void animationTriggerShortWall(){
        wallanimation.SetTrigger(trigger_animation_Short_Wall);
    }
    private void animationTriggerLongWall(){
        wallanimation.SetTrigger(trigger_animation_Long_Wall);
    }
    private void OnCollisionEnter2D(Collision2D collision) {
        //duvara çarpan şeyin adı Ball mu Paddle da olabilirdi eğer ballsa animasyon başlasın
        if(collision.gameObject.name=="Ball"||collision.gameObject.name=="Ball(Clone)"){
            if(ShortWall){
                auidoo.Play();
                animationTriggerShortWall();
        }
        else{
            animationTriggerLongWall();  
        }
        
    }
  }
}
