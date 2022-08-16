using System.Collections.Generic;
using UnityEngine;
using EmirhanErdgn;


public class GridComponent : MonoBehaviour
{
    #region Serializable Fields
    [SerializeField] private EColorType m_colorType;
    [SerializeField] private SpriteRenderer m_spriteRenderer;
    [SerializeField] private List<Transform> m_Firstpoints=new List<Transform>();
    [SerializeField] private List<Transform> m_Secondpoints=new List<Transform>();
    [SerializeField] private int m_firstPriorityValue;
    [SerializeField] private int m_secondPriorityValue;
    [SerializeField] private bool IsEmpty = true;
    #endregion

    #region Private Fields
    private bool IsCorrect = false;
    #endregion

    /// <summary>
    /// Start
    /// </summary>
    /// 

    private void Start()
    {
        SetSpriteMaterial();
    }

    #region Setters
    /// <summary>
    /// This Function Edited Sprite Material
    /// </summary>
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

    /// <summary>
    /// This Function Edited Empty Value.
    /// </summary>
    /// <param name="value"></param>
    public void SetEmpty(bool value)
    {
        IsEmpty = value;
    }

    /// <summary>
    /// This Function Edited Correct Value.
    /// </summary>
    /// <param name="value"></param>
    public void SetCorrect(bool value)
    {
        IsCorrect = value;
    }
    #endregion

    #region Getters

    /// <summary>
    /// This Function Returns Related Color Type.
    /// </summary>
    /// <returns></returns>
    public EColorType GetColorType()
    {
        return m_colorType;
    }

    /// <summary>
    /// This Funciton Returns Related Target Transforms.
    /// </summary>
    /// <param name="type"></param>
    /// <returns></returns>
    public List<Transform> GetTargetTransforms(EColorType type)
    {
        if (type.Equals(EColorType.FIRSTCOLOR))
        {
            return m_Firstpoints;
        }
        else if (type.Equals(EColorType.SECONDCOLOR))
        {
            return m_Secondpoints;
        }
        else
        {
            return null;
        }
       
    }

    /// <summary>
    /// This Function Return Empty Value.
    /// </summary>
    /// <returns></returns>
    public bool GetEmpty()
    {
        
        return IsEmpty;
    }

    /// <summary>
    /// This Function Return First Priority.
    /// </summary>
    /// <returns></returns>
    public int GetfirstPriority()
    {
        return m_firstPriorityValue;
    }

    /// <summary>
    /// This Function Return Second Priority.
    /// </summary>
    /// <returns></returns>
    public int GetSecondPriority()
    {
        return m_secondPriorityValue;
    }

    /// <summary>
    /// This Function Return Correct Value.
    /// </summary>
    /// <returns></returns>
    public bool GetIsCorrect()
    {
        return IsCorrect;
    }

    /// <summary>
    /// This Function Return Transforms.
    /// </summary>
    /// <returns></returns>
    public List<Transform> GetFirstTransforms()
    {
        return m_Firstpoints;
    }

    /// <summary>
    /// This Function Return Transforms.
    /// </summary>
    /// <returns></returns>
    public List<Transform> GetSecondTransforms()
    {
        return m_Secondpoints;
    }
    #endregion 
}
