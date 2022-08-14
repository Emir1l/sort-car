using UnityEngine;

namespace EmirhanErdgn
{
    [CreateAssetMenu(menuName = "EmirhanErdgn/Default/GameSettings", fileName = "GameSettings", order = 0)]
    public class GameSettings : ScriptableObject
    {
        [Header("Speed")]
        [Range(0, 10)] public float BarrierSpeed;

        [Header("Datas")]
        [ContextMenuItem("Update", "FindLevels")]
        public Level[] Levels;

    }
}