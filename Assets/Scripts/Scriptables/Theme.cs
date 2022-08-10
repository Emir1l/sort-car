using UnityEngine;

namespace EmirhanErdgn
{
    [CreateAssetMenu(menuName = "EmirhanErdgn/Default/Theme", fileName = "Theme", order = 3)]
    public class Theme : ScriptableObject
    {
        [Header("Materials")]
        public Material SkyBox;
        public Color FirstColor;
        public Color SecondColor;
    }
}