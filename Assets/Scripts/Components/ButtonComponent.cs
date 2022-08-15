using UnityEngine;
using DG.Tweening;
using EmirhanErdgn;

public class ButtonComponent : MonoBehaviour
{
    #region Serializable Fields
    [SerializeField] private Transform m_pushButton;
    [SerializeField] private EColorType m_colorType;
    #endregion

    #region Private Fields
    private bool IsComplete = true;
    private Level level => GameManager.Instance.GetCurrentLevel();
    #endregion

    #region Function
    /// <summary>
    /// This Function Helper For Push Button.
    /// </summary>
    public void PushButton()
    {
        if (IsComplete is false) return;

        Sequence sequence = DOTween.Sequence();
        sequence.Join(m_pushButton.DOLocalMove(m_pushButton.localPosition + (Vector3.down * 3f), level.StrokeRate / 10f));
        sequence.OnStart(() =>
        {
            IsComplete = false;
        });
        sequence.OnComplete(() =>
        {
            m_pushButton.DOLocalMove(m_pushButton.localPosition + (Vector3.up * 3f), level.StrokeRate / 10f);
            DOVirtual.DelayedCall((level.StrokeRate / 10f)+0.1f, () =>
            {
                IsComplete = true;
            });
        });

        sequence.Play();

    }
    #endregion

    #region Getters
    /// <summary>
    /// This Function Return Button Color Type.
    /// </summary>
    /// <returns></returns>
    public EColorType GetColorType()
    {
        return m_colorType;
    }

    /// <summary>
    /// This Function Return Is Complete.
    /// </summary>
    /// <returns></returns>
    public bool GetComplete()
    {
        return IsComplete;
    }
    #endregion
}
