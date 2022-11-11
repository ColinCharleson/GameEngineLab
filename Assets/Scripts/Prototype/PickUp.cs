using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PickUp : MonoBehaviour
{
	public abstract GameObject Spawn();
	public abstract PickUp Clone();
}

public class Coin : PickUp
{
	private int score;
	private GameObject clone;

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
	private int score;
	private GameObject clone;

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
	private int score;
	private GameObject clone;

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
	private int score;
	private GameObject clone;

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
