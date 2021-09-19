using UnityEngine;
using UnityEngine.Advertisements;

public class AD_Video : MonoBehaviour 
{
    public NailDown nail;

    private void Start() 
    {
        Advertisement.Initialize("3803873", false);   
    }

    private void Update() 
    {
        if (nail.tries == 3)
        {
            if (Advertisement.IsReady("video"))
            {
                Advertisement.Show("video");

            }
            nail.tries = 0;
        }
    }
}