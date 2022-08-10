using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEditor;
using UnityEngine;

public class Obstacle_mover : MonoBehaviour
{
    private Vector3 startPosition;
    ///ne kadar hızlı hareket edecek
    [SerializeField] private float move_speed=0.2f;
    //ne kadar uzağa gidecek
    [SerializeField] private float distance=0.2f;
   
    void Start()
    {
        startPosition=transform.position;
    }
    // position her framede sağa doğru değişiyor
    void Update()
    {
        transform.position=startPosition+transform.right*Mathf.Sin(Time.time*move_speed)*distance;
    }
}
