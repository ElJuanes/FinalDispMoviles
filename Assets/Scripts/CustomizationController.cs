using UnityEngine;

public class CustomizationController : MonoBehaviour
{
    public GameObject gafas;
    public GameObject gorro;
    public GameObject accesorio;

    public void GafasSkin()
    {
        ToggleItem(gafas);
    }

    public void GorroSkin()
    {
        ToggleItem(gorro);
    }

    public void AccesorioSkin()
    {
        ToggleItem(accesorio);
    }
    private void ToggleItem(GameObject item)
    {
        if (item != null)
        {
            item.SetActive(!item.activeSelf);
        }
    }
}
