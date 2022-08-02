using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Paddle : MonoBehaviour
{
Animator anim;
//trigger variable
const string bounce_anim="isbounced";
//top hızı
[SerializeField] float speed=70f;
//matematiksel şeylerde kullanılacak sekme açısı
public float maxBounceAngle = 75f;
void Start()
{
    anim=this.GetComponent<Animator>();
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
        anim.SetTrigger(bounce_anim);
    }
//top paddle a çarparsa    
private void OnCollisionEnter2D(Collision2D collision) {
        //çarpan objenin adı Ball ise
    if(collision.gameObject.name=="Ball"||collision.gameObject.name=="Ball(Clone)"){
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
            ////
            ///animasyonu tetikleyecek fonksiyon
        animationTrigger();
    }
      
    
    
  }



}













