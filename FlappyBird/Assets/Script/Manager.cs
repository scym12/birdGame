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
    public bool isPlay { get { return _bPlay; } set { _bPlay = value; } }

    public float Speed {  get { return _speed; } }



    private void Start()
    {
        _bPlay = false;
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
        // _pipeList.Remove(target);
        // Destroy(target.gameObject);
        
    }

    private void InvokeScore() 
    {
        _score++;
        UIManager.Instance.Score = _score;
        Debug.Log(_score);

    }
}
