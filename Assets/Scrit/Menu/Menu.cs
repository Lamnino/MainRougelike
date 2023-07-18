using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] private int buttonCount;
    [SerializeField] private Transform buttonPlace;
    [SerializeField] Image Pointer;
    private int Selectcur = 0;
    private bool RealdyInput = true;
    private void Update()
    {

        if (Input.GetKey(KeyCode.UpArrow))
        {
            if (RealdyInput)
            {
                if (Selectcur == 0)
                {
                    Selectcur = buttonCount;
                }
                else
                {
                    Selectcur--;
                }
                SetPointPos();
                RealdyInput = false;
            }
        }
        else
        if (Input.GetKey(KeyCode.DownArrow))
        {
            if (RealdyInput)
            {
                if (Selectcur == buttonCount)
                {
                    Selectcur = 0;
                }
                else
                {
                    Selectcur++;
                }
                SetPointPos();
                RealdyInput = false;
            }
        }
        else
            if (Input.GetKey(KeyCode.Return))
        {
            Transform button = buttonPlace.GetChild(Selectcur);
            Button btn = button.GetComponent<Button>();
            btn.onClick.Invoke();
        }
        else
            RealdyInput = true;

    }
    private void SetPointPos()
    {
        Transform button = buttonPlace.GetChild(Selectcur);
        Pointer.transform.position = button.position;
    }

    public void NewGame()
    {
        SceneManager.LoadScene("GameScene");
    }
    public void Resume()
    {
        Debug.Log("resume");
    }
    public void Exit()
    {
        Application.Quit();
    }
}
