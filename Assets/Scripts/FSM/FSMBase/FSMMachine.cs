﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 
public class FSMMachines
{
     
    public Dictionary<string, FSMState> m_states = new Dictionary<string, FSMState>();
    public FSMState m_curretstate;
    public FSMState m_laststate;
    public FSMMachines()
    {
        m_curretstate = null;
        m_laststate = null;
    }
    public void RegisterState(FSMState state)
    {
        if(m_states.ContainsKey(state.id))
        {
            return;
        }
        m_states.Add(state.id, state);
    }
    public void ChangeState(string id)
    {
        if(!m_states.ContainsKey(id))
        {
            return;
        }
        m_laststate = m_curretstate;
        m_curretstate = m_states[id];
        if (m_laststate!=null)
        {
            m_laststate.OnExit();
        }
        m_curretstate.OnEter();
    }
    public bool NowStateIs(string id)
    {
        return m_curretstate == m_states[id];
    }
    public FSMState GetState(string id)
    {
        if (!m_states.ContainsKey(id))
        {
            return null;
        }
        return m_states[id];
    }
    public void ResetState()
    {
        m_states.Clear();
        m_laststate = null;
        m_curretstate = null;
    }
   public void Update()
    {
        if(m_curretstate!=null)
        {
            m_curretstate.OnUpdate();
        }
    }
   
}
