using UnityEngine;

namespace EmirhanErdgn
{
    [CreateAssetMenu(menuName = "EmirhanErdgn/Default/Theme", fileName = "Theme", order = 3)]
    public class Theme : ScriptableObject
    {
        [Header("Materials")]
        public Material SkyBox;

        [Header("First Color")]
        public Color FirstColor;
        public Color FirstAlternaiveColor;

        [Header("First Color")]
        public Color SecondColor;
        public Color SecondAlternativeColor;
    }
}