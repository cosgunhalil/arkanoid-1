using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Power : MonoBehaviour
{
        [SerializeField] GameObject Ball1;
        [SerializeField] GameObject Ball2;
        [SerializeField] GameObject Ball3;
         

          ///temas ederse Spawnball classını çağır
     void OnTriggerEnter2D(Collider2D other) {
       if(other.gameObject.name=="Ball"||other.gameObject.name=="Ball(Clone)"){
       Spawnball();

       }
        
    }
    //3 tane ball objesini topun çarptığı objenin konumunda üret ve topun çarptığı objeyi yok et.
    void Spawnball(){
        GameObject a= Object.Instantiate(Ball1) as GameObject;
        GameObject a2= Object.Instantiate(Ball2) as GameObject;
        GameObject a3= Object.Instantiate(Ball3) as GameObject;
       
        a.transform.position=new Vector3(this.transform.position.x,this.transform.position.y,this.transform.position.z);
        a2.transform.position=new Vector3(this.transform.position.x,this.transform.position.y,this.transform.position.z);
        a3.transform.position=new Vector3(this.transform.position.x,this.transform.position.y,this.transform.position.z);
    
        Destroy(this.gameObject);
        
       }
}
