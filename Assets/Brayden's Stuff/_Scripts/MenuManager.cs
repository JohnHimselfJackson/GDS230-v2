using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    //A reference to our current menu & sub menu.
    public Menu currentMenu;

    //A reference to our play states.
    public playState playStates;

    //Our play & pause state enums.
    public enum playState
    {
        Menu,
        Play
    }

    public void Start()
    {
        ShowMenu(currentMenu);
    }

    private void Update()
    {
        PlayHandle();
    }

    //Handles our states between menu & game.
    void PlayHandle()
    {
        switch (playStates)
        {
            case playState.Menu:
                //our audioclip equals MainMenu Clip.
                //Reset our game progress.
                break;
            case playState.Play:
                //Our audioClip equal Game Clip.
                //Set Our menus to nothing.
                break;
            default:
                //REEEEE
                break;
        }
    }

    //Plays our game.
    public void PlayGame()
    {
        playStates = playState.Play;
    }

    //Handles which menu is our current menu depending on our selection.
    public void ShowMenu(Menu menu)
    {
        if (currentMenu != null)
            currentMenu.IsOpen = false;

        currentMenu = menu;
        currentMenu.IsOpen = true;

    }
}
