using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumberRenderer : MonoBehaviour
{
   // [SerializeField]
    [Range(0, 9)]
    private int _value;

    [SerializeField]
    private Image _image = null;

    [SerializeField]
    private Sprite[] _sprites = new Sprite[10];

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

    // Update is called once per frame
    void Render()
    {
        if (0 <= _value  && _value < _sprites.Length) {
            _image.sprite = _sprites[_value];
        }
    }
}
