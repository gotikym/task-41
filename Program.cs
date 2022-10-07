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
        bool isExit = false;

        DataBase dataBase = new DataBase();

        while (isExit == false)
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
                    isExit = true;
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
            Console.WriteLine(player.UniqNumber + " " + player.NickName + " " + player.Level + " " + (player.IsBanned ? "Забанен" : "Не забанен"));
        }
    }

    public void AddPlayer()
    {
        string nickName;
        int level;

        Console.WriteLine("Введите ник игрока: ");
        nickName = Console.ReadLine();
        Console.WriteLine("Введите уровень игрока: ");
        level = GetNumber();

        _players.Add(new Player(nickName, level, false));
    }

    public void BanPlayer()
    {
        Console.WriteLine("Введите уникальный номер игрока: ");
        FindPlayer(GetNumber()).Ban();
    }

    public void UnbanPlayer()
    {
        Console.WriteLine("Введите уникальный номер игрока: ");
        FindPlayer(GetNumber()).Unban();
    }

    public void DeletePlayer()
    {
        Console.WriteLine("Введите уникальный номер игрока: ");
        _players.Remove(FindPlayer(GetNumber()));
    }

    private Player FindPlayer(int uniqNumber)
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

    private int GetNumber()
    {
        bool isParse = false;
        int numberForReturn = 0;

        while (isParse == false)
        {            
            string userNumber = Console.ReadLine();

            if ((isParse = int.TryParse(userNumber, out int number)) == false)
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
    public bool IsBanned { get; private set; }

    public Player(string nickName, int level, bool isBanned)
    {
        UniqNumber = ++UniqNumbers;
        NickName = nickName;
        Level = level;
        IsBanned = isBanned;
    }

    public void Ban()
    {
        IsBanned = true;
    }

    public void Unban()
    {
        IsBanned = false;
    }
}
