using Godot;
using System;

public class Unit : Sprite
{
	Lifebar lifebar;
	private System.Collections.Generic.Dictionary<String, String> attributes = new System.Collections.Generic.Dictionary<String, String>();

	private int side;

	private int baseMaxHealth;
	private int baseMaxMoves;

	private int currentHealth;
	private int currentMoves;
	private int damage;

	public override void _Ready()
	{
		damage = int.Parse(attributes["damage"]);
		currentHealth = int.Parse(attributes["hitpoints"]);
		currentMoves = int.Parse(attributes["movement"]);

		baseMaxHealth = currentHealth;
		baseMaxMoves = currentMoves;

		lifebar = (Lifebar)GetNode("Lifebar");
		lifebar.SetValueMax(baseMaxHealth);
		lifebar.SetValue(baseMaxHealth);
	}

	public void SetAttributes(System.Collections.Generic.Dictionary<String, String> attributes)
	{
		this.attributes = attributes;
	}

	public int GetSide()
	{
		return side;
	}

	public int GetBaseMaxHealth()
	{
		return baseMaxHealth;
	}

	public int GetBaseMaxMoves()
	{
		return baseMaxMoves;
	}

	public int GetCurrentHealth()
	{
		return currentHealth;
	}

	public int GetCurrentMoves()
	{
		return currentMoves;
	}

	public int GetDamage()
	{
		return damage;
	}

	public void SetSide(int side)
	{
		this.side = side;
	}

	public void SetHealth(int health)
	{
		this.currentHealth = health;
		lifebar.SetValue(health);
	}

	public void Fight(Unit unit)
	{
		unit.Harm(damage);

		if (unit.GetCurrentHealth() > 0)
		{
			Harm(unit.GetDamage());
		}
	}

	public void Harm(int damage)
	{
		SetHealth(currentHealth - damage);
	}

	public void Restore()
	{
		currentHealth = baseMaxHealth;
		currentMoves = baseMaxMoves;
	}
}