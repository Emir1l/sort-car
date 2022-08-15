using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EmirhanErdgn;

public class InterfaceManager : Singleton<InterfaceManager>
{
    [SerializeField] private CanvasGroup m_winGroup;

    public CanvasGroup GetWinGroup()
    {
        return m_winGroup;
    }
    
}
