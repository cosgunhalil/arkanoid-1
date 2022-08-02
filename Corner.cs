using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Corner : MonoBehaviour
{
    // Start is called before the first frame update
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
        //duvara çarpan şeyin adı Ball mu Paddle da olabilirdi eğer ballsa animasyon başlasın
    if(collision.gameObject.name=="Ball"||collision.gameObject.name=="Ball(Clone)"){
        animationTrigger();
    }
  }
}
