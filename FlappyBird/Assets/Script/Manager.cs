using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : Singleton<Manager>
{

    [SerializeField]
    private Bird _bird = null;
    [SerializeField]
    private Ground _ground = null;
    [SerializeField]
    private Pipe _pipe = null;

    [SerializeField]
    private float _speed = 0.001f;

    [SerializeField]
    private float _createTime = 4.0f;

    private float _currentTime = 0.0f;

    [SerializeField]
    private float _pipeRandomHeight = 0.4f;
    [SerializeField]
    private float _pipeRandomPositionY = 0.5f;

    public List<Pipe> _pipeList = new List<Pipe>();
    public List<Pipe> _pipeDelete = new List<Pipe>();

    private bool _bPlay = false;
    private int _score = 0;
    private int _highScore = 0;
    private bool _bCurrentHighScore = false;

    public int Score {  get { return _score;  } }
    public int HighScore {  get { return _highScore;  } }
    public bool iscurrentBestScore {  get { return _bCurrentHighScore;  } }

    public bool isPlay {
        get { return _bPlay; }
        set {
            _bPlay = value;
            if( !_bPlay )
            {
                UIManager.Instance.InvokeGameOver();
            }
        }
    }

    public float Speed { get { return _speed; } }

    public void Replay()
    {
        Init();
        UIManager.Instance.ShowScore();
        _bPlay = true;
    }

    private void Init()
    {
        Debug.Log("Init:" + _bCurrentHighScore);
        _bCurrentHighScore = false;
        _bPlay = false;
        _score = 0;
        _currentTime = 0.0f;
        _bird.transform.position = new Vector3(-2.29f, 0.6f, 0);
        _ground.transform.position = new Vector3(0.05f, -4.58f, 0);
        foreach (Pipe pipe in _pipeList)
        {
            Destroy(pipe.gameObject);
        }
        _pipeList.Clear();

        UIManager.Instance.Init();

    }


    private void Start()
    {
        Init();
        UIManager.Instance.ShowTitle();
        _highScore = PlayerPrefs.GetInt("_bestScore");
    }

    // Update is called once per frame
    void Update()
    {
        _bird.FreezePositionY(!_bPlay);
        if(_bPlay)
        {
            _currentTime += Time.deltaTime;
            if(_createTime < _currentTime)
            {
                Pipe tmp = GameObject.Instantiate(_pipe);
                _currentTime = 0.0f;
                //tmp.SetHeight(Random.Range(0.0f, _pipeRandomHeight));
                tmp.SetPositionY(Random.Range(0.0f, _pipeRandomPositionY));
                tmp.SetLocation();
                // Pipe tmp = GameObject.Instantiate(_pipe);
                Transform tmp2 = tmp.transform;
                Transform tmp3 = tmp._topPipe.transform;

                _pipeList.Add(tmp);
            }

            _bird.GameUpdate();
            _ground.GameUpdate();
            _pipeList.ForEach((x) =>
            {
                x.GameUpdate();
                if(x.isScoreCheck(_bird.transform.position) )
                {
                    InvokeScore();
                }
            }
            );

            UpdateRemove();

            // _pipe.GameUpdate();
        }

    }

    void UpdateRemove()
    {
        if (_pipeDelete.Count > 0)
        {
            _pipeList.RemoveAll(_pipeDelete.Contains);
            foreach (Pipe pipe in _pipeDelete)
            {
                // _pipeList.Remove(pipe);
                Destroy(pipe.gameObject);
            }
            _pipeDelete.Clear();
        }
    }

    public void Remove(Pipe target)
    {
        _pipeDelete.Add(target);
        
    }

    // 
    private void InvokeScore() 
    {
        _score++;
        if(_highScore < _score)
        {
            Debug.Log("InvokeScore:" + _bCurrentHighScore);

            _bCurrentHighScore = true;
            _highScore = _score;

            PlayerPrefs.SetInt("_bestScore", _highScore);
            PlayerPrefs.Save();
        }

        UIManager.Instance.Score = _score;
        Debug.Log(_score);

    }
}
