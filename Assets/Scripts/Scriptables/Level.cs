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

        [Range(0, 10)] public float CarSpeed;

        public int FirstCarAmount;
        public int SecondCarAmount;

        public List<GameObject> FirstColorCars;
        public List<GameObject> SecondColorCars;

        [Header("Barrier")]

        [Range(0, 10)] public float BarrierOpenSpeed;
        [Range(0, 10)] public float BarrierCloseSpeed;

        [Header("Button")]

        [Range(0, 10)] public float StrokeRate;



    }
}