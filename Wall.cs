using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Wall : MonoBehaviour
{ 
    public bool bounce=true;
    AudioSource auidoo;
    ///Wall animasyonu için
    Animator anim;
    //triggerın adı
    const string trigger_animation="iscollide";
    void Start(){
        anim=GetComponent<Animator>();
        auidoo=GetComponent<AudioSource>();
    }
    private void animationTrigger(){
        if(bounce){

        anim.SetTrigger(trigger_animation);
        }
    }
   private void OnCollisionEnter2D(Collision2D collision) {
        //duvara çarpan şeyin adı Ball mu Paddle da olabilirdi eğer ballsa animasyon başlasın
    if(collision.gameObject.name=="Ball"||collision.gameObject.name=="Ball(Clone)"){
        animationTrigger();
        auidoo.Play();
    }
  }
}
