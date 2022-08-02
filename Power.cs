using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Power : MonoBehaviour
{
        [SerializeField] GameObject Powerr;
         [SerializeField] GameObject Powerr2;
          [SerializeField] GameObject Powerr3;
     void OnTriggerEnter2D(Collider2D other) {
       if(other.gameObject.name=="Ball"||other.gameObject.name=="Ball(Clone)"){
       Spawnball();

       }
        
    }
    void Spawnball(){
        GameObject a= Object.Instantiate(Powerr) as GameObject;
        GameObject a1= Object.Instantiate(Powerr2) as GameObject;
        GameObject a2= Object.Instantiate(Powerr3) as GameObject;
        a.transform.position=new Vector3(this.transform.position.x,this.transform.position.y,this.transform.position.z);
        a1.transform.position=new Vector3(this.transform.position.x,this.transform.position.y,this.transform.position.z);
         a2.transform.position=new Vector3(this.transform.position.x,this.transform.position.y,this.transform.position.z);
        Destroy(this.gameObject);
        
       }
}
