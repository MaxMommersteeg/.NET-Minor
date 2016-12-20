namespace BKE.GameAdministation.Commands
{
    public class JoinRoomCommand
    {
        public string RoomName { get; set; }
        public long PlayerID { get; set; }
        public string Colour { get; set; }
    }
}