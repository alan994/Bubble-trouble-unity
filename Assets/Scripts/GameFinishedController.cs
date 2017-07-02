using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameFinishedController : MonoBehaviour {

	public void GoBackToMainMenu()
    {
        SceneManager.LoadScene(NameHelper.SceneMainManuIndex);
    }
}
