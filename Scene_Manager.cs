using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_Manager : MonoBehaviour
{
   //sceneler arası geçiş
   public void level(){
    SceneManager.LoadScene("Normal_Level");
   }
   public void menu(){
    SceneManager.LoadScene("Mainmenu");
   }
   public void over(){
    SceneManager.LoadScene("gameover");
   }
   public void settings(){
      SceneManager.LoadScene("Settings");
   
   }
   
  
}
