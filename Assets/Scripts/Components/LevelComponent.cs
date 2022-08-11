using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EmirhanErdgn;

public class LevelComponent : Singleton<LevelComponent>
{
    [SerializeField] private List<GridComponent> m_grids = new List<GridComponent>();
    [SerializeField] private List<CarComponent> m_cars = new List<CarComponent>();
    [SerializeField] private List<ButtonComponent> m_buttons = new List<ButtonComponent>();
}
