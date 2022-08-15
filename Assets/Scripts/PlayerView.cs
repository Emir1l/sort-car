using UnityEngine;
using EmirhanErdgn;
using System.Linq;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using System;

public class PlayerView : MonoBehaviour
{
    // arabalar platform alt?nda gidiyor düzelt
    // kodlar? gözden geçir ve comment ekle



    private bool isPlaying = true;
    void Update()
    {
        PressButton();
        _ = IsComplete();
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

        _ = car.Move(TargetGrid.GetTargetTransforms(CurrentColor), TargetGrid);
        TargetGrid.SetEmpty(false);
        LevelComponent.Instance.GetCars(CurrentColor).Remove(car);
        LevelComponent.Instance.GetQueues(CurrentColor).QueueMove(CurrentColor);


    }
    private async UniTask IsComplete()
    {
        await UniTask.WaitForEndOfFrame();

        if (isPlaying is false) return;

        GridComponent grid = LevelComponent.Instance.GetGrids().FirstOrDefault(x => x.GetEmpty() == true);
        if (grid is null)
        {
            Debug.Log("dawd");
            GridComponent Grid = LevelComponent.Instance.GetGrids().FirstOrDefault(x => x.GetIsCorrect() == false);
            if (Grid is null)
            {

                //kazand?n
                //araba scale punch
                Debug.Log("kazand?n");
                LevelComponent.Instance.GetCars().ForEach(x => x.PunchScale());
                isPlaying = false;
                GameUtils.SwitchCanvasGroup(null, InterfaceManager.Instance.GetWinGroup());
            }
        }
    }

}
