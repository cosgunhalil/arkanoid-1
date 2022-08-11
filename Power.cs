using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Power : MonoBehaviour
{         
  AudioSource audioo;
  [SerializeField]  GameObject [] ExtraBall;
  GameObject [] spawnTheBall=new GameObject[3];
        
  private void Start() {
      audioo=this.GetComponent<AudioSource>();    
 }
   ///temas ederse Spawnball classını çağır
  void OnTriggerEnter2D(Collider2D other) {
    if(other.gameObject.name=="Ball"||other.gameObject.name=="Ball(Clone)"){
      audioo.Play();
      Spawnball();
     } 
    }
    void positionsOfTheExtraBalls(){
    //TODO: use for or foreach!!!
      spawnTheBall[0].transform.position=new Vector3(this.transform.position.x,this.transform.position.y,this.transform.position.z);
      spawnTheBall[1].transform.position=new Vector3(this.transform.position.x,this.transform.position.y,this.transform.position.z);
      spawnTheBall[2].transform.position=new Vector3(this.transform.position.x,this.transform.position.y,this.transform.position.z);
    }
    //3 tane ball objesini topun çarptığı objenin konumunda üret ve topun çarptığı objeyi yok et.
    void Spawnball(){
    //TODO: use for or foreach!!!
      spawnTheBall[0]= Object.Instantiate(ExtraBall[0]) as GameObject;
      spawnTheBall[1]= Object.Instantiate(ExtraBall[1]) as GameObject;
      spawnTheBall[2]= Object.Instantiate(ExtraBall[2]) as GameObject;
      positionsOfTheExtraBalls();
      Destroy(this.gameObject); //TODO: use object pool design pattern!!!
       }
}
