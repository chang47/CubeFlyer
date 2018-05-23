using UnityEngine;

public class GameOverCameraController : MonoBehaviour
{

    /// <summary>
    /// LateUpdate is called after all Update functions have been called. This is useful to order script execution. 
    /// For example a follow camera should always be implemented in LateUpdate because it tracks objects that might have moved inside Update.
    /// In our case, we use this to adjust our camera position after the Gvr Emulator changes the values.
    /// </summary>
    void LateUpdate()
    {
        Vector3 currentVector = transform.position;
        currentVector.z -= 30;
        transform.position = currentVector;
    }
}
