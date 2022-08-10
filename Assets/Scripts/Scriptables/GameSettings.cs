using UnityEngine;

namespace EmirhanErdgn
{
    [CreateAssetMenu(menuName = "EmirhanErdgn/Default/GameSettings", fileName = "GameSettings", order = 0)]
    public class GameSettings : ScriptableObject
    {
        [Header("General")]


        [Header("Datas")]
        [ContextMenuItem("Update", "FindLevels")]
        public Level[] Levels;

    }
}