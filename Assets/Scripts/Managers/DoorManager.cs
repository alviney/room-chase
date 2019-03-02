using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorManager : MonoBehaviour
{
    public Object[] doors;
    private bool open = true;

    #region 
    public static DoorManager instance = null;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }
    #endregion

    private void Start()
    {
        doors = FindObjectsOfType(typeof(Door));
        HideDoors();
    }
    // public void AddDoor(Door door)
    // {
    //     doors.Add(door);
    // }

    public void ToggleDoors()
    {
        if (open)
        {
            ShowDoors();
            open = false;
        }
        else
        {
            HideDoors();
            open = true;
        }
    }

    public void ShowDoors()
    {
        foreach (Door door in doors)
        {
            door.EnableTrigger();
        }
    }
    public void HideDoors()
    {
        foreach (Door door in doors)
        {
            door.DisableTrigger();
        }
    }
}
