
using Unity.VisualScripting;
using UnityEngine;

public class Ball : MonoBehaviour
{

   Animator anim;
  const string bounce_anim="big";
   
    public ParticleSystem particle;
   public float speed=750f;
   public new Rigidbody2D rigidbody{
    get; private set;
    }
   private void Awake() {
    this.rigidbody=GetComponent<Rigidbody2D>();
    }

    
    public void Start() 
    {
     
       Vector2 force=Vector2.zero;
       force.x=Random.Range(-1f,1f);
       force.y=-1f;
       this.rigidbody.AddForce(force*this.speed);
        anim=GetComponent<Animator>();
       
    }
     private void animationTrigger(){
        anim.SetTrigger(bounce_anim);
    }
   
   
    private void OnCollisionEnter2D(Collision2D other) {
      if(other.collider.name=="Brick"||other.collider.name=="Paddle"||other.collider.name=="wall"||other.collider.name=="Corner"){

      animationTrigger();
      }
    }

}
