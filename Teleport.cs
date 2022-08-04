using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{  

    AudioSource audioo;
    //teleport noktalarının konumu
    private Transform destination;
    private Transform destination2;
    ////
   ///teleporterları birbirinden ayırmak için teleport A ve Teleport B gibi
    [SerializeField] bool isTeleporter_A;
    //Teleportun gerçekleşmesi için gerekli olan uzaklık
    public float distance=1f;
    //Teleporter ve Teleporter2 taglerine sahip objeleri bulup onların transform componentlerini alıyor
    void Start(){
            destination=GameObject.FindGameObjectWithTag("Teleporter").GetComponent<Transform>();
            destination2=GameObject.FindGameObjectWithTag("Teleporter2").GetComponent<Transform>();
           
            audioo=this.GetComponent<AudioSource>();
    }
   
    void OnTriggerEnter2D(Collider2D other) {
        //topun teleporta pozisyonu olabilecek minimum uzaklıktan büyük mü ve girdiği teleport A mı B mı?
    if(other.gameObject.name=="Ball"||other.gameObject.name=="Ball(Clone)"){
        audioo.Play();
    if(Vector2.Distance(transform.position,other.transform.position)>distance&&isTeleporter_A==false){
        other.transform.position=new Vector3(destination.position.x,destination.position.y,destination.position.z);
    }else if(Vector2.Distance(transform.position,other.transform.position)>distance&&isTeleporter_A==true){
        other.transform.position=new Vector3(destination2.position.x,destination2.position.y,destination2.position.z);
    }
    ////
    }
    }
}

