using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private int stars;
    private TextMeshProUGUI starsCounter;

    private void Awake()
    {
        starsCounter = GameObject.Find("StarsCounter").transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        starsCounter.SetText("0");
    }

    public void AddStar()
    {
        stars++;
        starsCounter.SetText(stars.ToString());
    }

    public void Exit()
    {
        SavingSystem.UpdateData(stars);
        SceneManager.LoadScene("Menu");
    }
    
}
