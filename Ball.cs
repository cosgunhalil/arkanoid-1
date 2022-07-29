
using Unity.VisualScripting;
using UnityEngine;

public class Ball : MonoBehaviour
{
   private GameObject currentTeleporter;
   public float speed=750f;
   public new Rigidbody2D rigidbody{
    get; private set;
    }
   private void Awake() {
    
    this.rigidbody=GetComponent<Rigidbody2D>();
    }
    private void Start() 
    {
       Vector2 force=Vector2.zero;
       force.x=Random.Range(-1f,1f);
       force.y=-1f;
  
       this.rigidbody.AddForce(force*this.speed);
      
        
    }
    
    private void gamestart(){

    }   












}
