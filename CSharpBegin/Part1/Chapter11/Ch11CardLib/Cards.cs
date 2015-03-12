using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch11CardLib
{
    public class Cards : CollectionBase
    {
        public void Add(Card newCard)
        {
            List.Add(newCard);
        }

        public void Remove(Card oldCard)
        {
            List.Remove(oldCard);
        }

        public Cards()
        { }

        public Card this[int cardIndex]
        {
            get { return (Card)List[cardIndex]; }
            set { List[cardIndex] = value; }
        }

        /// <summary>
        /// 通用方法，将所有的card对象复制到另外一个Cards中
        /// 这个方法使用的前提是，目标集合和当前的集合，有相同的大小
        /// </summary>
        /// <param name="targetCards"></param>
        public void CopyTo(Cards targetCards)
        {
            for (int index = 0; index < Count; index++)
            {
                targetCards[index] = this[index];
            }
        }

        /// <summary>
        /// 检查集合中是否有特定的卡牌
        /// 调用了ArrayList的Contains方法，通过InnerList属性来调用
        /// </summary>
        /// <param name="card"></param>
        /// <returns></returns>
        public bool Contains(Card card)
        {
            bool flag = InnerList.Contains(card);
            return flag;
        }
    }
}
