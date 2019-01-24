using DecklistProjectASP.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DecklistProjectASP.Services
{
    public class FromYDKToCodedDeck : IFromYDKToCodedDeck
    {
        public Deck Convert(string ydkText)
        {
            Deck deck = new Deck();
            try
            {
                string st = ydkText.Replace("\r", "");
                string[] lines = st.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);
                int flag = 1;
                foreach (string line in lines)
                {
                    if (line == "#main")
                    {
                        flag = 1;
                    }
                    else if (line == "#extra")
                    {
                        flag = 2;
                    }
                    else if (line == "!side")
                    {
                        flag = 3;
                    }
                    else
                    {
                        int code = 0;
                        try
                        {
                            code = Int32.Parse(line);
                        }
                        catch (Exception)
                        {

                        }
                        if (code > 100)
                        {
                            deck.FullDeck.Add(code);
                            switch (flag)
                            {
                                case 1:
                                    {
                                        deck.Main.Add(code);
                                    }
                                    break;
                                case 2:
                                    {
                                        deck.Extra.Add(code);
                                    }
                                    break;
                                case 3:
                                    {
                                        deck.Side.Add(code);
                                    }
                                    break;
                                default:
                                    break;
                            }
                        }
                    }
                }
            }
            catch
            {

            }
            return deck;
        }
    }
}
