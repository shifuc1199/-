﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mutli_Sword_Ctr : MonoBehaviour,IAttackable
{
    public float _attack;
    public float Attack
    {
        get
        {
            return _attack;
        }
        set
        {
            _attack = value;
        }
    }

    public AttackCallBack _attackcallback
    {
        get;
        set;
    }

    public float _speed;
    public bool ismove;
    // Start is called before the first frame update
    void Start()
    {
        this._attackcallback = (t) =>
        {

           
            int a = Random.Range(1, 3);
            AudioManager._instance.PlayAudio("击中" + a);
            
        };
    }
   
    // Update is called once per frame
    void Update()
    {if (ismove) 
        transform.Translate(transform.right * _speed*Time.deltaTime, Space.World);
    
    }
}
