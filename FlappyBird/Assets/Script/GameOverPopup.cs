﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverPopup : MonoBehaviour
{



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Show()
    {
        gameObject.SetActive(true);
        
    }

    public void OkButton()
    {
        gameObject.SetActive(false);
        Manager.Instance.Replay();
    }
}
