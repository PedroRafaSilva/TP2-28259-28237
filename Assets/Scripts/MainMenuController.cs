using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{

   public GameObject MainMenuUI;
   public GameObject CoopMenuUI;
   public GameObject AIMenuUI;

   public void PlayHuman()
   {
      MainMenuUI.SetActive(false);
      AIMenuUI.SetActive(false);
      CoopMenuUI.SetActive(true);
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
      MainMenuUI.SetActive(false);
      CoopMenuUI.SetActive(false);
      AIMenuUI.SetActive(true);
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

   public void Back() {
       AIMenuUI.SetActive(false);
       CoopMenuUI.SetActive(false);
       MainMenuUI.SetActive(true);
   }
   
   public void Exit() {
      Application.Quit();
   }
}
