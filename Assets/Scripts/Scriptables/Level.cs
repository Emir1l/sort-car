using System.Collections.Generic;
using UnityEngine;

namespace EmirhanErdgn
{
    [CreateAssetMenu(menuName = "EmirhanErdgn/Default/Level", fileName = "Level", order = 1)]
    public class Level : ScriptableObject
    {
        [Header("General")]
        public int Id;
        public string SceneName;
        public Theme Theme;
        [Header("Cars")]
        public int FirstCarAmount;
        public int SecondCarAmount;
        public List<GameObject> FirstColorCars;
        public List<GameObject> SecondColorCars;


    }
}