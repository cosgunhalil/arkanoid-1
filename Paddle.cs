using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Paddle : MonoBehaviour
{
public float speed=70f;

public new Rigidbody2D rigidbody{
    get; private set;
}
public Vector2 direction{
    get; private set;
}
 private void Awake() {
    
this.rigidbody=GetComponent<Rigidbody2D>();
}
 private void Update() {
    if(Input.GetKey(KeyCode.A)){
        this.direction=Vector2.left;
    }
    else if(Input.GetKey(KeyCode.D)){
        this.direction=Vector2.right;
    }
    else{
        this.direction=Vector2.zero;
    }
    
}
 private void FixedUpdate() {
    if(this.direction!=Vector2.zero){
        this.rigidbody.AddForce(this.direction * this.speed);
    }
    
}

}












