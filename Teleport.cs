using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{  private Transform destination;
    private Transform destination2;
    public bool isTeleporter;
    
    public float distance=1f;
        void Start(){
       
            destination=GameObject.FindGameObjectWithTag("Teleporter").GetComponent<Transform>();
       
           destination2=GameObject.FindGameObjectWithTag("Teleporter2").GetComponent<Transform>();

        
    }
   
    void OnTriggerEnter2D(Collider2D other) {
    if(Vector2.Distance(transform.position,other.transform.position)>distance&&isTeleporter==false){
        other.transform.position=new Vector3(destination.position.x,destination.position.y,destination.position.z);
        
    }else if(Vector2.Distance(transform.position,other.transform.position)>distance&&isTeleporter==true){
        other.transform.position=new Vector3(destination2.position.x,destination2.position.y,destination2.position.z);
       
    }
    
    }

    
}

