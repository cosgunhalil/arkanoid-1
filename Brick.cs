
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class Brick : MonoBehaviour
{   
    AudioSource audioo;
      /// brickin cinsi
     public SpriteRenderer spriteRenderer{get; private set;}
     //// tuğla kaç vuruşta gidecek
    public int health{get;private set;}
    ///tuğla her vuruşta renk değiştirecek
     public Sprite[] color;
     /// her vuruşta partikül sistemi colora uygun şekilde çalıştırılacak
     public ParticleSystem[] particle;
    private void Awake(){
        this.spriteRenderer=GetComponent<SpriteRenderer>();    
          audioo=this.GetComponent<AudioSource>();
          this.audioo.playOnAwake = false;
       
    }
  private void Start(){
    this.health=this.color.Length;
    this.spriteRenderer.sprite=this.color[this.health-1];
  
  }
  private void Hit(){
   ///çarptıysa brick sağlığını 1 azalt rengini değiştir
    this.health--;
   
  if(this.health<=0){
    Destroy(gameObject);
  }else{
    this.spriteRenderer.sprite=this.color[this.health-1];
  }

  }
  //çarpışma olduğu anda
private void OnCollisionEnter2D(Collision2D collision) {
   
  ///çarpan şeyin adı Ball mu?
    if(collision.gameObject.name=="Ball"||collision.gameObject.name=="Ball(Clone)"){
      /// eğer ballsa partikülleri ve Hit() fonksiyonunu çalıştır
      particle[health-1].Play();

      audioo.Play();
      
    
   
      Hit();
    }
    
  }
}
