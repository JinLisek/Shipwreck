using UnityEngine;
using TMPro;
using Zenject;
using Logic;

public class MovementHolder : MonoBehaviour
{
    [SerializeField]
    public TMP_Text currentMovementView;

    private Movement movement;

    [Inject]
    public void Inject(Movement movement)
    {
        this.movement = movement;
    }

    private void Start()
    {
        movement.RegisterOnCurrentMovementChangeCallback(ChangeCurrentMovementView);
    }

    private void ChangeCurrentMovementView(int newMovement)
    {
        currentMovementView.text = newMovement.ToString();
    }
}
