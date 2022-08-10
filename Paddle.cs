using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Paddle : MonoBehaviour
{
    Collision2D collision;
    Animator Paddle_Animation;
    AudioSource audioo;
//trigger variable
    const string animation_trigger_for_scale="isbounced";
//top hızı
    [SerializeField] float speed=70f;
//matematiksel şeylerde kullanılacak sekme açısı
    public float maxBounceAngle = 75f;
    void Start()
    {
    Paddle_Animation=this.GetComponent<Animator>();
    audioo=this.GetComponent<AudioSource>();
    this.audioo.playOnAwake = false;
    }
    public new Rigidbody2D rigidbody{
    get; private set;
    }
    public Vector2 direction{
    get; private set;
    }
    private void Awake() {
        this.rigidbody=GetComponent<Rigidbody2D>();
    }
 //hareket
    private void Update() {
     if(Input.GetKey(KeyCode.A)){
        this.direction=Vector2.left;
     }
     else if(Input.GetKey(KeyCode.D)){
        this.direction=Vector2.right; 
     }
     else if(Input.GetKey(KeyCode.Escape)){
           SceneManager.LoadScene("Mainmenu");
     }
     else if(Input.GetKey(KeyCode.G)){
         SceneManager.LoadScene("gameover");
     }
     else{
        this.direction=Vector2.zero;
     }
    }
//sağlama,nolur nolmaz
    private void FixedUpdate() {
        if(this.direction!=Vector2.zero){
         this.rigidbody.AddForce(this.direction * this.speed);
     }
    }
    private void animationTrigger(){
    ///eğer fonksiyon çağrılmışsa bounce_anim adındaki triggerla animasyonu çağır
        Paddle_Animation.SetTrigger(animation_trigger_for_scale );
    }
      private void soundtrigger(){
        audioo.Play(); 
    }
    private void movement(){
         ////matematiksel şeyler
        Vector2 paddlePosition = transform.position;
        Vector2 contactPoint = collision.GetContact(0).point;
        float offset = paddlePosition.x - contactPoint.x;
        float maxOffset = collision.otherCollider.bounds.size.x / 2;
        float currentAngle = Vector2.SignedAngle(Vector2.up, collision.rigidbody.velocity);
        float bounceAngle = (offset / maxOffset) * maxBounceAngle;
        float newAngle = Mathf.Clamp(currentAngle + bounceAngle, -maxBounceAngle, maxBounceAngle);
        Quaternion rotation = Quaternion.AngleAxis(newAngle, Vector3.forward);
        collision.rigidbody.velocity = rotation * Vector2.up * collision.rigidbody.velocity.magnitude;
    }
//top paddle a çarparsa    
    private void OnCollisionEnter2D(Collision2D collision) {
         this.collision=collision;
            //çarpan objenin adı Ball ise
            if(collision.gameObject.name=="Ball"||collision.gameObject.name=="Ball(Clone)"){
           
                movement();
                audioo.Play();
                animationTrigger();
            } 
    }
}
    













