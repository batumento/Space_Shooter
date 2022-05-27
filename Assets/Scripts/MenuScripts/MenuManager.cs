using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;
public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject startButton;
    [SerializeField] private GameObject exitButton;
    [SerializeField] private GameObject shipObject;
    [SerializeField] private GameObject shipObject2;
    private void Start()
    {
        StartCoroutine(nameof(MenuElements));
    }

    IEnumerator MenuElements()
    {
        startButton.GetComponent<CanvasGroup>().DOFade(1, 1f);
        yield return new WaitForSeconds(0.5f);
        exitButton.GetComponent<CanvasGroup>().DOFade(1, 0.5f);
    }
    private void Update()
    {
        ShipRoutine();
    }
    private void ShipRoutine()
    {
        shipObject.transform.Rotate(Random.Range(5,10) * Time.deltaTime,Random.Range(5,10)*Time.deltaTime, Random.Range(5,10)* Time.deltaTime);
        shipObject2.transform.Rotate(Random.Range(5, 10) * Time.deltaTime, Random.Range(5, 10) * Time.deltaTime, Random.Range(5, 10) * Time.deltaTime);
    }

    public void StartButton()
    {
        SceneManager.LoadScene(1);
    }
    public void ExitButton()
    {
        Application.Quit();
    }
}
