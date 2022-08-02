using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Numerics;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class Brick : MonoBehaviour
{   
       Ball  ball;
   public  Power power;
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
    if(collision.gameObject.name=="Ball"){
      /// eğer ballsa partikülleri ve Hit() fonksiyonunu çalıştır
      particle[health-1].Play();

    
   
      Hit();
    }
    
  }
}
