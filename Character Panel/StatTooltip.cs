using System.Text;
using UnityEngine;
using UnityEngine.UI;
using Kryz.CharacterStats;

public class StatTooltip : MonoBehaviour
{
	[SerializeField] Text StatNameText;
	[SerializeField] Text StatModifiersLabelText;
	[SerializeField] Text StatModifiersText;

	private readonly StringBuilder sb = new StringBuilder();

	private Camera uiCamera;
	public void Update()
    {
        Vector2 localPoint;
        
        RectTransformUtility.ScreenPointToLocalPointInRectangle(transform.parent.GetComponent<RectTransform>(), Input.mousePosition *1.04f, uiCamera, out localPoint);
        localPoint.x += 36;
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

	public void ShowTooltip(CharacterStat stat, string statName)
	{
		Update();
		StatNameText.text = GetStatTopText(stat, statName);
		StatModifiersText.text = GetStatModifiersText(stat);
		gameObject.SetActive(true);
	}

	public void HideTooltip()
	{
		gameObject.SetActive(false);
		gameObject.transform.position = AquiSeEscondera;
	}

	private string GetStatTopText(CharacterStat stat, string statName)
	{
		sb.Length = 0;
		sb.Append(statName);
		sb.Append(" ");
		sb.Append(stat.Value);

		if (stat.Value != stat.BaseValue)
		{
			sb.Append(" (");
			sb.Append(stat.BaseValue);

			if (stat.Value > stat.BaseValue)
				sb.Append("+");

			sb.Append(System.Math.Round(stat.Value - stat.BaseValue, 4));
			sb.Append(")");
		}

		return sb.ToString();
	}

	private string GetStatModifiersText(CharacterStat stat)
	{
		sb.Length = 0;

		foreach (StatModifier mod in stat.StatModifiers)
		{
			if (sb.Length > 0)
				sb.AppendLine();

			if (mod.Value > 0)
				sb.Append("+");

			if (mod.Type == StatModType.Flat)
			{
				sb.Append(mod.Value);
			}
			else
			{
				sb.Append(mod.Value * 100);
				sb.Append("%");
			}

			Item item = mod.Source as Item;

			if (item != null)
			{
				sb.Append(" ");
				sb.Append(item.ItemName);
			}
			else
			{
				Debug.LogError("Modifier is not an Item!");
			}
		}

		return sb.ToString();
	}
}