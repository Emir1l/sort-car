using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EmirhanErdgn;
using System.Linq;

public class PlayerView : MonoBehaviour
{

    void Update()
    {
        PressButton();
    }

    private void PressButton()
    {

        //if (GameManager.Instance.GetGameState() != EGameState.STARTED) return;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Camera.main == null) return;

        if (!TouchManager.Instance.IsTouchDown()) return;

        if (Physics.Raycast(ray, out hit))
        {
            if (!hit.collider.tag.Equals(CommonTypes.BUTTON_TAG)) return;
            Debug.Log(hit.collider.gameObject.name);
            if (hit.collider.GetComponent<ButtonComponent>().GetColorType().Equals(EColorType.FIRSTCOLOR))
            {
                LevelComponent.Instance.GetButtons().FirstOrDefault().PushButton();
                Debug.Log("birinci arabalar? ç?karma yerle?time ve kap?y? açma fonksiyonu");
            }
            else if (hit.collider.GetComponent<ButtonComponent>().GetColorType().Equals(EColorType.SECONDCOLOR))
            {
                LevelComponent.Instance.GetButtons().LastOrDefault().PushButton();
                Debug.Log("ikinci arabalar? ç?karma yerle?time ve kap?y? açma fonksiyonu");

            }
        }
    }

}
