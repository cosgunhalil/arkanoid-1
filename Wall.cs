using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Wall : MonoBehaviour
{///*********************************** yine aynı şeyden iki tane optmize et ***************************

    ///Wall animasyonu için
    Animator anim;
    //triggerın adı
    const string bounce_anim="iscollide";
    void Start(){
        anim=GetComponent<Animator>();
    }

    private void animationTrigger(){
        anim.SetTrigger(bounce_anim);
        
    }

   private void OnCollisionEnter2D(Collision2D collision) {
  
        //duvara çarpan şeyin adı Ball mu Paddle da olabilirdi eğer ballsa animasyon başlasın
    if(collision.gameObject.name=="Ball"){
        animationTrigger();

    }
  }
   
}
