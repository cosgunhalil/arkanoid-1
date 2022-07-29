using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class Brick : MonoBehaviour
{   

 
     public SpriteRenderer spriteRenderer{get; private set;}
    public int health{get;private set;}
     public Sprite[] color;
     public ParticleSystem[] particle;
    private void Awake(){
        this.spriteRenderer=GetComponent<SpriteRenderer>();
        
       
                
      
    }
  private void Start(){
    this.health=this.color.Length;
    this.spriteRenderer.sprite=this.color[this.health-1];
   

  }
 
  private void Hit(){
   
    this.health--;
  if(this.health<=0){
     
    Destroy(gameObject);
    
  }else{
    
    this.spriteRenderer.sprite=this.color[this.health-1];

  }
    

  }
private void OnCollisionEnter2D(Collision2D collision) {
  
        
    if(collision.gameObject.name=="Ball"){
      
     
      particle[health-1].Play();
   
  
      Hit();
      

    }
  }
}
