using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PickUp : MonoBehaviour
{
	protected int score;
	protected int heal;

	protected GameObject clone;
	public abstract GameObject Spawn();
	public abstract PickUp Clone();
}

public class Coin : PickUp
{
	public Coin(GameObject clone, int score)
    {
        this.score = score;
        this.clone = clone;
    }
	public override GameObject Spawn()
	{
		if (!clone.GetComponent<Collectable>())
		{
		clone.AddComponent<Collectable>();
		}

		clone.AddComponent<Collectable>().score = score;

		return clone;
	}
	public override PickUp Clone()
	{
		return new Coin(Instantiate(clone), score);
	}
} 
public class BlueGem : PickUp
{
	public BlueGem(GameObject clone, int score)
    {
        this.score = score;
        this.clone = clone;
    }
	public override GameObject Spawn()
	{
		if (!clone.GetComponent<Collectable>())
		{
		clone.AddComponent<Collectable>();
		}

		clone.AddComponent<Collectable>().score = score;

		return clone;
	}
	public override PickUp Clone()
	{
		return new BlueGem(Instantiate(clone), score);
	}
}
public class GreenGem : PickUp
{
	public GreenGem(GameObject clone, int score)
	{
		this.score = score;
		this.clone = clone;
	}
	public override GameObject Spawn()
	{
		if (!clone.GetComponent<Collectable>())
		{
			clone.AddComponent<Collectable>();
		}

		clone.AddComponent<Collectable>().score = score;

		return clone;
	}
	public override PickUp Clone()
	{
		return new GreenGem(Instantiate(clone), score);
	}
}
public class RedGem : PickUp
{
	public RedGem(GameObject clone, int score)
    {
        this.score = score;
        this.clone = clone;
    }
	public override GameObject Spawn()
	{
		if (!clone.GetComponent<Collectable>())
		{
		clone.AddComponent<Collectable>();
		}

		clone.AddComponent<Collectable>().score = score;

		return clone;
	}
	public override PickUp Clone()
	{
		return new RedGem(Instantiate(clone), score);
	}
}
public class Heart : PickUp
{
	public Heart(GameObject clone, int healValue)
    {
        this.heal = healValue;
        this.clone = clone;
    }
	public override GameObject Spawn()
	{
		if (!clone.GetComponent<Collectable>())
		{
		clone.AddComponent<Collectable>();
		}

		clone.AddComponent<Collectable>().heal = heal;

		return clone;
	}
	public override PickUp Clone()
	{
		return new Heart(Instantiate(clone), heal);
	}
}

public class Key : PickUp
{
	public Key(GameObject clone)
    {
        this.clone = clone;
    }
	public override GameObject Spawn()
	{
		if (!clone.GetComponent<Collectable>())
		{
		clone.AddComponent<Collectable>();
		}

		clone.GetComponent<Collectable>().heal = 0;
		clone.GetComponent<Collectable>().score = 0;

		return clone;
	}
	public override PickUp Clone()
	{
		return new Key(Instantiate(clone));
	}
}
