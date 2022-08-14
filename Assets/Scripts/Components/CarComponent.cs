using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EmirhanErdgn;
using DG.Tweening;
using Cysharp.Threading.Tasks;

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
    public async UniTask Move(List<Transform> TargetTranforms)
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
            Vector3 direction = this.transform.position - TargetTransform.position;
            sequence.Join(transform.DOMove(TargetTransform.position, 1f).SetEase(Ease.InOutSine));
            sequence.Join(transform.DORotateQuaternion(Quaternion.LookRotation(-direction), 0.1f).SetEase(Ease.InOutSine));

            sequence.SetId(GetInstanceID());
            sequence.Play();
            targetRoadIndex++;
            if (targetRoadIndex >= TargetTranforms.Count) { break; }



        }
    }
}
