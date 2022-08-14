using UnityEngine;
using EmirhanErdgn;
using System.Linq;

public class PlayerView : MonoBehaviour
{
    private int FirstPriority = 0;
    private int SecondPriority = 0;

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

            EColorType CurrentColor = hit.collider.GetComponent<ButtonComponent>().GetColorType();
            ButtonComponent button = LevelComponent.Instance.GetButtons().SingleOrDefault(x => x.GetColorType() == CurrentColor);
            button.PushButton();
            LevelComponent.Instance.GetDoors().SingleOrDefault(x => x.GetColorType() == CurrentColor).OpenBarrier();

            if (CurrentColor is EColorType.FIRSTCOLOR)
            {
                GridComponent TargetGrid = LevelComponent.Instance.GetGrids().FirstOrDefault(x => x.GetEmpty() == true && x.GetfirstPriority() > FirstPriority&&x.GetColorType()==EColorType.FIRSTCOLOR);
                _ = LevelComponent.Instance.GetFirstCars().FirstOrDefault().Move(TargetGrid.GetTargetTransforms(EColorType.FIRSTCOLOR));
            }
            else if (CurrentColor is EColorType.SECONDCOLOR)
            {
                GridComponent TargetGrid = LevelComponent.Instance.GetGrids().FirstOrDefault(x => x.GetEmpty() == true && x.GetSecondPriority() > SecondPriority && x.GetColorType() == EColorType.SECONDCOLOR);
                _ = LevelComponent.Instance.GetSecondCars().FirstOrDefault().Move(TargetGrid.GetTargetTransforms(EColorType.SECONDCOLOR));
            }
        }
    }

}
