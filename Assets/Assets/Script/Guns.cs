using System;

public class Guns
{
	private int damage;
	private float delay;
	private int bulletCount;

	public int Damage { get => damage; set => damage = value; }
	public float Delay { get => delay; set => delay = value; }
	public int BulletCount { get => bulletCount; set => bulletCount = value; }
}
public class DefaultGun : Guns
{
	public DefaultGun()
	{
		Damage = 25;
		Delay = 2f;
		BulletCount = 10;//practically doesnt do anything
	}
}
public class Pistol : Guns
{
	public Pistol(){
		Damage = 35;
		Delay = 1f;
		BulletCount = 20;//practically doesnt do anything
	}
}
public class SubM : Guns
{
	public SubM()
	{
		Damage = 40;
		Delay = 0.3f;
		BulletCount = 30;//practically doesnt do anything
	}
}
public class Rifle : Guns
{
	public Rifle()
	{
		Damage = 45;
		Delay = 2f;
		BulletCount = 30;//practically doesnt do anything
	}

}


