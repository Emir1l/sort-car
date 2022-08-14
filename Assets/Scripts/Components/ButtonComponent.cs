using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using EmirhanErdgn;

public class ButtonComponent : MonoBehaviour
{
    [SerializeField] private Transform m_pushButton;
    [SerializeField] private EColorType m_colorType;
    private bool IsComplete = true;
    public void PushButton()
    {
        if (IsComplete is false) return;

        Sequence sequence = DOTween.Sequence();
        sequence.Join(m_pushButton.DOLocalMove(m_pushButton.localPosition + (Vector3.down * 3f), 0.5f));
        sequence.OnStart(() =>
        {
            IsComplete = false;
        });
        sequence.OnComplete(() =>
        {
            m_pushButton.DOLocalMove(m_pushButton.localPosition + (Vector3.up * 3f), 0.5f);
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
    public bool GetComplete()
    {
        return IsComplete;
    }
}
