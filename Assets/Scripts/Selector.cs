using UnityEngine;
using UnityEngine.UI;

public class Selector : MonoBehaviour 
{
    public bool pvp = false;

    #region publicVariables
        public Image PVE_image;
        public Image PVP_image;
        public SaveAndLoad saveAndLoad;
        public GameObject sel;
    #endregion

    private void Start() 
    {
        sel.GetComponent<Button>().onClick.AddListener(SelectorButton);
        pvp = saveAndLoad.LoadBool(gameObject.name);
    }
    private void Update() 
    {
        SelectChanger();
    }

    public void SelectorButton()
    {
        pvp = !pvp;
        saveAndLoad.SaveBool(pvp, gameObject.name);
    }

    public void SelectChanger()
    {
        if(!pvp)
        {
            PVE_image.fillAmount = 1;
            PVP_image.fillAmount = 0;
        }
        else
        {
            PVE_image.fillAmount = 0;
            PVP_image.fillAmount = 1;
        }
    }    
}