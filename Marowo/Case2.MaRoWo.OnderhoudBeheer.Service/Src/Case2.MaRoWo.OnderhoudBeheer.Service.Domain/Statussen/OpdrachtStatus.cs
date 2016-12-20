namespace Case2.MaRoWo.OnderhoudBeheer.Service.Domain.Statussen {
    public class OpdrachtStatus
    {
        public OpdrachtStatus(int statusId, string beschrijving)
        {
            StatusId = statusId;
            Beschrijving = beschrijving;
        }

        public int StatusId { get; set; }
        public string Beschrijving { get; set; }
    }
}
