using UnityEngine;

public class UseMaze : MonoBehaviour
{
    public GameObject maze;
    public Canvas billboard;
    
    private Camera cityCamera;
    private Camera mazeCamera;

    private void OnTriggerStay2D(Collider2D other)
    {
        if (!other.transform.TryGetComponent(out CharacterController _)) return;

        if (Input.GetKeyDown(KeyCode.E))
            FocusMaze();
    }
    private void FocusMaze()
    {
        maze.SetActive(true);
        billboard.enabled = false;
        cityCamera = Camera.main;
        cityCamera.enabled = false;
        mazeCamera = maze.GetComponentInChildren<Camera>();
        mazeCamera.targetDisplay = 0;
        
        LevelManager.CurrentLevel.OnLevelCompleted += ResetCameraView;
    }

    private void ResetCameraView()
    {
        mazeCamera.targetDisplay = 1;
        cityCamera.enabled = true;
        maze.SetActive(false);
    }
}
