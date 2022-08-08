using System.Collections;
using System.Collections.Generic;
using System.Runtime;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;

public class trackitdown : MonoBehaviour
{
     [SerializeField] GameObject target;
      [SerializeField] GameObject eyeball;
     void Update()
     {
         transform.rotation= Quaternion.Euler(0,0,(eyeball.transform.position.x*5-target.transform.position.x*5));
     }
}
