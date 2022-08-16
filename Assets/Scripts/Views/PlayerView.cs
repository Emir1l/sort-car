using UnityEngine;
using EmirhanErdgn;
using System.Linq;
using Cysharp.Threading.Tasks;

public class PlayerView : MonoBehaviour
{
    #region Private Region
    private bool isPlaying = true;
    #endregion

    void Update()
    {
        PressButton();
        _ = IsComplete();
    }

    /// <summary>
    /// This Function Helper For Press The Button
    /// </summary>
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

    /// <summary>
    /// This Function Helper For Move Car
    /// </summary>
    /// <param name="CurrentColor"></param>
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

    /// <summary>
    /// This Function Helper For Complete Level.
    /// </summary>
    /// <returns></returns>
    private async UniTask IsComplete()
    {
        await UniTask.WaitForEndOfFrame();

        if (isPlaying is false) return;

        GridComponent grid = LevelComponent.Instance.GetGrids().FirstOrDefault(x => x.GetEmpty() == true);
        if (grid is null)
        {
            GridComponent Grid = LevelComponent.Instance.GetGrids().FirstOrDefault(x => x.GetIsCorrect() == false);
            if (Grid is null)
            {
                LevelComponent.Instance.GetCars().ForEach(x => x.PunchScale());
                isPlaying = false;
                GameUtils.SwitchCanvasGroup(null, InterfaceManager.Instance.GetWinGroup());
                GameManager.Instance.ChangeGameState(EGameState.WIN);
            }
        }
    }

}
