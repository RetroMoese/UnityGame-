using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class demoui : MonoBehaviour
{
    public GameObject DemoMainMenu;
    public GameObject DemoMonu;
    // Start is called before the first frame update
    void newgame()
    {
        
    }

    // Update is called once per frame
    void options()
    {
        DemoMainMenu.SetActive(false);
        DemoMonu.SetActive(true);
    }
    void exitgame()
    {

    }

    void Update()
    {
       if(Input.GetKeyDown(KeyCode.Escape)){
        if(DemoMonu.activeSelf==true){
            DemoMainMenu.SetActive(true);
            DemoMonu.SetActive(false);
            return;
        }
       } 
    }
}
