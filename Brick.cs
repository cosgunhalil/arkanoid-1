
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;


public class Brick : MonoBehaviour
{   
  public bool audioenablee=false;
      AudioSource brick_effect;
      /// brickin cinsi
     public SpriteRenderer spriteRenderer{get; private set;}
     //// tuğla kaç vuruşta gidecek
    public int health;
    ///tuğla her vuruşta renk değiştirecek
     public Sprite[] color;
     /// her vuruşta partikül sistemi colora uygun şekilde çalıştırılacak
     public ParticleSystem[] particle;
    private void Awake(){
        this.spriteRenderer=GetComponent<SpriteRenderer>();    
          brick_effect=this.GetComponent<AudioSource>();
          this.brick_effect.playOnAwake = false;
       
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

  public void audiosettings(){
    this.audioenablee=true;
  }
  private void AudioTrigger(){
    brick_effect.Play();
  }
  //çarpışma olduğu anda
private void OnCollisionEnter2D(Collision2D collision) {
   
  ///çarpan şeyin adı Ball mu?
    if(collision.gameObject.name=="Ball"||collision.gameObject.name=="Ball(Clone)"){
      /// eğer ballsa partikülleri ve Hit() fonksiyonunu çalıştır
      particle[health-1].Play();
      AudioTrigger();
      Hit();
    }
    
  }
}
