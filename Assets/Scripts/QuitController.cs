using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitController : MonoBehaviour
{
    public void OnMouseDown()
    {
        SceneManager.LoadScene("StartScreen");
    }
}
