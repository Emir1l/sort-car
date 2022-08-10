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

            GetFirstMaterial().color = theme.FirstColor;
            GetFirstAlternativeMaterial().color = theme.FirstAlternaiveColor;
            GetFirstSpriteMaterial().color = theme.FirstColor;

            GetSecondMaterial().color = theme.SecondColor;
            GetSecondAlternativeMaterial().color = theme.SecondAlternativeColor;
            GetSecondSpriteMaterial().color = theme.SecondColor;
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
            return FirstColor[2];
        }
        public Material GetSecondSpriteMaterial()
        {
            return SecondColor[2];
        }

        public Material GetFirstAlternativeMaterial()
        {
            return FirstColor[1];
        }
        public Material GetSecondAlternativeMaterial()
        {
            return SecondColor[1];
        }
    }
}