using UnityEngine;
using UnityEngine.UI;
using Logic;

public class ControlsManager : MonoBehaviour
{
    [SerializeField]
    MapManager mapManager;

    [SerializeField]
    Button turnRightButton;
    // Start is called before the first frame update
    void Start()
    {
        turnRightButton.onClick.AddListener(delegate{mapManager.TurnShip(TurnType.HalfRight);});
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
