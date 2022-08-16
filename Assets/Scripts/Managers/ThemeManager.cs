using UnityEngine;

namespace EmirhanErdgn
{
    public class ThemeManager : Singleton<ThemeManager>
    {
        #region
        [SerializeField] private Material[] FirstColor;
        [SerializeField] private Material[] SecondColor;
        #endregion

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

        /// <summary>
        /// This Function returns Game First Material.
        /// </summary>
        /// <returns></returns>
        public Material GetFirstMaterial()
        {
            return FirstColor[0];
        }

        /// <summary>
        /// This Function returns Game Second Material.
        /// </summary>
        /// <returns></returns>
        public Material GetSecondMaterial()
        {
            return SecondColor[0];
        }

        /// <summary>
        /// This Function returns Game First Sprite Material.
        /// </summary>
        /// <returns></returns>
        public Material GetFirstSpriteMaterial()
        {
            return FirstColor[2];
        }

        /// <summary>
        /// This Function returns Game Second Sprite Material.
        /// </summary>
        /// <returns></returns>
        public Material GetSecondSpriteMaterial()
        {
            return SecondColor[2];
        }

        /// <summary>
        /// This Function Returns Game Alternative Material.
        /// </summary>
        /// <returns></returns>
        public Material GetFirstAlternativeMaterial()
        {
            return FirstColor[1];
        }

        /// <summary>
        /// This Function Returns Game Alternative Material.
        /// </summary>
        /// <returns></returns>
        public Material GetSecondAlternativeMaterial()
        {
            return SecondColor[1];
        }
    }
}