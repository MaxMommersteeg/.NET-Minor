using System;

public class Gameroom
{
    public TTTColour Colour { get; set; }
    public string Gamename { get; set; }
    public string Roomname { get; set; }
    private IRepository _repo;

    public Gameroom(IRepository repo)
    {
       _repo = repo;
    }

    public void Create(string roomname, string gamename, TTTColour colour)
    {
        Roomname = roomname;
        Gamename = gamename;
        Colour = colour;

        _repo.Insert(this);
    }
}