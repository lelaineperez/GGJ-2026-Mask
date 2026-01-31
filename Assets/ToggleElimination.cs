using UnityEngine;

public class ToggleElimination : MonoBehaviour
{
    public GameObject crossOut; 

    public void Toggle()
    {
        crossOut.SetActive(!crossOut.activeSelf);
    }
}
