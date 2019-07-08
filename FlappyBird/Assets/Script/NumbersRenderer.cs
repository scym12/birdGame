using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumbersRenderer : MonoBehaviour
{
    // [SerializeField]
    [Range(0, 999)]
    private int _value = 0;

    [SerializeField]
    private NumberRenderer[] _numberRenderers = new NumberRenderer[3];

    public int value
    {
        get
        {
            return _value;
        }
        set
        {
            _value = value;
            Render();
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    //void Update()
    //{
     //   Render();
    //}

    private void Render()
    {
        _numberRenderers[0].value = (int)Mathf.Floor(_value / 100.0f) % 10;
        _numberRenderers[1].value = (int)Mathf.Floor(_value / 10.0f) % 10;
        _numberRenderers[2].value = (int)Mathf.Floor(_value / 1.0f) % 10;
    }
}
