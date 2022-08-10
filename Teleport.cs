using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{  

    AudioSource audioo;
    //teleport noktalarının konumu
    private Transform BottomBlueTeleport;
    private Transform UpperBlueTeleport;
    private Transform BottomRedTeleport;
    private Transform UpperRedTeleport;
    Collider2D colliders;
    ////
   ///teleporterları birbirinden ayırmak için teleport A ve Teleport B gibi
    [SerializeField] bool isTeleporterBlueBottom;
    [SerializeField] bool isTeleporterRedBottom;
    [SerializeField] bool isTeleporterBlue;
    [SerializeField] bool isTeleporterRed;
    //Teleportun gerçekleşmesi için gerekli olan uzaklık
    public float distance=1f;
    //Teleporter ve Teleporter2 taglerine sahip objeleri bulup onların transform componentlerini alıyor
    void Start(){
            BottomBlueTeleport=GameObject.FindGameObjectWithTag("Teleporter").GetComponent<Transform>();
            UpperBlueTeleport=GameObject.FindGameObjectWithTag("Teleporter2").GetComponent<Transform>();
            BottomRedTeleport=GameObject.FindGameObjectWithTag("Teleporter3").GetComponent<Transform>();
            UpperRedTeleport=GameObject.FindGameObjectWithTag("Teleporter4").GetComponent<Transform>();
            audioo=this.GetComponent<AudioSource>();
    }
    void Blue_Teleport(){
        audioo.Play();
    if(Vector2.Distance(transform.position,colliders.transform.position)>distance&&isTeleporterBlueBottom==false){
        colliders.transform.position=new Vector3(BottomBlueTeleport.position.x,BottomBlueTeleport.position.y,BottomBlueTeleport.position.z);
    }else if(Vector2.Distance(transform.position,colliders.transform.position)>distance&&isTeleporterBlueBottom==true){
        colliders.transform.position=new Vector3(UpperBlueTeleport.position.x,UpperBlueTeleport.position.y,UpperBlueTeleport.position.z);
    }
    }

    void Red_Teleport(){
        audioo.Play();
    if(Vector2.Distance(transform.position,colliders.transform.position)>distance&&isTeleporterRedBottom==false){
        colliders.transform.position=new Vector3(BottomRedTeleport.position.x,BottomRedTeleport.position.y,BottomRedTeleport.position.z);
    }else if(Vector2.Distance(transform.position,colliders.transform.position)>distance&&isTeleporterRedBottom==true){
        colliders.transform.position=new Vector3(UpperRedTeleport.position.x,UpperRedTeleport.position.y,UpperRedTeleport.position.z);
    }
    }
    void OnTriggerEnter2D(Collider2D other) {
         this.colliders=other;
        //topun teleporta pozisyonu olabilecek minimum uzaklıktan büyük mü ve girdiği teleport A mı B mı?
        if((colliders.gameObject.name=="Ball"||colliders.gameObject.name=="Ball(Clone)")&&isTeleporterBlue){
            Blue_Teleport();
        }
        else if((colliders.gameObject.name=="Ball"||colliders.gameObject.name=="Ball(Clone)")&&isTeleporterRed){
            Red_Teleport();
        }
  
    ////
    }
    }


