using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
    [SerializeField]
    private GameObject _title = null;
    [SerializeField]
    private Button _startButton = null;
    [SerializeField]
    private Button _tipButton = null;

    [SerializeField]
    private NumbersRenderer _numbersRenderer = null;

    [SerializeField]
    private GameObject _bestScore = null;


    [SerializeField]
    private GameOverPopup _gameOverPopup = null; 

    public int Score { set {
            _numbersRenderer.value = value;
        } }

    private void Start()
    {
        Init();
        ShowTitle();
    }

    public void Init()
    {
        _title.gameObject.SetActive(false);
        _startButton.gameObject.SetActive(false);
        _tipButton.gameObject.SetActive(false);
        _gameOverPopup.gameObject.SetActive(false);
        _numbersRenderer.gameObject.SetActive(false);
    }

    public void ShowTitle()
    {
        _title.gameObject.SetActive(true);
        _startButton.gameObject.SetActive(true);
    }

    public void StartButton()
    {
        ShowTipButton();

        _title.SetActive(false);
        _startButton.gameObject.SetActive(false);
    }

    public void TipButton()
    {
        ShowScore();
        Manager.Instance.isPlay = true;
        _tipButton.gameObject.SetActive(false);
        
    }

    private void ShowTipButton()
    {
        _tipButton.gameObject.SetActive(true);
    }

    public void ShowScore()
    {
        _numbersRenderer.value = 0;
        _numbersRenderer.gameObject.SetActive(true);
    }

    public void InvokeGameOver()
    {
        _gameOverPopup.Show();
        _numbersRenderer.gameObject.SetActive(false);
        _bestScore.gameObject.SetActive(false);
    }
}
