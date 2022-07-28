using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class Brick : MonoBehaviour
{   

  private bool object_dısappear=true;
    public ParticleSystem particle;
     public SpriteRenderer spriteRenderer{get; private set;}
    public int health{get;private set;}
     public Sprite[] color;
    private void Awake(){
        this.spriteRenderer=GetComponent<SpriteRenderer>();
        
       
                
      
    }
  private void Start(){
    this.health=this.color.Length;
    this.spriteRenderer.sprite=this.color[this.health-1];
   

  }
   public void blockcrasher(){
    if(object_dısappear==false){
      particle.Play();
    }
   
        
  }
  private void Hit(){
   
    this.health--;
  if(this.health<=0){
     
    Destroy(gameObject);
      object_dısappear=false;
  }else{
    this.spriteRenderer.sprite=this.color[this.health-1];

  }
    

  }
private void OnCollisionEnter2D(Collision2D collision) {
  
        
    if(collision.gameObject.name=="Ball"){
      particle.Play();
      Hit();
      

    }
  }
}
