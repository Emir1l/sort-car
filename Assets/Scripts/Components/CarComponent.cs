using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EmirhanErdgn;

public class CarComponent : MonoBehaviour
{
    [SerializeField] private EColorType m_colorType;

    public EColorType GetCarType()
    {
        return m_colorType;
    }
    public void SetCarType(EColorType Type)
    {
        m_colorType = Type;
    }
}
