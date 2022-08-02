using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Corner : MonoBehaviour
{
    //Top bazen iki köşe arasında gidiyordu o yüzden eklendi wall classının aynısı
   Animator anim;
    //triggerın adı
    const string bounce_anim="iscorner";
    void Start(){
        anim=GetComponent<Animator>();
    }
    private void animationTrigger(){
        anim.SetTrigger(bounce_anim);
    }
   private void OnCollisionEnter2D(Collision2D collision) {
        //Cornera çarpan şeyin adı Ball mu Paddle da olabilirdi eğer ballsa animasyon başlasın
    if(collision.gameObject.name=="Ball"||collision.gameObject.name=="Ball(Clone)"){
        animationTrigger();
    }
  }
}
