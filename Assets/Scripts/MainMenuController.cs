using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
   public void PlayHuman()
   {
      // Carrega a próxima cena
      SceneManager.LoadScene("PlayerScene");
   }

   public void PlayAI()
   {
      // Carrega a próxima cena
      SceneManager.LoadScene("AIScene");
   }
   
   public void Exit() {
      Application.Quit();
   }
}
