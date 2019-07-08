using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MoveObject
{
    //    [SerializeField]
    //    public float _startPositionX = 0.05f;
    //    [SerializeField]
    //    public float _endPositionX = -0.014f;

    [SerializeField]
    public GameObject _topPipe = null;
    [SerializeField]
    public GameObject _downpPipe = null;

    // TOP pipe의 y
    private float _defaultTopPositionY = 0.0f;
    // pipe 의 y
    private float _defaultBasePositionY = 0.0f;

    private bool _bCheck = false;

    public void SetLocation()
    {
        float tmp = 0;
        float up_min = 2.5f;
        float up_max = 8f;

        float down_min = -6.5f;
        float down_max = 0f;

        float min = 1.6f;
        float max = 4;

        float height = Random.Range(min, max);

        float up_x = Random.Range(up_min, up_max);
        float down_x = up_x - 7 - height;

        if(down_x < down_min)
        {
            tmp = down_min - down_x;
            down_x = down_min;
            up_x = up_x + tmp;
        }

        Vector3 topPipe = _topPipe.transform.localPosition;
        Vector3 downPipe = _downpPipe.transform.localPosition;
        topPipe.y = up_x;
        downPipe.y = down_x;

        _topPipe.transform.localPosition = topPipe;
        _downpPipe.transform.localPosition = downPipe;

    }

    // Start is called before the first frame update
    void Start()
    {
        _defaultTopPositionY = _topPipe.transform.localPosition.y;
        _defaultBasePositionY = transform.position.y;
    }

    public void SetHeight(float value)
    {
        // 왜 _topPipe값이 Null인가?
        if (_topPipe == null)
        {
      //      _topPipe = this.gameObject.transform.Find("pipe2").gameObject;
        }
        Debug.Log(_topPipe);
        Vector3 result = _topPipe.transform.localPosition;
        result.y = value + _defaultTopPositionY;

        _topPipe.transform.localPosition = result; //  new Vector3(0, value + _defaultTopPositionY, 0);
    }

    public void SetPositionY(float value)
    {
        Vector3 result = transform.position;
        result.y = value + _defaultBasePositionY;

        transform.position = result; 
    }

    override public void GameUpdate()
    {
        base.GameUpdate();
    }

    override protected void FinishEndPosition()
    {
        Debug.Log("Remove Object");
        Manager.Instance.Remove(this);
    }


    public bool isScoreCheck(Vector3 target)
    {
        if( !_bCheck )
        {
            if(transform.position.x <= target.x )
            {
                _bCheck = true;
                return true;
            }
        }
        return false;
    }
}
