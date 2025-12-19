using UnityEngine;

public enum BatmanState { Normal, Stealth, Alert }

public class StateManager : MonoBehaviour
{
    private BatmanState activeState;
    private PlayerMovement movement;

    void Start()
    {
        activeState = BatmanState.Normal;
        movement = GameObject.Find("Batman").GetComponent<PlayerMovement>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
            SetState(BatmanState.Normal);

        if (Input.GetKeyDown(KeyCode.C))
            SetState(BatmanState.Stealth);

        if (Input.GetKeyDown(KeyCode.Space))
            SetState(BatmanState.Alert);
    }

    private void SetState(BatmanState state)
    {
        activeState = state;

        switch (activeState)
        {
            case BatmanState.Normal:
                movement.SetNormalSpeed();
                break;

            case BatmanState.Stealth:
                movement.SetSlowSpeed();
                break;

            case BatmanState.Alert:
                movement.SetNormalSpeed();
                break;
        }
    }
}
