using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour, IGameObject
{
    [SerializeField]
    private Rigidbody2D _rigidbody = null;

    [SerializeField]
    private float _jumpValue = 1.0f; 

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody.constraints = RigidbodyConstraints2D.FreezePositionY;
    }

    public void FreezePositionY( bool value )
    {
        _rigidbody.constraints = value ? RigidbodyConstraints2D.FreezePositionY : RigidbodyConstraints2D.None;
    }
     
    public void GameUpdate()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            _rigidbody.velocity = Vector2.up * _jumpValue;
            // _rigidbody.AddForce(new Vector2(0, _jumpValue));
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log(collision.gameObject.tag);
        switch(collision.gameObject.tag)
        {
            case "Enemy":
                Manager.Instance.isPlay = false;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
 