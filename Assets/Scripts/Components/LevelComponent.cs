using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EmirhanErdgn;
using System.Linq;

public class LevelComponent : Singleton<LevelComponent>
{
    #region Serializable Fields
    [SerializeField] private List<DoorComponent> m_doors = new List<DoorComponent>();
    [SerializeField] private List<GridComponent> m_grids = new List<GridComponent>();
    [SerializeField] private List<ButtonComponent> m_buttons = new List<ButtonComponent>();
    [SerializeField] private List<CarComponent> m_Firstcars = new List<CarComponent>();
    [SerializeField] private List<CarComponent> m_Secondcars = new List<CarComponent>();
    [SerializeField] private List<GridComponent> m_firstColorPoints = new List<GridComponent>();
    [SerializeField] private List<GridComponent> m_secondColorPoints = new List<GridComponent>();
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

    public List<DoorComponent> GetDoors()
    {
        return m_doors;
    }

    public List<CarComponent> GetCars(EColorType type)
    {
        if (type == EColorType.FIRSTCOLOR)
        {
            return m_Firstcars;
        }
        else if (type == EColorType.SECONDCOLOR)
        {
            return m_Secondcars;
        }
        else
        {
            return null;
        }
    }
    public List<GridComponent> GetPoints(EColorType type)
    {
        if (type == EColorType.FIRSTCOLOR)
        {
            return m_firstColorPoints;
        }
        else if (type == EColorType.SECONDCOLOR)
        {
            return m_secondColorPoints;
        }
        else
        {
            return null;
        }
    }

    #endregion



}

