using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ch10CardLib
{
    public class Deck
    {
        private Card[] cards;

        public Deck()
        {
            cards = new Card[52];
            //对花色和数字的所有组合进行迭代
            for (int suitVal = 0; suitVal < 4; suitVal++)
            {
                for (int rankVal = 1; rankVal <= 13; rankVal++)
                {
                    cards[suitVal * 13 + rankVal - 1] = new Card((Suit)suitVal, (Rank)rankVal);//创建新卡牌
                }
            }

        }

        public Card GetCard(int cardNum)
        {
            if (cardNum >= 0 && cardNum <= 51)
            {
                return cards[cardNum];
            }
            else
            {
                throw new System.ArgumentOutOfRangeException("cardNum", cardNum, "Value must be between 0 and 51.");
            }
        }

        /// <summary>
        /// 洗牌
        /// </summary>
        public void Shuffle()
        {
            Card[] newDeck = new Card[52];//临时的扑克牌数组
            bool[] assigned = new bool[52];
            Random sourceGen = new Random();
            //将cards中顺序位置的牌，放到newDeck的随机位置上
            for (int i = 0; i < 52; i++)
            {
                int destCard = 0;
                bool foundCard = false;
                //while查找没有复制过卡牌的位置
                while (foundCard == false)
                {
                    destCard = sourceGen.Next(52);
                    if (assigned[destCard] == false)
                    {
                        foundCard = true;
                    }
                }
                assigned[destCard] = true;
                newDeck[destCard] = cards[i];//将cards数组中的牌复制到临时卡组
            }
            newDeck.CopyTo(cards, 0);//不可以使用cards=newDeck，否则的话就用了另一个对象，如果其他地方还保持了对cards引用的话，就会出问题
        }
    }
}
