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
    [SerializeField] private List<GridComponent> m_firstColorPoints = new List<GridComponent>();
    [SerializeField] private List<GridComponent> m_secondColorPoints = new List<GridComponent>();
    [SerializeField] private List<QueueComponent> m_queues = new List<QueueComponent>();
    #endregion

    #region Private Fields
    private List<CarComponent>m_cars = new List<CarComponent>();
    private List<CarComponent> m_Firstcars = new List<CarComponent>();
    private List<CarComponent> m_Secondcars = new List<CarComponent>();
    #endregion

    #region Setters
    /// <summary>
    /// This Function Helper For Added Car.
    /// </summary>
    /// <param name="Car"></param>
    public void FirstCarAdd(CarComponent Car)
    {
        m_Firstcars.Add(Car);
        m_cars.Add(Car);
    }

    /// <summary>
    /// This Function Helper For Added Car.
    /// </summary>
    /// <param name="Car"></param>
    public void SecondCarAdd(CarComponent Car)
    {
        m_Secondcars.Add(Car);
        m_cars.Add(Car);
    }
    #endregion

    #region Getters

    /// <summary>
    /// This Function Return Grids.
    /// </summary>
    /// <returns></returns>
    public List<GridComponent> GetGrids()
    {
        return m_grids;
    }

    /// <summary>
    /// This Function Return Buttons.
    /// </summary>
    /// <returns></returns>
    public List<ButtonComponent> GetButtons()
    {
        return m_buttons;
    }

    /// <summary>
    /// This Function Return Doors.
    /// </summary>
    /// <returns></returns>
    public List<DoorComponent> GetDoors()
    {
        return m_doors;
    }

    /// <summary>
    /// This Funciton Returns Cars.
    /// </summary>
    /// <param name="type"></param>
    /// <returns></returns>
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

    /// <summary>
    /// This Function Return Points
    /// </summary>
    /// <param name="type"></param>
    /// <returns></returns>
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

    /// <summary>
    /// This Function Return Queues
    /// </summary>
    /// <param name="type"></param>
    /// <returns></returns>
    public QueueComponent GetQueues(EColorType type)
    {
        if (type == EColorType.FIRSTCOLOR)
        {
            return m_queues.FirstOrDefault();
        }
        else if (type == EColorType.SECONDCOLOR)
        {
            return m_queues.LastOrDefault();
        }
        else
        {
            return null;
        }
    }

    /// <summary>
    /// This Funciton Return All Cars.
    /// </summary>
    /// <returns></returns>
    public List<CarComponent> GetCars()
    {
        return m_cars;
    }
    #endregion
}

