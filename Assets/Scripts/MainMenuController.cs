using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour


{
   public void PlayHuman()
{
    // Carrega a próxima cena
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
}


   public void PlayIA() {
    
    // Carrega a próxima cena
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
   }

   public void Exit() {
      Application.Quit();
   }
}
