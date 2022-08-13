using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EmirhanErdgn;


public class GridComponent : MonoBehaviour
{
    [SerializeField] private EColorType m_colorType;
    [SerializeField] private SpriteRenderer m_spriteRenderer;

    private void Start()
    {
        SetSpriteMaterial();
    }
    public void SetSpriteMaterial()
    {
        if (m_colorType.Equals(EColorType.FIRSTCOLOR))
        {
            m_spriteRenderer.material = ThemeManager.Instance.GetFirstSpriteMaterial();
        }
        else if (m_colorType.Equals(EColorType.SECONDCOLOR))
        {
            m_spriteRenderer.material = ThemeManager.Instance.GetSecondSpriteMaterial();
        }

    }

    public EColorType GetColorType()
    {
        return m_colorType;
    }

}
