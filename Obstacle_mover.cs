using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEditor;
using UnityEngine;

public class Obstacle_mover : MonoBehaviour
{

    private Vector3 startPosition;
    ///ne kadar hızlı hareket edecek
    [SerializeField] private float frequency=0.2f;
    //ne kadar uzağa gidecek
    [SerializeField] private float magnitude=0.2f;

  
 

    // Start is called before the first frame update
    void Start()
    {
        startPosition=transform.position;


    }

    // position her framede sağa doğru değişiyor
    void Update()
    {
        transform.position=startPosition+transform.right*Mathf.Sin(Time.time*frequency)*magnitude;
        
    }
   
  
   
}
