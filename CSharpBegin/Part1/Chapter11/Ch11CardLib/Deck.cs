using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ch11CardLib
{
    public class Deck
    {
        private Cards cards = new Cards();

        public Deck()
        {
            //对花色和数字的所有组合进行迭代
            for (int suitVal = 0; suitVal < 4; suitVal++)
            {
                for (int rankVal = 1; rankVal <= 13; rankVal++)
                {
                    cards.Add(new Card((Suit)suitVal, (Rank)rankVal));
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
            Cards newDeck = new Cards();//临时的扑克牌数组
            bool[] assigned = new bool[52];
            Random sourceGen = new Random();
            //将cards中随机的一张牌添加到newDeck的开头
            for (int i = 0; i < 52; i++)
            {
                int sourceCard = 0;
                bool foundCard = false;
                //while查找没有复制过卡牌的位置
                while (foundCard == false)
                {
                    sourceCard = sourceGen.Next(52);
                    if (assigned[sourceCard] == false)
                    {
                        foundCard = true;
                    }
                }
                assigned[sourceCard] = true;
                newDeck.Add(cards[sourceCard]);//将cards数组中的牌复制到临时卡组
            }
            newDeck.CopyTo(cards);//不可以使用cards=newDeck，否则的话就用了另一个对象，如果其他地方还保持了对cards引用的话，就会出问题
        }
    }
}
