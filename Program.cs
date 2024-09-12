using System;
using System.Security.Cryptography.X509Certificates;

class Character
{
	private string name;

	public string Name
	{
		get { return name; }
		set { name = value; }
	}

	private int health;

	public int Health
	{
		get { return health; }
		set { health = value; }
	}

	private int attack_power;

	public int AttackPower
	{
		get { return attack_power; }
		set { attack_power = value; }
	}

	private int defense;

	public int Defense
	{
		get { return defense; }
		set { defense = value; }
	}


	public void Attack(Character target)
    {
        Console.WriteLine($"{Name} atakuje {target.Name} i zadaje: {AttackPower-Defense} obrażeń.");
        target.TakeDamage(AttackPower-Defense);
    }

    public void TakeDamage(int damage)
    {
        Health -= damage;
        Console.WriteLine($"{Name} traci {damage} punktów zdrowia. Pozostało {Health} PZ.");
        Console.WriteLine();
    }

}

class Program
{
    static void Main(string[] args)
    {
		Character player = new Character();
		player.Name = "Gracz";
		player.Health = 50;
		player.AttackPower = 25;
		player.Defense = 1;

		Character enemy = new Character();
		enemy.Name = "Goblin";
		enemy.Health = 50;
		enemy.AttackPower = 2;
		enemy.Defense = 1;

		while(player.Health > 0 && enemy.Health > 0)
		{
			Console.Clear();
			
            player.Attack(enemy);
            Thread.Sleep(2000);
            if (enemy.Health <= 0)
            {
                Console.WriteLine($"{enemy.Name} ginie.");
                break;
            }

            enemy.Attack(player);
			Thread.Sleep(2000);
            if (player.Health <= 0)
            {
                Console.WriteLine($"{player.Name} ginie.");
                break;
            }
        }
    }
}
