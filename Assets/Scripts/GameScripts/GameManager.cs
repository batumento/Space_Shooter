using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject hazard;
    [SerializeField] private Text scoreText;
    [SerializeField] private Text scorePanel;
    [SerializeField] private int score;

    
    //Burada InvokeRepeating metodu kullanarak da yapabilirdik ama ben Coroutine bilgimi pekiþtirmek için Coroutine tercih ettim.
   
    public void Score(int _score)
    {
        score += _score;
        scoreText.text = score.ToString();
    }
    public void ScorePanel()
    {
        scorePanel.text = "Score: "+score.ToString();
    }
    public void AgainButton()
    {
        SceneManager.LoadScene(1);
    }
    public void MenuButton()
    {
        SceneManager.LoadScene(0);
    }
}
