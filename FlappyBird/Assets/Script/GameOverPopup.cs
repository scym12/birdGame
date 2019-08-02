using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverPopup : MonoBehaviour
{
    [SerializeField]
    private NumbersRenderer _score = null;
    [SerializeField]
    private NumbersRenderer _best = null;

    [SerializeField]
    private GameObject _newBestScore = null;



    public void Show()
    {
        gameObject.SetActive(true);
        _newBestScore.SetActive(Manager.Instance.iscurrentBestScore);
        _score.value = Manager.Instance.Score;
        _best.value = Manager.Instance.HighScore;

        Debug.Log("bestScore:" + Manager.Instance.iscurrentBestScore);

        _newBestScore.SetActive(true);
    }

    public void OkButton()
    {
        gameObject.SetActive(false);
        Manager.Instance.Replay();
    }
}
