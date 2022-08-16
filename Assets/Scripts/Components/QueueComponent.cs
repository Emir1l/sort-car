using UnityEngine;
using EmirhanErdgn;
using DG.Tweening;
using System.Linq;

public class QueueComponent : MonoBehaviour
{
    #region Serializable Fields
    [Header("Transforms")]
    [SerializeField] private Transform FirstPoint;
    [SerializeField] private Transform SecondPoint;
    [SerializeField] private Transform BasePoint;
    [Header("Color")]
    [SerializeField] private EColorType m_colorType;
    #endregion

    #region Private Fields
    private Level currentLevel => GameManager.Instance.GetCurrentLevel();
    private LevelComponent levelComponent => LevelComponent.Instance;
    #endregion

    /// <summary>
    /// Initialize
    /// </summary>
    public void Initalize()
    {
        switch (m_colorType)
        {
            case EColorType.FIRSTCOLOR:
                FirstColorCarCreate();
                ParkedFirstCars();
                break;
            case EColorType.SECONDCOLOR:
                SecondColorCarCreate();
                ParkedSecondCars();
                break;
            default:
                break;
        }

    }

    /// <summary>
    /// This Function Helper For Instantiate Car.
    /// </summary>
    private void FirstColorCarCreate()
    {
        for (int i = 0; i < currentLevel.FirstCarAmount; i++)
        {
            int rndIndex = Random.Range(0, currentLevel.FirstColorCars.Count);
            GameObject Car = Instantiate(currentLevel.FirstColorCars[rndIndex], BasePoint);
            levelComponent.FirstCarAdd(Car.GetComponent<CarComponent>());
        }
    }

    /// <summary>
    /// This Function Helper For Instantiate Car.
    /// </summary>
    private void SecondColorCarCreate()
    {
        for (int i = 0; i < currentLevel.SecondCarAmount; i++)
        {
            int rndIndex = Random.Range(0, currentLevel.SecondColorCars.Count);
            GameObject Car = Instantiate(currentLevel.SecondColorCars[rndIndex], BasePoint);
            levelComponent.SecondCarAdd(Car.GetComponent<CarComponent>());
        }
    }

    /// <summary>
    /// This Function Helper For Parked Awake.
    /// </summary>
    private void ParkedFirstCars()
    {
        levelComponent.GetCars(EColorType.FIRSTCOLOR)[0].transform.DOMove(FirstPoint.position, 1f);
        levelComponent.GetCars(EColorType.FIRSTCOLOR)[1].transform.DOMove(SecondPoint.position, 2f);
    }

    /// <summary>
    /// This Function Helper For Parked Awake.
    /// </summary>
    private void ParkedSecondCars()
    {
        levelComponent.GetCars(EColorType.SECONDCOLOR)[0].transform.DOMove(FirstPoint.position, 1f);
        levelComponent.GetCars(EColorType.SECONDCOLOR)[1].transform.DOMove(SecondPoint.position, 2f);
    }

    /// <summary>
    /// This Function Helper For Car Queue Move.
    /// </summary>
    /// <param name="type"></param>
    public void QueueMove(EColorType type)
    {
        DOVirtual.DelayedCall(0.75f, () =>
        {
            CarComponent car = levelComponent.GetCars(type).FirstOrDefault();
            if (car is null) return;
            car.transform.DOMove(FirstPoint.position, 0.5f);
            if (levelComponent.GetCars(type).Count < 2) return;
            CarComponent car2 = levelComponent.GetCars(type)[1];
            if (car2 is null) return;
            car2.transform.DOMove(SecondPoint.position, 0.8f);
        });
        

    }


}
