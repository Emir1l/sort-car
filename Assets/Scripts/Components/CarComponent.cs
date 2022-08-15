using System.Collections.Generic;
using UnityEngine;
using EmirhanErdgn;
using DG.Tweening;
using Cysharp.Threading.Tasks;
public class CarComponent : MonoBehaviour
{
    [SerializeField] private EColorType m_colorType;
    [SerializeField] private CanvasGroup m_group;
    [SerializeField] private Canvas m_canvas;


    private Level level => GameManager.Instance.GetCurrentLevel();

    public EColorType GetCarType()
    {
        return m_colorType;
    }
    public void SetCarType(EColorType Type)
    {
        m_colorType = Type;
    }
    public async UniTask Move(List<Transform> TargetTranforms, GridComponent CurrentGrid)
    {
        int targetRoadIndex = 0;
        while (true)
        {
            if (DOTween.IsTweening(GetInstanceID()))
            {
                await UniTask.WaitForEndOfFrame();
                continue;
            }
            Transform TargetTransform = TargetTranforms[targetRoadIndex];
            if (TargetTransform is null) break;
            Sequence sequence = DOTween.Sequence();
            Vector3 direction = TargetTransform.position - this.transform.position;
            sequence.Join(transform.DOMove(TargetTransform.position, level.CarSpeed / 3f).SetEase(Ease.InOutSine));
            sequence.Join(transform.DOLocalRotateQuaternion(Quaternion.LookRotation(direction), 0.0625f).SetEase(Ease.InOutSine));

            sequence.SetId(GetInstanceID());
            sequence.Play();
            targetRoadIndex++;
            if (targetRoadIndex >= TargetTranforms.Count)
            {
                DOVirtual.DelayedCall(level.CarSpeed / 3f, () =>
                {
                    if (CurrentGrid.GetColorType() == m_colorType)
                    {
                        CanvasLookCamera();
                        CurrentGrid.SetCorrect(true);
                    }
                });
                break;
            }
        }

    }

    public void PunchScale()
    {
        transform.DOPunchScale(transform.localScale * 0.06f, 2f,1);

    }
    public void CanvasLookCamera()
    {
        Vector3 direction = Camera.main.transform.position - transform.position;
        m_canvas.transform.rotation = Quaternion.LookRotation(direction);
        GameUtils.SwitchCanvasGroup(null, m_group, 0.1f);
        m_canvas.transform.DOPunchRotation(Vector3.up * 20, 2f, 1);

    }


}
