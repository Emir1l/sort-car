using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EmirhanErdgn;
using DG.Tweening;

public class DoorComponent : MonoBehaviour
{
    #region Serializable Fields
    [SerializeField] private Transform m_barrier;
    [SerializeField] private EColorType m_colorType;
    #endregion

    #region Private Fields
    private bool IsComplete = true;
    private Level level => GameManager.Instance.GetCurrentLevel();
    #endregion

    /// <summary>
    /// This Function Helper For Open Barrier
    /// </summary>
    public void OpenBarrier()
    {
        if (IsComplete is false) return;

        Sequence sequence = DOTween.Sequence();
        sequence.Join(m_barrier.DOLocalRotateQuaternion(Quaternion.Euler(Vector3.back * 90), level.BarrierOpenSpeed / 10f));
        sequence.OnStart(() =>
        {
            IsComplete = false;
        });
        sequence.OnComplete(() =>
        {
            m_barrier.DOLocalRotateQuaternion(Quaternion.Euler(Vector3.zero), level.BarrierCloseSpeed / 10f);
            DOVirtual.DelayedCall(0.75f, () =>
            {
                IsComplete = true;
            });
        });

        sequence.Play();
    }

    #region Getters
    /// <summary>
    /// This Function Returns Color Type.
    /// </summary>
    /// <returns></returns>
    public EColorType GetColorType()
    {
        return m_colorType;
    }

    /// <summary>
    /// This Function Returns Complete Value.
    /// </summary>
    /// <returns></returns>
    public bool GetComplete()
    {
        return IsComplete;
    }
    #endregion
}


