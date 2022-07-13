using UnityEngine;

public class Control : MonoBehaviour
{
    [SerializeField] private Menu _menu;

    bool _menuIsOpen=false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            _menuIsOpen = !_menuIsOpen;
            OpenningMenuByESC();
        }
    }

    private void OpenningMenuByESC()
   {
        if(_menuIsOpen==false)
        {
            _menu.OpenMenuWindow();
        }
        else
        {
            _menu.CloseMenuWindow();
        }
   }
}
