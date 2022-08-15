using UnityEngine;
using EmirhanErdgn;
using System.Linq;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using System;

public class PlayerView : MonoBehaviour
{
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
        DOVirtual.DelayedCall(3.5f, () => { TargetGrid.SetEmpty(false); });
        LevelComponent.Instance.GetCars(CurrentColor).Remove(car);
        LevelComponent.Instance.GetQueues(CurrentColor).QueueMove(CurrentColor);


    }
    private async UniTask IsComplete()
    {
        await UniTask.Delay(TimeSpan.FromSeconds(5f));
        if (isPlaying is false) return;

        GridComponent grid = LevelComponent.Instance.GetGrids().FirstOrDefault(x => x.GetEmpty() == true);
        if (grid is null)
        {
            GridComponent Grid = LevelComponent.Instance.GetGrids().FirstOrDefault(x => x.GetIsCorrect() == false);
            if (Grid is null)
            {

                //kazand?n
                //araba scale punch
                Debug.Log("asdasd");
                LevelComponent.Instance.GetCars(EColorType.FIRSTCOLOR).ForEach(x => x.PunchScale());
                LevelComponent.Instance.GetCars(EColorType.SECONDCOLOR).ForEach(x => x.PunchScale());
                isPlaying = false;
                //win ekran?
            }
            else
            {
                Debug.Log("aaaann");
                //kaybettin
                //lose ekran?
            }
        }



    }

    //  oyunu kazanma ve kaybetme fonksiyonlar?. araban?n üzerinde tik ç?kmas? yada çarp? ç?kmas? oyunu kazanma
    // ve kaybetme fonksiyonu her butona bas?ld?ktan sonra kontrol edilecek

}
