using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EmirhanErdgn;


public class GridComponent : MonoBehaviour
{
    [SerializeField] private EColorType m_colorType;
    [SerializeField] private SpriteRenderer m_spriteRenderer;
    [SerializeField] private List<Transform> m_Firstpoints=new List<Transform>();
    [SerializeField] private List<Transform> m_Secondpoints=new List<Transform>();
    [SerializeField] private int m_firstPriorityValue;
    [SerializeField] private int m_secondPriorityValue;
    [SerializeField] private bool IsEmpty = true;

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

    public List<Transform> GetTargetTransforms(EColorType type)
    {
        if (type.Equals(EColorType.FIRSTCOLOR))
        {
            Debug.Log("baban?");
            return m_Firstpoints;
        }
        else if (type.Equals(EColorType.SECONDCOLOR))
        {
            Debug.Log("anan?");
            return m_Secondpoints;
        }
        else
        {
            return null;
        }
       
    }

    public bool GetEmpty()
    {
        
        return IsEmpty;
    }
    public int GetfirstPriority()
    {
        return m_firstPriorityValue;
    }
    public int GetSecondPriority()
    {
        return m_secondPriorityValue;
    }
    public List<Transform> GetFirstTransforms()
    {
        return m_Firstpoints;
    }
    public List<Transform> GetSecondTransforms()
    {
        return m_Secondpoints;
    }

}
