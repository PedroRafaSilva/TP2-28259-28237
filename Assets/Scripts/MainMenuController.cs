using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
   public GameObject mainMenuUI;
   public GameObject coopMenuUI;
   public GameObject aiMenuUI;

   public void PlayHuman()
   {
      mainMenuUI.SetActive(false);
      aiMenuUI.SetActive(false);
      coopMenuUI.SetActive(true);
   }

   public void SingleBall()
   {
      SceneManager.LoadScene("PlayerScene");
   }

   public void DoubleBall()
   {
      SceneManager.LoadScene("DoubleBallScene");
   }

   public void PlayAI()
   {
      mainMenuUI.SetActive(false);
      coopMenuUI.SetActive(false);
      aiMenuUI.SetActive(true);
   }

   public void PlayAIEasy()
   {
      SceneManager.LoadScene("AIEasyScene");
   }

   public void PlayAINormal()
   {
      SceneManager.LoadScene("AINormalScene");
   }

   public void PlayAIHard()
   {
      SceneManager.LoadScene("AIHardScene");
   }

   public void Back()
   {
       aiMenuUI.SetActive(false);
       coopMenuUI.SetActive(false);
       mainMenuUI.SetActive(true);
   }
   
   public void Exit()
   {
      Application.Quit();
   }
}
