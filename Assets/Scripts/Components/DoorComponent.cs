using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EmirhanErdgn;
using DG.Tweening;

public class DoorComponent : MonoBehaviour
{
    [SerializeField] private Transform m_barrier;
    [SerializeField] private EColorType m_colorType;
    private bool IsComplete = true;

    public void OpenBarrier()
    {
        if (IsComplete is false) return;

        Sequence sequence = DOTween.Sequence();
        sequence.Join(m_barrier.DOLocalRotateQuaternion(Quaternion.Euler(Vector3.back * 90), GameManager.Instance.GetGameSettings().BarrierSpeed / 10f));
        sequence.OnStart(() =>
        {
            IsComplete = false;
        });
        sequence.OnComplete(() =>
        {
            m_barrier.DOLocalRotateQuaternion(Quaternion.Euler(Vector3.zero), GameManager.Instance.GetGameSettings().BarrierSpeed / 10f);
            DOVirtual.DelayedCall(0.75f, () =>
            {
                IsComplete = true;
            });
        });

        sequence.Play();
    }
    public EColorType GetColorType()
    {
        return m_colorType;
    }
}


