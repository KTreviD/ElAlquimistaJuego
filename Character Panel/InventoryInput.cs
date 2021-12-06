using UnityEngine;

public class InventoryInput : MonoBehaviour
{
	[SerializeField] GameObject characterPanelGameObject;
	[SerializeField] GameObject equipmentPanelGameObject;
	[SerializeField] KeyCode[] toggleCharacterPanelKeys;
	[SerializeField] KeyCode[] toggleInventoryKeys;

	void Update()
	{
		ToggleCharacterPanel();
		ToggleInventory();
	}

	private void ToggleCharacterPanel()
	{
		for (int i = 0; i < toggleCharacterPanelKeys.Length; i++)
		{
			if (Input.GetKeyDown(toggleCharacterPanelKeys[i]))
			{
				characterPanelGameObject.SetActive(!characterPanelGameObject.activeSelf);

				if (characterPanelGameObject.activeSelf)
				{
					equipmentPanelGameObject.SetActive(true);
				}
				break;
			}
		}
	}

	private void ToggleInventory()
	{
		for (int i = 0; i < toggleInventoryKeys.Length; i++)
		{
			if (Input.GetKeyDown(toggleInventoryKeys[i]))
			{
				if (!characterPanelGameObject.activeSelf)
				{
					characterPanelGameObject.SetActive(true);
					equipmentPanelGameObject.SetActive(false);
				}
				else if (equipmentPanelGameObject.activeSelf)
				{
					equipmentPanelGameObject.SetActive(false);
				}
				else
				{
					characterPanelGameObject.SetActive(false);
				}
				break;
			}
		}
	}

	public void ToggleEquipmentPanel()
	{
		equipmentPanelGameObject.SetActive(!equipmentPanelGameObject.activeSelf);
	}
}
