namespace BKE.GameAdministation.Commands
{
    public class CreateRoomCommand
    {
        public string RoomName { get; set; }
        public long GameID { get; set; }
        public long PlayerID { get; set; }
        public string Colour { get; set; }
    }
}