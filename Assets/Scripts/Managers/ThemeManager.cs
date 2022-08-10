using UnityEngine;

namespace EmirhanErdgn
{
    public class ThemeManager : Singleton<ThemeManager>
    {
        [SerializeField] private Material[] FirstColor;
        [SerializeField] private Material[] SecondColor;
        /// <summary>
        /// This function helper for initialize theme to the world.
        /// </summary>
        /// <param name="theme"></param>
        public void Initialize(Theme theme)
        {
            RenderSettings.skybox = theme.SkyBox;
            foreach(Material material in FirstColor) { material.color = theme.FirstColor; }
            foreach(Material material in SecondColor) { material.color = theme.SecondColor; }
        }
        public Material GetFirstMaterial()
        {
            return FirstColor[0];
        }
        public Material GetSecondMaterial()
        {
            return SecondColor[0];
        }
        public Material GetFirstSpriteMaterial()
        {
            return FirstColor[1];
        }
        public Material GetSecondSpriteMaterial()
        {
            return SecondColor[1];
        }
    }
}