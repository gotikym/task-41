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
                    dataBase.ShowAllPlayers();
                    break;

                case AddPlayer:
                    dataBase.AddPlayer();
                    break;

                case BanPlayer:
                    dataBase.BanPlayer();
                    break;

                case UnbanPlayer:
                    dataBase.UnbanPlayer();
                    break;

                case DeletePlayer:
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
    Player player = new Player();

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

        player.AddPlayer(_players, nickName, level);
    }

    public void BanPlayer()
    {
        Console.WriteLine("Введите уникальный номер игрока: ");
        int uniqNumber = Convert.ToInt32(Console.ReadLine());

        player.BanPlayer(_players, uniqNumber);
    }

    public void UnbanPlayer()
    {
        Console.WriteLine("Введите уникальный номер игрока: ");
        int uniqNumber = Convert.ToInt32(Console.ReadLine());

        player.UnbanPlayer(_players, uniqNumber);
    }

    public void DeletePlayer()
    {
        Console.WriteLine("Введите уникальный номер игрока: ");
        int uniqNumber = Convert.ToInt32(Console.ReadLine());

        player.DeletePlayer(_players, uniqNumber);
    }
}

class Player
{
    public int UniqNumber { get; private set; }
    public string NickName { get; private set; }
    public int Level { get; private set; }
    public bool IsBane { get; private set; }

    public Player(int uniqNumber, string nickName, int level, bool isBane)
    {
        UniqNumber = uniqNumber;
        NickName = nickName;
        Level = level;
        IsBane = isBane;
    }

    public Player()
    {
    }

    public void AddPlayer(List<Player> _players, string nickName, int level)
    {
        _players.Add(new Player(++UniqNumber, nickName, level, false));
    }

    public Player FindPlayer(List<Player> _players, int uniqNumber)
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

    public void BanPlayer(List<Player> _players, int uniqNumber)
    {
        Player player = FindPlayer(_players, uniqNumber);
        player.IsBane = true;
    }

    public void UnbanPlayer(List<Player> _players, int uniqNumber)
    {
        Player player = FindPlayer(_players, uniqNumber);
        player.IsBane = false;
    }

    public void DeletePlayer(List<Player> _players, int uniqNumber)
    {
        Player player = FindPlayer(_players, uniqNumber);
        _players.Remove(player);
    }
}