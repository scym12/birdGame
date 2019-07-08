using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour, IGameObject
{
    [SerializeField]
    public float _startPositionX = 0.05f;
    [SerializeField]
    public float _endPositionX = -0.014f;

    virtual public void GameUpdate()
    {
        Move();
    }

    private void Move()
    {
        Vector3 pos = transform.position;
        pos.x -= Manager.Instance.Speed;
        if (pos.x < _endPositionX)
        {
            FinishEndPosition();
        }
        else
        {
            transform.position = pos;
            //pos.x = _startPositionX;
        }
        
    }


    virtual protected void FinishEndPosition()
    {
        transform.position = new Vector3(_startPositionX, transform.position.y, 0);
    }
}
