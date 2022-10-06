using System;
using System.Collections.Generic;

internal class Program
{
    static void Main(string[] args)
    {
        const string ShowAllPlayers = "1";
        const string AddPlayer = "2";
        const string BanPlayer = "3";
        const string UnbanPlayer = "4";
        const string DeletePlayer = "5";
        const string Exit = "Exit";
        bool exit = false;

        DataBase dataBase = new DataBase();

        while (exit == false)
        {
            Console.WriteLine($"Введите {ShowAllPlayers} - для просмотра всех игроков, {AddPlayer} - добавления игрока, {BanPlayer} - забанить игрока, {UnbanPlayer} - разбанить игрока, {DeletePlayer} - удалить игрока, {Exit} - выйти из программы");
            string userChose = Console.ReadLine();

            switch (userChose)
            {
                case ShowAllPlayers:
                    Console.Clear();
                    dataBase.ShowAllPlayers();
                    break;

                case AddPlayer:
                    Console.Clear();
                    dataBase.AddPlayer();
                    break;

                case BanPlayer:
                    Console.Clear();
                    dataBase.BanPlayer();
                    break;

                case UnbanPlayer:
                    Console.Clear();
                    dataBase.UnbanPlayer();
                    break;

                case DeletePlayer:
                    Console.Clear();
                    dataBase.DeletePlayer();
                    break;

                case Exit:
                    exit = true;
                    break;
            }
        }
    }
}

class DataBase
{
    private List<Player> _players = new List<Player>();

    public DataBase()
    {
        _players = new List<Player>();
    }

    public void ShowAllPlayers()
    {
        foreach (Player player in _players)
        {
            Console.WriteLine(player.UniqNumber + " " + player.NickName + " " + player.Level + " " + (player.IsBane ? "Забанен" : "Не забанен"));
        }
    }

    public void AddPlayer()
    {
        string nickName;
        int level;

        Console.WriteLine("Введите ник игрока: ");
        nickName = Console.ReadLine();
        Console.WriteLine("Введите уровень игрока: ");
        level = Convert.ToInt32(Console.ReadLine());

        _players.Add(new Player(nickName, level, false));
    }

    public void BanPlayer()
    {
        FindPlayer(GetUniqNumber()).BanPlayer();
    }

    public void UnbanPlayer()
    {
         FindPlayer(GetUniqNumber()).UnbanPlayer();
    }

    public void DeletePlayer()
    {
        _players.Remove(FindPlayer(GetUniqNumber()));
    }

    public Player FindPlayer(int uniqNumber)
    {
        foreach (Player player in _players)
        {
            if (player.UniqNumber == uniqNumber)
            {
                return player;
            }
        }

        return null;
    }
    static int GetUniqNumber()
    {
        bool isParse = false;
        int numberForReturn = 0;

        while (isParse == false)
        {            
            Console.WriteLine("Введите уникальный номер игрока: ");
            string uniqNumber = Console.ReadLine();

            if (isParse == int.TryParse(uniqNumber, out int number))
            { 
            }
            else
            {
                Console.WriteLine("Вы не корректно ввели число.");                
            }

            numberForReturn = number;
        }

        return numberForReturn;
    }
}

class Player
{
    public static int UniqNumbers { get; private set; }
    public int UniqNumber { get; private set; }
    public string NickName { get; private set; }
    public int Level { get; private set; }
    public bool IsBane { get; private set; }

    public Player(string nickName, int level, bool isBane)
    {
        UniqNumber = ++UniqNumbers;
        NickName = nickName;
        Level = level;
        IsBane = isBane;
    }

    public Player()
    {
    }

    public void BanPlayer()
    {
        this.IsBane = true;
    }

    public void UnbanPlayer()
    {
        this.IsBane = false;
    }
}
