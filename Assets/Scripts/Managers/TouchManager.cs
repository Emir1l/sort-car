using UnityEngine;

namespace EmirhanErdgn
{
    public class TouchManager : Singleton<TouchManager>
    {
        /// <summary>
        /// This function returns true if player touching screen.
        /// </summary>
        /// <returns></returns>
        public bool IsTouching()
        {
            return Input.GetMouseButton(0);
        }

        /// <summary>
        /// This function returns true if player touching up.
        /// </summary>
        /// <returns></returns>
        public bool IsTouchUp()
        {
            return Input.GetMouseButtonUp(0);
        }

        /// <summary>
        /// This function returns true if player touching down.
        /// </summary>
        /// <returns></returns>
        public bool IsTouchDown()
        {
            return Input.GetMouseButtonDown(0);
        }
    }
}