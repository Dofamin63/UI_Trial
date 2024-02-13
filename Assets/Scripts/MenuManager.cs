using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
   public static bool IsPause;
   private TextMeshProUGUI star_wallet;
   private AudioController _audioController => GameObject.Find("AudioController").transform.GetComponent<AudioController>();

   void Awake()
   {
      SavingSystem.LoadData();
      star_wallet = GameObject.Find("StarsWallet").transform.GetChild(1).GetComponent<TextMeshProUGUI>();
      star_wallet.SetText(SavingSystem.GetStar().ToString());
   }

   public void PlayGame()
   {
      _audioController.PlaySound(_audioController.sound[0]);
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
   }
   public void Options()
   {
      _audioController.PlaySound(_audioController.sound[0]);
   }

   public void ExitGame()
   {
      _audioController.PlaySound(_audioController.sound[0]);
      Application.Quit();
   }
    
   public void BackToMenuMain()
   {
      _audioController.PlaySound(_audioController.sound[0]);
      PlayerPrefs.Save();
   }

   public void Reset()
   {
      Time.timeScale = 1;
      _audioController.PlaySound(_audioController.sound[0]);
      IsPause = false;
      Invoke(nameof(ResetScene), 1f);
   }

   private void ResetScene()
   {
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
   }
   
   public void Continue()
   {
      Time.timeScale = 1;
      _audioController.PlaySound(_audioController.sound[0]);
      PlayerPrefs.Save();
      IsPause = false;
   }
   
   public void Pause()
   {
      _audioController.PlaySound(_audioController.sound[0]);
      IsPause = true;
      // Time.timeScale = 0;
   }
   
   public void BackToMenu()
   {
      _audioController.PlaySound(_audioController.sound[0]);
      IsPause = false;
      Time.timeScale = 1;
      PlayerPrefs.Save();
      SceneManager.LoadScene("Menu");
   }
}
