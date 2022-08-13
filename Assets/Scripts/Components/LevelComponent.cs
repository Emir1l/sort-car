using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EmirhanErdgn;
using System.Linq;

public class LevelComponent : Singleton<LevelComponent>
{
    #region Serializable Fields
    [SerializeField] private List<GridComponent> m_grids = new List<GridComponent>();
    [SerializeField] private List<ButtonComponent> m_buttons = new List<ButtonComponent>();
    [SerializeField] private List<CarComponent> m_Firstcars = new List<CarComponent>();
    [SerializeField] private List<CarComponent> m_Secondcars = new List<CarComponent>();
    #endregion
    #region Private Fields
    #endregion


    #region Setters
    public void FirstCarAdd(CarComponent Car)
    {
        m_Firstcars.Add(Car);
    }
    public void SecondCarAdd(CarComponent Car)
    {
        m_Secondcars.Add(Car);
    }

    #endregion

    #region Getters
    public List<GridComponent> GetGrids()
    {
        return m_grids;
    }
    public List<ButtonComponent> GetButtons()
    {
        return m_buttons;
    }
    public List<CarComponent> GetFirstCars()
    {
        return m_Firstcars;
    }
    public List<CarComponent> GetSecondCars()
    {
        return m_Secondcars;
    }

    #endregion



}

