using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using EmirhanErdgn;

public class ButtonComponent : MonoBehaviour
{
    [SerializeField] private Transform m_pushButton;

    private void Start()
    {
        PushButton();
    }
    public void PushButton()
    {
        Sequence sequence = DOTween.Sequence();
        sequence.Join(m_pushButton.DOLocalMove(m_pushButton.localPosition + (Vector3.down * 2.5f), 0.75f));
        sequence.OnComplete(() =>
        {
            m_pushButton.DOLocalMove(m_pushButton.localPosition + (Vector3.up * 2.5f), 0.75f);
        });


        sequence.Play();

    }
}
