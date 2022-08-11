using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EmirhanErdgn;


public class GridComponent : MonoBehaviour
{
    [SerializeField] private EGridType m_gridType;
    [SerializeField] private SpriteRenderer m_spriteRenderer;

    private void Start()
    {
        SetSpriteMaterial();
    }
    public void SetSpriteMaterial()
    {
        if (m_gridType.Equals(EGridType.FIRSTCOLOR))
        {
            m_spriteRenderer.material = ThemeManager.Instance.GetFirstSpriteMaterial();
        }
        else if (m_gridType.Equals(EGridType.SECONDCOLOR))
        {
            m_spriteRenderer.material = ThemeManager.Instance.GetSecondSpriteMaterial();
        }
       
    }
    
}
