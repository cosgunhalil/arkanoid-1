
using Unity.VisualScripting;
using UnityEngine;

public class Ball : MonoBehaviour
{
  Animator ball_animation;
  [SerializeField] Shake Maincamera;
  public float ball_speed=750f;
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
    this.rigidbody.AddForce(force*this.ball_speed);
    ball_animation=GetComponent<Animator>();
  }
  private void animationTrigger(){
    ball_animation.SetTrigger("square");
  }
  private void OnCollisionEnter2D(Collision2D other) {
    if(other.collider.name=="Brick"||other.collider.name=="Paddle"){
      animationTrigger();
      Maincamera.Shakes();
    }
  }
}
