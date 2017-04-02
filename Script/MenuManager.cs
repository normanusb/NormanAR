using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour {

    public void OnplayButtonClick()
    {
        GameManager.Instance.ChangeScene("Game");
    }

}
