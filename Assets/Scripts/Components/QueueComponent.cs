using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EmirhanErdgn;
using DG.Tweening;
using System.Linq;

public class QueueComponent : MonoBehaviour
{
    [Header("Transforms")]
    [SerializeField] private Transform FirstPoint;
    [SerializeField] private Transform SecondPoint;
    [SerializeField] private Transform BasePoint;
    [Header("Color")]
    [SerializeField] private EColorType m_colorType;
    private Level currentLevel => GameManager.Instance.GetCurrentLevel();
    private LevelComponent levelComponent=>LevelComponent.Instance;

    private void Start()
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
    private void FirstColorCarCreate()
    {
        for (int i = 0; i < currentLevel.FirstCarAmount; i++)
        {
            int rndIndex = Random.Range(0, currentLevel.FirstColorCars.Count);
            GameObject Car= Instantiate(currentLevel.FirstColorCars[rndIndex], BasePoint);
            levelComponent.FirstCarAdd(Car.GetComponent<CarComponent>());
        }
    }
    private void SecondColorCarCreate()
    {
        for (int i = 0; i < currentLevel.SecondCarAmount; i++)
        {
            int rndIndex = Random.Range(0, currentLevel.SecondColorCars.Count);
            GameObject Car = Instantiate(currentLevel.SecondColorCars[rndIndex], BasePoint);
            levelComponent.SecondCarAdd(Car.GetComponent<CarComponent>());
        }
    }

    private void ParkedFirstCars()
    {
        levelComponent.GetFirstCars()[0].transform.DOMove(FirstPoint.position, 1f);
        levelComponent.GetFirstCars()[1].transform.DOMove(SecondPoint.position, 2f);
    }
    private void ParkedSecondCars()
    {
        levelComponent.GetSecondCars()[0].transform.DOMove(FirstPoint.position, 1f);
        levelComponent.GetSecondCars()[1].transform.DOMove(SecondPoint.position, 2f);
    }

    public CarComponent FirstCarMove()
    {
       CarComponent car=levelComponent.GetFirstCars().FirstOrDefault();
        levelComponent.GetFirstCars().Remove(car);
        return car;
    }
    public CarComponent SecondCarMove()
    {
        CarComponent car = levelComponent.GetSecondCars().FirstOrDefault();
        levelComponent.GetSecondCars().Remove(car);
        
        return car;
    }


}
