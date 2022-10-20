using System;

namespace MODEL
{
    public class Game
    {
        private CardNode deck;

        //creates an ordered card node and randomly shuffles it
        public Game()
        {
            //creates an ordered node
            Card firstCard = new Card(1, false);
            CardNode ordered = new CardNode(firstCard, null);
            CardNode pointer = ordered;
            for (int i = 2; i <= 12; i++)
            {
                Card card = new Card(i, false);
                CardNode whileTmp = new CardNode(card, null);
                pointer.SetNext(whileTmp);
                pointer = pointer.GetNext();
            }

            CardNode shuffled = new CardNode();
            CardNode shuffledPointer = shuffled;

            //makes the max random between 1-12
            int maxRnd = 13;

            //creates a shuffled node
            while (maxRnd > 1)
            {
                //creates two pointers
                pointer = ordered;
                CardNode pointer2 = ordered.GetNext();

                //creates new random
                Random rnd = new Random();
                int rndNum = rnd.Next(1, maxRnd);

                //takes out the node at the random place and places it at the end of the shuffled node
                for (int i = 0; i < rndNum; i++)
                {
                    pointer = pointer.GetNext();
                    pointer2 = pointer2.GetNext();
                }
                pointer.SetNext(pointer2.GetNext());
                pointer2.SetNext(null);
                shuffledPointer.SetNext(pointer2);
                shuffledPointer = shuffledPointer.GetNext();

                //makes the max random smaller
                maxRnd--;
            }
            this.deck = shuffled;
        }

        public Card GetCard(int index)
        {
            // get card by index
            return null;
        }

        public int AreTheSamePicture(Card card)
        {
            for (int i = 0; i < 12; i++)
            {
                if (this.deck.GetValue().GetNameNum() + card.GetNameNum() == 13)
                    return i;
            }
            return -1;
        }
    }

    public class CardNode
    {
        Card card;
        CardNode next;

        public CardNode()
        {
            card = null;
            next = null;
        }

        public CardNode(Card card, CardNode next)
        {
            this.card = card;
            this.next = next;
        }

        public CardNode GetNext()
        {
            return this.next;
        }

        public Card GetValue()
        {
            return this.card;
        }

        public void SetNext(CardNode next)
        {
            this.next = next;
        }

        public void SetValue(Card card)
        {
            this.card = card;
        }

        public override string ToString()
        {
            return " " + this.card;
        }
    }

    public class Card
    {
        int nameNum;
        bool flipped;

        public Card()
        {
            nameNum = 0;
            flipped = false;
        }

        public Card(int nameNum, bool flipped)
        {
            this.nameNum = nameNum;
            this.flipped = flipped;
        }

        public int GetNameNum()
        {
            return nameNum;
        }

        public bool IsFlipped()
        {
            return flipped;
        }

        public void SetNameNum(int nameNum)
        {
            this.nameNum = nameNum;
        }

        public void Flip()
        {
            this.flipped = !this.flipped;
        }

        public override string ToString()
        {
            return "flipped: " + flipped + ", name: " + nameNum;
        }
    }
}
