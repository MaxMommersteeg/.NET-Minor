using Case2.MaRoWo.OnderhoudBeheer.Service.Incoming.Commands;

namespace Case2.MaRoWo.OnderhoudBeheer.Service.Domain.Services
{
    public interface IOnderhoudsopdrachtService
    {
        void AddOnderhoudsopdracht(CreateOnderhoudCommand onderhoudCommand);
        void UpdateOnderhoudsopdracht(UpdateOnderhoudCommand updateOnderhoudCommand);
        void OnderhoudsopdrachtAfmelden(OnderhoudAfmeldenCommand onderhoudAfmeldenCommand);
    }
}
