using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EmirhanErdgn;

public class InterfaceManager : Singleton<InterfaceManager>
{
    #region Seraializable Fields
    [SerializeField] private CanvasGroup m_winGroup;
    #endregion

    /// <summary>
    /// This Function Helper For Get Canvas Group.
    /// </summary>
    /// <returns></returns>
    public CanvasGroup GetWinGroup()
    {
        return m_winGroup;
    }
    
}
