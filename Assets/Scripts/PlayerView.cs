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
            DoorComponent door = LevelComponent.Instance.GetDoors().SingleOrDefault(x => x.GetColorType() == CurrentColor);
            if (button.GetComplete() is false || door.GetComplete() is false) return;
            button.PushButton();
            door.OpenBarrier();

            CarMove(CurrentColor);

        }
    }
    private void CarMove(EColorType CurrentColor)
    {
        GridComponent TargetGrid = LevelComponent.Instance.GetPoints(CurrentColor).FirstOrDefault(x => x.GetEmpty() == true);
        CarComponent car = LevelComponent.Instance.GetCars(CurrentColor).FirstOrDefault();

        if (car is null || TargetGrid is null) return;

        _ = car.Move(TargetGrid.GetTargetTransforms(CurrentColor));
        TargetGrid.SetEmpty(false);
        LevelComponent.Instance.GetCars(CurrentColor).Remove(car);
    }

    // aralar?n s?rayla öne gelmesi oyunu kazanma ve kaybetme fonksiyonlar?. aç? düzeltmeleri. 

}
