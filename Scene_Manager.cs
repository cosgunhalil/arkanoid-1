using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_Manager : MonoBehaviour
{
    // Start is called before the first frame update
   public void level(){
    SceneManager.LoadScene("Normal_Level");
   }
   public void menu(){
    SceneManager.LoadScene("Mainmenu");
   }
   public void over(){
    SceneManager.LoadScene("gameover");
   }
  
}
