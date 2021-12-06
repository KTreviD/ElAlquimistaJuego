using UnityEngine;
using UnityEngine.UI;

public class ItemTooltip : MonoBehaviour
{
	[SerializeField] Text ItemNameText;
	[SerializeField] Text ItemTypeText;
	[SerializeField] Text ItemDescriptionText;

	private Camera uiCamera;
	public void Update()
    {
    	Vector2 localPoint;
    	RectTransformUtility.ScreenPointToLocalPointInRectangle(transform.parent.GetComponent<RectTransform>(), Input.mousePosition *1.01f, uiCamera, out localPoint);
    	localPoint.x += 40;
   		transform.localPosition = localPoint;
    }
	Vector3 AquiSeEscondera;
	public void PosicionEsconder()
	{
		AquiSeEscondera = new Vector3(0.0f,0.0f,0.0f);
		AquiSeEscondera.x =0;
		AquiSeEscondera.y =0;
		AquiSeEscondera.z =0;
	}
	private void Awake()
	{
		gameObject.SetActive(false);
	}

	public RectTransform Prueba;

	public void ShowTooltip(Item item)
	{
		if(item.ArribaAbajo == false)
		{
			Prueba = gameObject.GetComponent<RectTransform>();
			Prueba.SetAnchor(AnchorPresets.BottomLeft);
			Prueba.SetPivot(PivotPresets.BottomLeft);
		}
		else
		{
			Prueba = gameObject.GetComponent<RectTransform>();
			Prueba.SetAnchor(AnchorPresets.TopLeft);
			Prueba.SetPivot(PivotPresets.TopLeft);
		}
		Update();
		ItemNameText.text = item.ItemName;
		ItemTypeText.text = item.GetItemType();
		ItemDescriptionText.text = item.GetDescription();
		gameObject.SetActive(true);

		
	}

	public void HideTooltip()
	{
		gameObject.SetActive(false);
		gameObject.transform.position = AquiSeEscondera;
	}

}
