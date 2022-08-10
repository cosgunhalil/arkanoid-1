using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Corner : MonoBehaviour
{
    //Top bazen iki köşe arasında gidiyordu o yüzden eklendi wall classının aynısı
   Animator corner_bounce_animation;
    //triggerın adı
    const string trigger_name="iscorner";
    void Start(){
        corner_bounce_animation=GetComponent<Animator>();
    }
    private void animationTrigger(){
        corner_bounce_animation.SetTrigger(trigger_name);
    }
   private void OnCollisionEnter2D(Collision2D collision) {
        //Cornera çarpan şeyin adı Ball mu eğer ballsa animasyon başlasın
    if(collision.gameObject.name=="Ball"||collision.gameObject.name=="Ball(Clone)"){
        animationTrigger();
    }
  }
}
