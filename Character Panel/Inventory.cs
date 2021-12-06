using UnityEngine;

public class Inventory : ItemContainer
{
	[SerializeField] protected Item[] startingItems;
	[SerializeField] protected Transform itemsParent;


	public Item Mineral;

	protected override void OnValidate()
	{
		if (itemsParent != null)
			itemsParent.GetComponentsInChildren(includeInactive: true, result: ItemSlots);

		if (!Application.isPlaying) {
			SetStartingItems();
		}
	}

	protected override void Awake()
	{
		base.Awake();
		SetStartingItems();
	}

	private void SetStartingItems()
	{
		Clear();
		foreach (Item item in startingItems)
		{
			if(item.id == "62913bfa78f63fd47b088672a1769f96")
			{
				Mineral = item;
			}
			else
			{
				AddItem(item.GetCopy());
			}
		}
	}

	public void AgregarMineral()
	{
		AddItem(Mineral.GetCopy());
	} 
}
