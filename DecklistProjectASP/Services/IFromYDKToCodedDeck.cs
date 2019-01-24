using System.Threading.Tasks;
using DecklistProjectASP.ViewModel;

namespace DecklistProjectASP.Services
{
    public interface IFromYDKToCodedDeck
    {
        Deck Convert(string ydkText);
    }
}